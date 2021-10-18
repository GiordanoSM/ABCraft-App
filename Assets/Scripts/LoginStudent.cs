using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginStudent : MonoBehaviour
{
    public GameObject theEmail;
    public GameObject thePassword;
    // Start is called before the first frame update
    void Start()
    {
        theEmail.GetComponent<InputField>().text = "aluno@gmail.com";
        thePassword.GetComponent<InputField>().text = "*******";
    }
}
