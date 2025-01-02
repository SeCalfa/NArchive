using System;
using System.Collections.Generic;

namespace App.Code.MVVM.Models
{
    [Serializable]
    public class ArchiveModel
    {
        public List<TextDocument> textDocuments = new();
        public List<ListDocument> listDocuments = new();
    }

    [Serializable]
    public class TextDocument : Document
    {
        public string text;
    }

    [Serializable]
    public class ListDocument : Document
    {
        public List<string> elements = new();
    }

    [Serializable]
    public class Document
    {
        public string title;
    }
}