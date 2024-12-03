using Assets.App.Code.MVVM.ViewModels;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private ArchiveViewModel archiveViewModel;

    public void Add()
    {
        archiveViewModel.AddFolder();
    }

    public void Remove()
    {
        archiveViewModel.RemoveFolder();
    }
}
