using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RolesPage : MonoBehaviour
{
    UIDocument document;
    VisualElement rolesContainer;
    Button nextButton;

    void Start()
    {
        document = GetComponent<UIDocument>();
        rolesContainer = document.rootVisualElement.Q<VisualElement>("roles-container");
        nextButton = document.rootVisualElement.Q<Button>("next-button");

        List<RoleData> roles = GameManager.Instance.roles;

        for (int i = 0; i < roles.Count; i++) { 
            RoleData role = roles[i];
         
            RolesAvatar avatar = new RolesAvatar(roles[i].role);
            avatar.Counter.Value = role.count;
            avatar.Counter.OnChange += (int value) =>
            {
                role.count = value;
            };

            rolesContainer.Add(avatar);
        }


        nextButton.clicked += () =>
        {
            Debug.Log("Next Clicked");
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
