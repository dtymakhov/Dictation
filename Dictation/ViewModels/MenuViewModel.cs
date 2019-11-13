﻿namespace Dictation.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Dictation.Commands;
    using Dictation.Helpers;
    using Dictation.Models;
    using Dictation.Services;
    using Dictation.Views;
    using Windows.Storage.Pickers;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;

    public class MenuViewModel : Observable
    {
        private NavigationView navigationView;
        private NavigationViewItem selected;
        private ICommand itemInvokedCommand;

        public MenuViewModel(DocumentModel document)
        {
            Document = document;
        }

        public NavigationViewItem Selected
        {
            get { return selected; }
            set { Set(ref selected, value); }
        }

        public DocumentModel Document { get; set; }

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
                ChooseItem(tag);
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
            var sourcePageType = e.SourcePageType;
            if (sourcePageType == typeof(Menu))
            {
                sourcePageType = typeof(OpenPage);
            }

            Selected = navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .FirstOrDefault(menuItem => IsMenuItemForPageType(menuItem, sourcePageType));
        }

        private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            var pageType = menuItem.GetValue(NavHelper.NavigateToProperty) as Type;
            return pageType == sourcePageType;
        }

        private void ChooseItem(string tag)
        {
            switch (tag)
            {
                case "back":
                    NavigationService.Navigate(typeof(MainPage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight});
                    break;
                case "new":
                    NewFile();
                    break;
                case "save":
                    SaveFile();
                    break;
                case "close":
                    CloseFile();
                    break;
            }
        }

        private void NewFile()
        {
            //TODO: add New File
            throw new NotImplementedException();
        }

        private async void SaveFile()
        {
            FileSavePicker savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.Desktop,
                CommitButtonText = "Save",
            };
            List<string> filters = new List<string>() { ".txt", ".rtf", ".doc", ".docx", ".html", ".htm" };
            savePicker.FileTypeChoices.Add(".txt, .rtf, .doc, .docx, .html, .htm", filters); 
            var file = await savePicker.PickSaveFileAsync();
            int retryAttempts = 5;

            if (file != null)
            {
                // Application now has read/write access to the picked file.
                while (retryAttempts > 0)
                {
                        retryAttempts--;
                        await Windows.Storage.FileIO.WriteTextAsync(file, Document.Text);
                        break;
                }
            }

            NavigationService.Navigate(typeof(MainPage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void CloseFile()
        {
            //TODO: add Close File
            throw new NotImplementedException();
        } 

    }
}
