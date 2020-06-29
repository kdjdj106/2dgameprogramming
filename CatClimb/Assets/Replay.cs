using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{ // Start is called before the first frame update
   
   
    public void BackToGame()
    {
        Debug.Log("리트라이 감지");
        SceneManager.LoadScene("GameScene");
    }
}
