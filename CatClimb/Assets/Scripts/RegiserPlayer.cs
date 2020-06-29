using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegiserPlayer : MonoBehaviour
{
    public InputField displayNameInput, userNameInput, passwordInput;

    // 회원가입
    public void RegisterPlayerBttn()
    {
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayNameInput.text) // DisplayName 이 닉네임일듯
            .SetPassword(passwordInput.text) // 비밀번호
            .SetUserName(userNameInput.text) // 계정아이디
            .Send((response) => {
                if (!response.HasErrors)
                {
                    Debug.Log("회원가입 완료");
                }
                else
                {

                    Debug.Log("회원가입 실패" + response.Errors.JSON.ToString());
                }
            }
        );
    }
}

