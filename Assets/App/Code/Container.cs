using App.Code.MVVM;
using App.Code.MVVM.Models;
using App.Code.MVVM.View;
using App.Code.MVVM.ViewModels;
using UnityEngine;

namespace App.Code
{
    public class Container : MonoBehaviour
    {
        [SerializeField] private GameObject listItem;
        [Space]
        [SerializeField] private ArchiveView archiveView;

        private JsonHandler jsonHandler;
        private ArchiveModel archiveModel;
        private ArchiveViewModel archiveViewModel;
        
        private void Awake()
        {
            jsonHandler = new JsonHandler();
            archiveModel = jsonHandler.ArchiveInit();
            
            archiveViewModel = new ArchiveViewModel(archiveModel, archiveView, listItem);

            archiveView.Construct(archiveModel, archiveViewModel);
            
            archiveViewModel.UpdateFoldersCount();
        }

        private void OnDestroy()
        {
            jsonHandler.SaveToJson(archiveModel);
        }

        public void AddTextDocument() => archiveViewModel.AddTextDocument();

        public void AddListDocument() => archiveViewModel.AddListDocument();

        public void AddListItem() => archiveViewModel.AddListItem();

        public void RemoveListItem() => archiveViewModel.RemoveListItem();
    }
}