using Assets.App.Code.MVVM.ViewModels;
using UnityEngine;
using TMPro;

namespace Assets.App.Code.MVVM.View
{
    public class ArchiveView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI foldersCountText;
        [SerializeField]
        private ArchiveViewModel viewModel;

        private void Awake()
        {
            viewModel.OnFoldersCountChanged += UpdateFoldersCount;
        }

        private void UpdateFoldersCount(int count)
        {
            foldersCountText.text = count.ToString();
        }
    }
}