using MVP.Presenter;
using System;
using TMPro;
using UI.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        public event Action<string> EquationFieldChanged;
        public event Action ResultButtonClicked;
        public event Action ErrorPopupCancelButtonClicked;
        public event Action ErrorPopupOkButtonClicked;

        [SerializeField] private ErrorPopup _errorPopup;
        [SerializeField] private TMP_InputField _equationField;
        [SerializeField] private Button _resultButton;

        public void SetEquation(string equation) => _equationField.text = equation;

        public void ShowErrorMessage(string message)
        {
            _errorPopup.SetErrorMessage(message);
            _errorPopup.Show();
        }

        public void HideErrorMessage()
        {
            _errorPopup.SetErrorMessage(string.Empty);
            _errorPopup.Hide();
        }

        private void OnEnable()
        {
            _errorPopup.OkButtonClicked += HandleErrorPopupOkButtonClick;
            _errorPopup.CancelButtonClicked += HandleErrorPopupCancelButtonClick;

            _equationField.onValueChanged.AddListener(HandleEquationFieldChange);
            _resultButton.onClick.AddListener(HandleResultButtonClick);
        }

        private void OnDisable()
        {
            _errorPopup.OkButtonClicked -= HandleErrorPopupOkButtonClick;
            _errorPopup.CancelButtonClicked -= HandleErrorPopupCancelButtonClick;

            _equationField.onValueChanged.RemoveListener(HandleEquationFieldChange);
            _resultButton.onClick.RemoveListener(HandleResultButtonClick);
        }

        private void Start()
        {
            new CalculatorPresenter(this);
        }

        private void HandleErrorPopupOkButtonClick() => ErrorPopupOkButtonClicked?.Invoke();

        private void HandleErrorPopupCancelButtonClick() => ErrorPopupCancelButtonClicked?.Invoke();

        private void HandleEquationFieldChange(string newValue) => EquationFieldChanged?.Invoke(newValue);

        private void HandleResultButtonClick() => ResultButtonClicked?.Invoke();
    }
}