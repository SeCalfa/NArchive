using System;
using System.Collections.Generic;
using System.Linq;
using App.Code.MVVM.Models;
using App.Code.MVVM.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Code.MVVM.ViewModels
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

        public void UpdateFoldersCount()
        {
            OnFoldersCountChanged?.Invoke(archiveModel.textDocuments.Count + archiveModel.listDocuments.Count);
        }

        public void AddTextDocument()
        {
            archiveModel.textDocuments.Add(new TextDocument
            {
                title = archiveView.GetDocumentTitleText.text,
                text = archiveView.GetDocumentContentText.text
            });

            UpdateFoldersCount();

            OnPageOpen?.Invoke(archiveView.GetHomePage);
            OnDocumentAdd?.Invoke();
        }

        public void AddListDocument()
        {
            var elements = listItems.Select(item => item.GetInputFieldText()).ToList();
            Debug.Log(elements.Count);

            archiveModel.listDocuments.Add(new ListDocument
            {
                title = archiveView.GetListTitleText.text,
                elements = elements
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