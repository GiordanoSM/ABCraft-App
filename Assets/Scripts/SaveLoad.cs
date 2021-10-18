using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public string theText;
    public GameObject ourNote;
    public GameObject placeHolder;
    public GameObject saveAnim;

    // Start is called before the first frame update
    void Start()
    {
        theText = PlayerPrefs.GetString("TextContent");
        //theText = "Usei o load";
        placeHolder.GetComponent<Text>().text = theText;
    }

    public void SaveText(){
        theText = ourNote.GetComponent<Text>().text;
        PlayerPrefs.SetString("TextContent", theText);
        StartCoroutine(SaveTextRoll());
    }

    IEnumerator SaveTextRoll(){
        saveAnim.GetComponent<Animator>().Play("SaveText");
        yield return new WaitForSeconds(1);
        saveAnim.GetComponent<Animator>().Play("New State");

    }
}
