using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CounterInput : VisualElement
{
    public new class UxmlFactory : UxmlFactory<CounterInput> { }

    // Components
    private Label valueLabel;
    private Button decreaseButton;
    private Button increaseButton;


    // Data
    public int _value = 0;
    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            valueLabel.text = value.ToString();
        }
    }

    // Events
    public delegate void OnChangeEvent(int value);
    public event OnChangeEvent OnChange;

    public CounterInput()
    {
        this.AddToClassList("counter-input");

        decreaseButton = new Button(Decrease);
        decreaseButton.text = "-";

        valueLabel = new Label(_value.ToString());

        increaseButton = new Button(Increase);
        increaseButton.text = "+";

        this.Add(decreaseButton);
        this.Add(valueLabel);
        this.Add(increaseButton);
    }

    public void Increase()
    {
        Value++;
        if (OnChange != null) OnChange.Invoke(Value);
    }

    public void Decrease()
    {
        Value--;
        if (OnChange != null) OnChange.Invoke(Value);
    }
}
