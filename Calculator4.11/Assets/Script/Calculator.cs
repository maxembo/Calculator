
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
    private string compression;

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
            compression = operat;
        }
        else
        {
            if (equalIsPressed)
            {
                equalIsPressed = false;
                operation = operat;
                compression = operat;
                input2 = 0;
            }
            else
            {
                if (operation.Equals(operat, StringComparison.OrdinalIgnoreCase))
                {
                    Calculate();
                    
                }
                if (compression.Equals(operat, StringComparison.OrdinalIgnoreCase))
                {
                    ClickCompression();
                }
                else
                {
                    operation = operat;
                    compression = operat;
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

    public void ClickEqualComp(string equalsComp)
    {
        Debug.Log($"{equalsComp}");
        ClickCompression();
        equalIsPressed = true;
    }

    public void ClickCompression()
    {
        if (!string.IsNullOrEmpty(operation))
        {
            SetCurrentInput();
            if (input1 != input2)
            {
                if (input1 > input2)
                {
                    result = input1;
                    InputText.SetText($"{result} > {input2}");
                }
                else
                {
                    result = input2;
                    InputText.SetText($"{input1} < {result}");
                }
            }
            else
                InputText.SetText($"{input1} = {input2}");
        }
    }
}