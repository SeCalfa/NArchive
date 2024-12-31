using Assets.App.Code.MVVM.Models;
using Assets.App.Code.MVVM.View;
using Assets.App.Code.MVVM.ViewModels;
using UnityEngine;

namespace App.Code
{
    public class Container : MonoBehaviour
    {
        [SerializeField] private GameObject listItem;
        [Space]
        [SerializeField] private ArchiveView archiveView;

        private ArchiveModel archiveModel;
        private ArchiveViewModel archiveViewModel;
        
        private void Awake()
        {
            archiveModel = new ArchiveModel();
            archiveViewModel = new ArchiveViewModel(archiveModel, archiveView, listItem);
            
            archiveView.Construct(archiveModel, archiveViewModel);
        }

        public void AddTextDocument() => archiveViewModel.AddTextDocument();

        public void AddListDocument() => archiveViewModel.AddListDocument();

        public void AddListItem() => archiveViewModel.AddListItem();

        public void RemoveListItem() => archiveViewModel.RemoveListItem();
    }
}