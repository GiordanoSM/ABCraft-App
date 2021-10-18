using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void ToStudentsLogin(){
        SceneManager.LoadScene(2);
    }

    public void ToStudentsMenu(){
        SceneManager.LoadScene(3);
    }

    public string theScene;
    public void ToExitMenu(){
        theScene = SceneManager.GetActiveScene().buildIndex.ToString();
        PlayerPrefs.SetString("LastScene", theScene);
        SceneManager.LoadScene(4);
    }

    public void Exit(){
        Application.Quit();
    }

    public void CancelExit(){
        theScene = PlayerPrefs.GetString("LastScene");
        SceneManager.LoadScene(int.Parse(theScene));
    }
}
