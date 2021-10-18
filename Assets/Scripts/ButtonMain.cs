using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMain : MonoBehaviour
{
    public GameObject theText;
    public AudioSource ringSound;
    public GameObject thePanel;

    public void Pressed()
    {
        //theText.GetComponent<Canvas>.text = "Mudei";
        theText.GetComponent<Text>().text = "Novo";
        ringSound.Play();
    }

    public void CancelButton()
    {
        thePanel.SetActive(false);
    }

    public void CloseButton()
    {
        thePanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
