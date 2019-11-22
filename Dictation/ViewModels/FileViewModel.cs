﻿namespace Dictation.ViewModels
{
    using System;
    using System.IO;
    using System.Windows.Input;
    using Dictation.Models;

    public class FileViewModel
    {
        public DocumentModel Document { get; set; }

        public FileViewModel()
        {
            Document = DocumentModel.GetDocument();
        }

        public ICommand NewCommand { get; }

        public ICommand SaveCommand { get; }

        public ICommand SaveAsCommand { get; }

        public ICommand OpenCommand { get; }

        public void NewFile()
        {
            Document.Text = string.Empty;
            Document.Name = string.Empty;
            Document.Path = string.Empty;
        }

        private void SaveFile()
        {
            File.WriteAllText(Document.Path, Document.Text);
        }

        private void SaveAsFile()
        {
            throw new NotImplementedException();
        }

        private void OpenFile()
        {
            throw new NotImplementedException();
        }
    }
}