using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorScript : MonoBehaviour
{
    public InputField inputField;
    private float Text;
    public float input1;
    public float input2;
    public float result;
    public string operations;
    void Start()
    {
        
        
    }
    public void ClickNumbers(int val)
    {
        Debug.Log($"val:{val}");
        inputField.text = $"{val}";
        input = val;
        if(input == 0)
        {
            input1 = val;        
        }
        else
        {
            input2 = val;
        }
    }
    public void ClickOperations(string val)
    {
        Debug.Log($"ClickOperations val:{val}");
        operations = val;
    }
    public void ClickEquals()
    {
        if (input1 != 0 && input2 != 0 && !string.IsNullOrEmty(operations))
        {
            switch (operations)
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
            inputField.SetText( result.ToString());
        }
    }

}
