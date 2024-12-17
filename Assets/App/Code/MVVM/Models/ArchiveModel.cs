using System.Collections.Generic;

namespace Assets.App.Code.MVVM.Models
{
    public class ArchiveModel
    {
        public List<Document> Documents { get; set; } = new List<Document>();
    }

    public class TextDocument : Document
    {
        public string Text { get; set; }
    }

    public class ListDocument : Document
    {
        public List<string> Elements { get; set; }
    }

    public class Document
    {
        public string Title { get; set; }
    }
}