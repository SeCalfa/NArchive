using UnityEngine;
using TMPro;

namespace Assets.App.Code.MVVM
{
    public class ListItem : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public string GetInputFieldText()
        {
            return inputField.text;
        }
    }
}