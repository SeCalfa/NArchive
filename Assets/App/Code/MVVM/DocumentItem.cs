using App.Code.MVVM.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Code.MVVM
{
    public class DocumentItem : MonoBehaviour
    {
        [SerializeField] private Sprite textLogo;
        [SerializeField] private Sprite checklistLogo;
        [SerializeField] private Color32 textColor;
        [SerializeField] private Color32 checklistColor;

        [Space]
        [SerializeField] private Image logo;
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI title;

        private Document activeDocument;

        public void Init(Document document)
        {
            activeDocument = document;

            if(activeDocument is TextDocument)
            {
                logo.sprite = textLogo;
                background.color = textColor;
            }
            else if (activeDocument is ListDocument)
            {
                logo.sprite = checklistLogo;
                background.color = checklistColor;
            }

            title.text = activeDocument.title;
        }
    }
}