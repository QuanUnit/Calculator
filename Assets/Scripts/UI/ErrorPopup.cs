using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class ErrorPopup : Popup
    {
        public event Action OkButtonClicked;
        public event Action CancelButtonClicked;

        [SerializeField] private TMP_Text _errorMessage;
        [SerializeField] private Button _okButton;
        [SerializeField] private Button _cancelButton;

        public void SetErrorMessage(string message)
        {
            _errorMessage.text = message;
        }

        private void HandleOkButtonClick() => OkButtonClicked?.Invoke();

        private void HandleCancelButtonClick() => CancelButtonClicked?.Invoke();

        private void OnEnable()
        {
            _okButton.onClick.AddListener(HandleOkButtonClick);
            _cancelButton.onClick.AddListener(HandleCancelButtonClick);
        }

        private void OnDisable()
        {
            _okButton.onClick.RemoveListener(HandleOkButtonClick);
            _cancelButton.onClick.RemoveListener(HandleCancelButtonClick);
        }
    }
}