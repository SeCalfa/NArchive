using Assets.App.Code.MVVM.Models;
using Assets.App.Code.MVVM.View;
using System;
using UnityEngine;

namespace Assets.App.Code.MVVM.ViewModels
{
    public class ArchiveViewModel : MonoBehaviour
    {
        public event Action<int> OnFoldersCountChanged;
        public event Action OnDocumentAdd;
        public event Action<GameObject> OnPageOpen;

        private ArchiveView archiveView;
        private ArchiveModel archiveModel;

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

        public void RemoveDocument()
        {
            if(archiveModel.Documents.Count == 0)
                return;

            archiveModel.Documents.RemoveAt(0);
            UpdateFoldersCount();
        }
    }
}