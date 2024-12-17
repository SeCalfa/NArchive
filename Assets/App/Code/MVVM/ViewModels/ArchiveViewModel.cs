using Assets.App.Code.MVVM.Models;
using Assets.App.Code.MVVM.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Code.MVVM.ViewModels
{
    public class ArchiveViewModel : MonoBehaviour
    {
        [SerializeField]
        private GameObject listItem;

        public event Action<int> OnFoldersCountChanged;
        public event Action OnDocumentAdd;
        public event Action<GameObject> OnPageOpen;

        private ArchiveView archiveView;
        private ArchiveModel archiveModel;

        private List<ListItem> listItems = new List<ListItem>();

        public ArchiveModel GetArchiveModel => archiveModel;

        private void Awake()
        {
            archiveView = GetComponent<ArchiveView>();
            archiveModel = new ArchiveModel();

            OnPageOpen?.Invoke(archiveView.GetHomePage);
        }

        private void UpdateFoldersCount()
        {
            OnFoldersCountChanged.Invoke(archiveModel.Documents.Count);
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
            List<string> elements = new List<string>();

            foreach (var item in listItems)
            {
                elements.Add(item.GetInputFieldText());
            }

            archiveModel.Documents.Add(new ListDocument
            {
                Title = archiveView.GetListTitleText.text,
                Elements = elements
            });

            UpdateFoldersCount();

            OnPageOpen?.Invoke(archiveView.GetHomePage);
            OnDocumentAdd?.Invoke();
        }

        public void RemoveDocument()
        {
            if(archiveModel.Documents.Count == 0)
                return;

            archiveModel.Documents.RemoveAt(0);
            UpdateFoldersCount();
        }

        public void AddListItem()
        {
            GameObject item = Instantiate(listItem, archiveView.GetListScrollBar);
            listItems.Add(item.GetComponent<ListItem>());
        }

        public void RemoveListItem()
        {
            if (listItems.Count > 0)
            {
                Destroy(listItems[listItems.Count - 1].gameObject);
                listItems.RemoveAt(listItems.Count - 1);
            }
        }
    }
}