using Assets.App.Code.MVVM.ViewModels;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Assets.App.Code.MVVM.View
{
    public class ArchiveView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button foldersButton;
        [SerializeField] private Button textDocumentButton;
        [SerializeField] private Button listDoumentButton;
        [SerializeField] private Button[] backButtons;

        [Header("Pages")]
        [SerializeField] private GameObject homePage;
        [SerializeField] private GameObject textDocumentPage;
        [SerializeField] private GameObject listPage;

        [Header("Home Page")]
        [SerializeField] private TextMeshProUGUI foldersCountText;

        [Header("Text Document Page")]
        [SerializeField] private TMP_InputField documentTitleText;
        [SerializeField] private TMP_InputField documentContentText;

        [Space]
        [SerializeField] private ArchiveViewModel viewModel;

        public GameObject GetHomePage => homePage;

        public TMP_InputField GetDocumentTitleText => documentTitleText;
        public TMP_InputField GetDocumentContentText => documentContentText;

        private void Awake()
        {
            viewModel.OnFoldersCountChanged += UpdateFoldersCount;
            viewModel.OnDocumentAdd += ClearAllInputFields;
            viewModel.OnPageOpen += OpenPage;

            textDocumentButton.onClick.AddListener(delegate
            {
                OpenPage(textDocumentPage);
            });

            foreach(var backButton in backButtons)
            {
                backButton.onClick.AddListener(delegate
                {
                    OpenPage(homePage);
                });
            }
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
            listPage.SetActive(false);

            page.SetActive(true);
        }
    }
}