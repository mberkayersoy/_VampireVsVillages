using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class RolesAvatar : VisualElement
{
    public new class UxmlFactory : UxmlFactory<RolesAvatar> { }

    Roles role;
    public readonly CounterInput Counter;

    public RolesAvatar() {
        this.AddToClassList("avatar");
    }

    public RolesAvatar(Roles r)
    {
        role = r;
        
        VisualElement Image = new Image();
        Image.AddToClassList("avatar");

        // For Debug
        Label test = new Label();
        test.text = role.ToString();

        Counter = new CounterInput();

        this.Add(Image);
        this.Add(test);
        this.Add(Counter);
    }
}
