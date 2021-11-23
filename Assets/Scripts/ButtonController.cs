using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Button[] buttons;
    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    public void TrafficLightInteraction()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].interactable == true)
            {
                buttons[i].interactable = false;
                buttons[i --].interactable = true;
            }
            
        }

    }
}
