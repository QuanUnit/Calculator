using System;

namespace MVP.View
{
    public interface ICalculatorView
    {
        event Action<string> EquationFieldChanged;
        event Action ResultButtonClicked;
        event Action ErrorPopupCancelButtonClicked;
        event Action ErrorPopupOkButtonClicked;

        void ShowErrorMessage(string message);

        void HideErrorMessage();

        void SetEquation(string equation);
    }
}