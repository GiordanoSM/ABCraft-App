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

    public bool locked = true;

    Vector2 mousePosition;

    float deltaX;
    float deltaY;

    public void Awake()
    {
        spriteRenderer = form.GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = forms[formIndex];
    }

    public void ChangeForm(int formIndex){
        spriteRenderer.sprite = forms[formIndex];
    }

    public void OnMouseDrag(){
        if (!locked){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }
}
