using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{

    public TMP_Text InputField;

    float CurrentNumber = 0;
    float LastNumber = 0;

    string operation = null;

    bool IsWhole = true;
    void Start()
    {
        Screen.SetResolution(300, 500, true, 60);
    }

    void Update()
    {
        InputField.text = CurrentNumber.ToString();
    }

    public void ClickOnNumber(int number)
    {
        if(IsWhole)
            CurrentNumber = float.Parse(CurrentNumber.ToString() + number.ToString());
        else
            CurrentNumber = float.Parse(CurrentNumber.ToString() + "," + number.ToString());
        IsWhole = true;
    }

    public void ClickOnSign(string sign)
    {
        switch (sign)
        {
            case "%":
                CurrentNumber /= 100;
                break;

            case "C":
                CurrentNumber = 0;
                LastNumber = 0;
                sign = null;
                operation = null;
                break;

            case "CE":
                CurrentNumber = 0;
                break;

            case "Sqrt":
                CurrentNumber = Mathf.Sqrt(CurrentNumber);
                break;

            case ".":
                if(CurrentNumber % 2 ==0)
                    IsWhole = false;
                break;

            case "+/-":
                CurrentNumber *= -1;
                break;

            case "1/x":
                CurrentNumber = 1 / CurrentNumber;
                break;

            case "DEL":
                string s = CurrentNumber.ToString();
                if(s.Length == 2 && s[0] == '-')
                    CurrentNumber = 0;
                else if (s.Length > 1)
                    CurrentNumber = float.Parse(s.Remove(s.Length - 1));
                else
                    CurrentNumber = 0;
                break;

            case "x^2":
                CurrentNumber *= CurrentNumber;
                break;
        }
        
    }

    public void ClickOnOperation(string operation)
    {
        this.operation = operation;
        LastNumber = CurrentNumber;
        CurrentNumber = 0;
        IsWhole = true;
    }

    public void ClickOnEqual()
    {

        switch (operation)
        {
            case "+":
                CurrentNumber = LastNumber + CurrentNumber;
                break;

            case "-":
                CurrentNumber = LastNumber - CurrentNumber;
                break;

            case "/":
                CurrentNumber = LastNumber / CurrentNumber;
                break;

            case "*":
                CurrentNumber = LastNumber * CurrentNumber;
                break;
        }
        operation = null;
    }
}
