using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    public GameObject token;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;

    public void OnMouseDown(){

        if(spriteRenderer.sprite == back){
            spriteRenderer.sprite = faces[faceIndex];
        }
        else{
            spriteRenderer.sprite = back;
        }
        
    }

    public void Awake(){
        spriteRenderer = token.GetComponent<SpriteRenderer>();
    }
}
