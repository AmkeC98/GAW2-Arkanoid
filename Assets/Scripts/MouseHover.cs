using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    private Text buttonText;

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        buttonText.color = Color.green;
    }

    public void ChangeColorEnter()
    {
        buttonText.color = Color.white;
    }

    public void ChangeColorExit()
    {
        buttonText.color = Color.green;
    }
}
