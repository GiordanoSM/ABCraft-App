using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenBehaviour : MonoBehaviour
{
    public GameObject token;
    public GameObject endPopup;
    public GameObject endClick;
    public GameObject gameBehaviour;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;

    public AudioSource endSound;
    public AudioSource rightSound;
    public AudioSource wrongSound;

    GameObject turned_token;

    public void OnMouseDown(){

        if (!gameBehaviour.GetComponent<GameBehaviour>().matching){
            if(spriteRenderer.sprite == back){
                spriteRenderer.sprite = faces[faceIndex];

                if (gameBehaviour.GetComponent<GameBehaviour>().turnedToken == ""){
                    gameBehaviour.GetComponent<GameBehaviour>().turnedToken = token.name;
                }
                else {
                    turned_token = GameObject.Find(gameBehaviour.GetComponent<GameBehaviour>().turnedToken);
                    if(spriteRenderer.sprite != turned_token.GetComponent<SpriteRenderer>().sprite){
                        gameBehaviour.GetComponent<GameBehaviour>().matching = true;
                        StartCoroutine(Unturn(turned_token));
                    }
                    else{
                        rightSound.Play();
                        gameBehaviour.GetComponent<GameBehaviour>().turnedToken = "";
                        gameBehaviour.GetComponent<GameBehaviour>().n_turned += 2;
                    }              
                }
            }
            if (gameBehaviour.GetComponent<GameBehaviour>().n_turned == gameBehaviour.GetComponent<GameBehaviour>().n_tokens){
                endPopup.SetActive(true);
                endClick.SetActive(true);
                endSound.Play();
            }
        }

    }

    IEnumerator Unturn(GameObject turned_token){
        wrongSound.Play();
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = back;
        turned_token.GetComponent<SpriteRenderer>().sprite = back;
        gameBehaviour.GetComponent<GameBehaviour>().turnedToken = "";
        gameBehaviour.GetComponent<GameBehaviour>().matching = false;
    }

    public void Awake(){
        spriteRenderer = token.GetComponent<SpriteRenderer>();
    }
}
