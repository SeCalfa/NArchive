using System.Collections.Generic;

namespace Assets.App.Code.MVVM.Models
{
    public class ArchiveModel
    {
        public List<Folder> Folders { get; set; } = new List<Folder>();
    }

    public class Folder
    {
        public List<TextDocument> TextDocuments { get; set; } = new List<TextDocument> { };
        public List<ListDocument> ListDocuments { get; set; } = new List<ListDocument> { };
    }

    public class TextDocument
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class ListDocument
    {
        public string Title { get; set; }
        public List<string> Elements { get; set; }
    }
}