using Assets.App.Code.MVVM.ViewModels;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private ArchiveViewModel archiveViewModel;

    public void AddTextDocument()
    {
        archiveViewModel.AddTextDocument();
    }
}
