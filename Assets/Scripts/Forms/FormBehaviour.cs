using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBehaviour : MonoBehaviour
{
    public GameObject form;
    SpriteRenderer spriteRenderer;
    public GameObject gameBehaviour;
    public GameObject endPopup;
    public GameObject endClick;
    public Sprite[] forms;

    public AudioSource endSound;
    public AudioSource rightSound;
    public AudioSource wrongSound;

    public bool locked = true;

    Vector2 mousePosition;
    Transform t_hole;

    public Vector2 initialPos;

    float deltaX;
    float deltaY;

    int id;

    public void Awake()
    {
        spriteRenderer = form.GetComponent<SpriteRenderer>();
    }

    public void ChangeForm(int formIndex){
        spriteRenderer.sprite = forms[formIndex];
        this.id = formIndex;
    }

    private void OnMouseDrag(){
        if (!locked){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

    private void OnMouseUp(){
        if (!locked){
            t_hole = GameObject.Find("Hole" + id%4).GetComponent<Transform>();
            if(Mathf.Abs(transform.position.x - t_hole.position.x) < 0.5f &&
               Mathf.Abs(transform.position.y - t_hole.position.y) < 0.5f)
            {
                transform.position = t_hole.position;
                t_hole.localScale = new Vector3(
                    t_hole.localScale.x + 0.02f, t_hole.localScale.y + 0.02f, 0
                );
                locked = true;
                gameBehaviour.GetComponent<FormsGameBehaviour>().n_done += 1;
                rightSound.Play();
                if (gameBehaviour.GetComponent<FormsGameBehaviour>().n_done >= 4){
                    endPopup.SetActive(true);
                    endClick.SetActive(true);
                    endSound.Play();
                }
            }
            else{
                wrongSound.Play();
                transform.position = initialPos;
            }
        }
    }
}
