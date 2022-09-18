using System;

namespace MVP.Model
{
    public interface ICalculatorModel
    {
        event Action<string> CalculationErrorThrowed;

        string Equation { get; set; }
        
        string CalculateEquation();
    }
}