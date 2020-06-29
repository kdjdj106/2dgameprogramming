using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLogin : MonoBehaviour
{
    public void ClickGotoLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
