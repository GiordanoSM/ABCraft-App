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

    public void ToGamesMenu(){
        theScene = SceneManager.GetActiveScene().buildIndex.ToString();
        PlayerPrefs.SetString("SceneBeforeGames", theScene);
        SceneManager.LoadScene(5);
    }

    public void BackFromGames(){
        theScene = PlayerPrefs.GetString("SceneBeforeGames");
        SceneManager.LoadScene(int.Parse(theScene));
    }

    public void ToMemoryGame(){
        SceneManager.LoadScene(6);
    }

    public void BackToGames(){
        SceneManager.LoadScene(5);
    }
}
