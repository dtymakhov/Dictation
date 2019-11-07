﻿namespace Dictation.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows.Input;
    using Dictation.Commands;
    using Dictation.Helpers;
    using Dictation.Services;
    using Dictation.Views;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public class MenuViewModel : Observable
    {
        private NavigationView navigationView;
        private NavigationViewItem selected;
        private ICommand itemInvokedCommand;

        public NavigationViewItem Selected
        {
            get { return selected; }
            set { Set(ref selected, value); }
        }

        public ICommand ItemInvokedCommand => itemInvokedCommand ?? (itemInvokedCommand = new RelayCommand<NavigationViewItemInvokedEventArgs>(OnItemInvoked));

        public void Initialize(Frame contentFrame, NavigationView navigationView)
        {
            this.navigationView = navigationView;
            NavigationService.ContentFrame = contentFrame;
            NavigationService.NavigationFailed += Frame_NavigationFailed;
            NavigationService.Navigated += Frame_Navigated;

            NavigationService.NavigateContent(typeof(OpenPage));
        }

        private void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                NavigationService.NavigateContent(typeof(SettingsPage));
                return;
            }

            var item = navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .First(menuItem => (string)menuItem.Content == (string)args.InvokedItem);

            if (item.Tag != null)
            {
                var tag = item.Tag.ToString();

                if (item.Tag.ToString() == "back")
                {
                    NavigationService.Navigate(typeof(MainPage));
                }

                return;
            }

            var pageType = item.GetValue(NavHelper.NavigateToProperty) as Type;
            NavigationService.NavigateContent(pageType);
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw e.Exception;
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            Selected = navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .FirstOrDefault(menuItem => IsMenuItemForPageType(menuItem, e.SourcePageType));
        }

        private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            var pageType = menuItem.GetValue(NavHelper.NavigateToProperty) as Type;
            return pageType == sourcePageType;
        }
    }
}