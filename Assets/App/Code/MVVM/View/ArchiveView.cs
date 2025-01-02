using System.Collections.Generic;
using App.Code.MVVM.Models;
using App.Code.MVVM.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Code.MVVM.View
{
    public class ArchiveView : MonoBehaviour
    {
        [SerializeField]
        private GameObject documentItem;

        [Header("Buttons")]
        [SerializeField] private Button foldersButton;
        [SerializeField] private Button textDocumentButton;
        [SerializeField] private Button listDocumentButton;
        [SerializeField] private Button[] backButtons;

        [Header("Pages")]
        [SerializeField] private GameObject homePage;
        [SerializeField] private GameObject textDocumentPage;
        [SerializeField] private GameObject listDocumentPage;
        [SerializeField] private GameObject foldersPage;

        [Header("Home Page")]
        [SerializeField] private TextMeshProUGUI foldersCountText;

        [Header("Text Document Page")]
        [SerializeField] private TMP_InputField documentTitleText;
        [SerializeField] private TMP_InputField documentContentText;

        [Header("List Document Page")]
        [SerializeField] private TMP_InputField listTitleText;
        [SerializeField] private Transform listScrollBar;

        [Header("Folders Page")]
        [SerializeField] private Transform foldersScrollBar;

        private List<GameObject> docItems = new();

        public GameObject GetHomePage => homePage;

        public TMP_InputField GetDocumentTitleText => documentTitleText;
        public TMP_InputField GetDocumentContentText => documentContentText;

        public TMP_InputField GetListTitleText => listTitleText;

        public Transform GetListScrollBar => listScrollBar;

        private ArchiveModel archiveModel;
        private ArchiveViewModel archiveViewModel;

        public void Construct(ArchiveModel archiveModel, ArchiveViewModel archiveViewModel)
        {
            this.archiveModel = archiveModel;
            this.archiveViewModel = archiveViewModel;
            
            this.archiveViewModel.OnFoldersCountChanged += UpdateFoldersCount;
            this.archiveViewModel.OnDocumentAdd += ClearAllInputFields;
            this.archiveViewModel.OnPageOpen += OpenPage;

            foldersButton.onClick.AddListener(delegate
            {
                OpenPage(foldersPage);
                InitAllDocuments();
            });

            textDocumentButton.onClick.AddListener(delegate
            {
                OpenPage(textDocumentPage);
            });

            listDocumentButton.onClick.AddListener(delegate
            {
                OpenPage(listDocumentPage);
            });

            foreach (var backButton in backButtons)
            {
                backButton.onClick.AddListener(delegate
                {
                    OpenPage(homePage);
                });
            }

            OpenPage(homePage);
        }

        private void UpdateFoldersCount(int count)
        {
            foldersCountText.text = count.ToString();
        }

        private void ClearAllInputFields()
        {
            documentTitleText.text = string.Empty;
            documentContentText.text = string.Empty;
        }

        private void OpenPage(GameObject page)
        {
            homePage.SetActive(false);
            textDocumentPage.SetActive(false);
            listDocumentPage.SetActive(false);
            foldersPage.SetActive(false);

            page.SetActive(true);
        }

        private void InitAllDocuments()
        {
            RemoveAllDocuments();
            
            foreach (var doc in archiveModel.textDocuments)
            {
                var d = Instantiate(documentItem, foldersScrollBar);
                d.GetComponent<DocumentItem>().Init(doc);
                
                docItems.Add(d);
            }
            
            foreach (var doc in archiveModel.listDocuments)
            {
                var d = Instantiate(documentItem, foldersScrollBar);
                d.GetComponent<DocumentItem>().Init(doc);
                
                docItems.Add(d);
            }
        }

        private void RemoveAllDocuments()
        {
            foreach (var docItem in docItems)
            {
                Destroy(docItem);
            }
            
            docItems.Clear();
        }
    }
}