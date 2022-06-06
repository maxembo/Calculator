
using System;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI InputText;
    private float result;
    private float input1;
    private float input2;
    private string operation;
    private string currentInput;
    private bool equalIsPressed;

    public void ClickNumber(int number)
    {
        Debug.Log($"{number}");
        if (!string.IsNullOrEmpty(currentInput))
        {
            if (currentInput.Length < 10)
            {
                currentInput += number;
            }
        }
        else
        {
            currentInput = number.ToString();
        }
        InputText.text = $"{currentInput}";
    }

    public void ClickOperation(string operat)
    {
        Debug.Log($"{operat}");
        if (input1 == 0)
        {
            SetCurrentInput();
            operation = operat;
        }
        else
        {
            if (equalIsPressed)
            {
                equalIsPressed = false;
                operation = operat;
                input2 = 0;
            }
            else
            {
                if (operation.Equals(operat, StringComparison.OrdinalIgnoreCase))
                {
                    Calculate();
                }
                else
                {
                    operation = operat;
                    input2 = 0;
                }
            }
        }
    }

    public void ClickEqual(string equalsOper)
    {
        Debug.Log($"{equalsOper}");
        Calculate();
        equalIsPressed = true;
    }

    private void Calculate()
    {
        if (input1 != 0 && !string.IsNullOrEmpty(operation))
        {
            SetCurrentInput();
            switch (operation)
            {
                case "+":
                    result = input1 + input2;
                    break;
                case "-":
                    result = input1 - input2;
                    break;
                case "*":
                    result = input1 * input2;
                    break;
                case "/":
                    result = input1 / input2;
                    break;
            }
            InputText.SetText(result.ToString());
            input1 = result;
        }
    }

    private void SetCurrentInput()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            if (input1 == 0)
            {
                input1 = int.Parse(currentInput);
            }
            else
            {
                input2 = int.Parse(currentInput);
            }
            currentInput = "";
        }
    }

    public void ClearInput()
    {
        currentInput = "";
        input1 = 0;
        input2 = 0;
        result = 0;
        InputText.SetText("0");
    }
    public void ClickCompression()
    {

    }
}
