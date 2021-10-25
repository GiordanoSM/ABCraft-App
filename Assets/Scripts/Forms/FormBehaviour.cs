using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBehaviour : MonoBehaviour
{
    public GameObject form;
    SpriteRenderer spriteRenderer;

    public Sprite[] forms;

    public AudioSource endSound;
    public AudioSource rightSound;
    public AudioSource wrongSound;


    public void Awake()
    {
        spriteRenderer = form.GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = forms[formIndex];
    }

    public void ChangeForm(int formIndex){
        spriteRenderer.sprite = forms[formIndex];
    }
}
