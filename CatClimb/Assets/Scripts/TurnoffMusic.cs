using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TurnoffMusic : MonoBehaviour, IPointerClickHandler
{
    int volume =1;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("클릭감지");
            TurnOn_Off_Music();
        }
    }

    public void TurnOn_Off_Music()
    {
       this.volume = this.volume * -1;
            if (this.volume == -1)
            {
                GetComponent<AudioSource>().Pause();
                GameObject.Find("cat").GetComponent<PlayerController>().Turn_Off_Music();
            }
            else
            {
                GetComponent<AudioSource>().Play();
                GameObject.Find("cat").GetComponent<PlayerController>().Turn_On_Music();
            }
        
    }
    // Start is called before the first frame update
    
}
