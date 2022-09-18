using System;
using UnityEngine;

namespace MVP.Model
{
    public class CalculatorModel : ICalculatorModel
    {
        public event Action<string> CalculationErrorThrowed;

        public string Equation
        {
            get => PlayerPrefs.GetString(EquationSave, string.Empty);
            set => PlayerPrefs.SetString(EquationSave, value);
        }

        private readonly string EquationSave = nameof(EquationSave);
        private readonly string ErrorMessage = @"Our programmers are already dealing with the problem, the manager at this time beats them with a whip, while the director is tearing his hair out.";

        public string CalculateEquation()
        {
            int a;
            int b;

            bool parseResult = TryParseEquation(out a, out b, Equation);

            if(parseResult == false || b == 0)
            {
                CalculationErrorThrowed?.Invoke(ErrorMessage);
                return string.Empty;
            }

            return ((float)a / b).ToString();
        }

        private bool TryParseEquation(out int a, out int b, string equation)
        {
            a = default;
            b = default;

            string[] words = equation.Split('/');

            if (words.Length != 2) return false;

            if(int.TryParse(words[0], out a) == false) return false;
            if(int.TryParse(words[1], out b) == false) return false;

            return true;
        }
    }
}