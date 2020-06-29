using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class AuthenticatePlayer : MonoBehaviour
{
    public InputField userNameInput, passwordInput;
    // Start is called before the first frame update
    public void AuthorizePlayerBttn()
    {
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(userNameInput.text)
            .SetPassword(passwordInput.text)
            .Send((response) => {
                if (!response.HasErrors)
                {
                    Debug.Log("로그인 성공...");
                    SceneManager.LoadScene("GameScene");
                }
                else
                {
                    Debug.Log("로그인 실패..." + response.Errors.JSON.ToString());
                }
            });
    }
    
}
