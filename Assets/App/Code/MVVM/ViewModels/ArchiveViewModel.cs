using Assets.App.Code.MVVM.Models;
using Assets.App.Code.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.App.Code.MVVM.ViewModels
{
    public class ArchiveViewModel
    {
        public event Action<int> OnFoldersCountChanged;
        public event Action OnDocumentAdd;
        public event Action<GameObject> OnPageOpen;

        private readonly ArchiveModel archiveModel;
        private readonly ArchiveView archiveView;
        private readonly GameObject listItem;

        private readonly List<ListItem> listItems = new();

        public ArchiveViewModel(ArchiveModel archiveModel, ArchiveView archiveView, GameObject listItem)
        {
            this.archiveModel = archiveModel;
            this.archiveView = archiveView;
            this.listItem = listItem;
        }

        private void UpdateFoldersCount()
        {
            OnFoldersCountChanged?.Invoke(archiveModel.Documents.Count);
        }

        public void AddTextDocument()
        {
            archiveModel.Documents.Add(new TextDocument
            {
                Title = archiveView.GetDocumentTitleText.text,
                Text = archiveView.GetDocumentContentText.text
            });

            UpdateFoldersCount();

            OnPageOpen?.Invoke(archiveView.GetHomePage);
            OnDocumentAdd?.Invoke();
        }

        public void AddListDocument()
        {
            var elements = listItems.Select(item => item.GetInputFieldText()).ToList();

            archiveModel.Documents.Add(new ListDocument
            {
                Title = archiveView.GetListTitleText.text,
                Elements = elements
            });

            UpdateFoldersCount();

            OnPageOpen?.Invoke(archiveView.GetHomePage);
            OnDocumentAdd?.Invoke();
        }

        public void AddListItem()
        {
            var item = Object.Instantiate(listItem, archiveView.GetListScrollBar);
            listItems.Add(item.GetComponent<ListItem>());
        }

        public void RemoveListItem()
        {
            if (listItems.Count > 0)
            {
                Object.Destroy(listItems[^1].gameObject);
                listItems.RemoveAt(listItems.Count - 1);
            }
        }
    }
}