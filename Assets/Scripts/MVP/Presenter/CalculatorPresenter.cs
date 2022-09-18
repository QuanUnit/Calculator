using MVP.Model;
using MVP.View;
using UnityEngine;

namespace MVP.Presenter
{
    public class CalculatorPresenter
    {
        private ICalculatorView _view;
        private ICalculatorModel _model;

        public CalculatorPresenter(ICalculatorView view)
        {
            _view = view;
            _model = new CalculatorModel();

            Subscribe();
            Init();
        }

        private void Init() => _view.SetEquation(_model.Equation);

        private void Subscribe()
        {
            _view.ResultButtonClicked += View_ResultButtonClicked;
            _view.ErrorPopupCancelButtonClicked += View_ErrorPoup_CancelButtonClicked;
            _view.ErrorPopupOkButtonClicked += View_ErrorPoup_OkButtonClicked;
            _view.EquationFieldChanged += View_EquationFieldChanged;

            _model.CalculationErrorThrowed += Model_CalculationErrorThrowed;
        }

        private void Unsubscribe()
        {
            _view.ResultButtonClicked -= View_ResultButtonClicked;
            _view.ErrorPopupCancelButtonClicked -= View_ErrorPoup_CancelButtonClicked;
            _view.ErrorPopupOkButtonClicked -= View_ErrorPoup_OkButtonClicked;
            _view.EquationFieldChanged -= View_EquationFieldChanged;
        }

        private void View_ResultButtonClicked()
        {
            string result = _model.CalculateEquation();
            _view.SetEquation(result);
        }

        private void View_ErrorPoup_CancelButtonClicked()
        {
            Unsubscribe();
            Application.Quit();
        }

        private void View_ErrorPoup_OkButtonClicked() => _view.HideErrorMessage();

        private void View_EquationFieldChanged(string equation) => _model.Equation = equation;

        private void Model_CalculationErrorThrowed(string errorMessage) => _view.ShowErrorMessage(errorMessage);
    }
}