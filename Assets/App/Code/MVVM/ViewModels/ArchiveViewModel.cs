using Assets.App.Code.MVVM.Models;
using System;
using UnityEngine;

namespace Assets.App.Code.MVVM.ViewModels
{
    public class ArchiveViewModel : MonoBehaviour
    {
        public event Action<int> OnFoldersCountChanged;

        private ArchiveModel archiveModel;

        private void Awake()
        {
            archiveModel = new ArchiveModel();
        }

        private void UpdateFoldersCount()
        {
            OnFoldersCountChanged.Invoke(archiveModel.Folders.Count);
        }

        public void AddFolder()
        {
            archiveModel.Folders.Add(new Folder());

            UpdateFoldersCount();
        }

        public void RemoveFolder()
        {
            if(archiveModel.Folders.Count == 0)
                return;

            archiveModel.Folders.RemoveAt(0);
            UpdateFoldersCount();
        }
    }
}