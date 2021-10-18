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
}
