using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamedirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    public static float time = 600;
    public static int point = 0;
    GameObject FinalPoint;
    public static float finalpoint;

    public void GetBread()
    {
        point += 10;
    }
    // Start is called before the first frame update

    void Start()
    {
       
        this.pointText = GameObject.Find("Point");
        this.timerText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
       
        this.pointText.GetComponent<Text>().text = point.ToString() + "point";
        time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = time.ToString("F0");
        finalpoint = time + point;
        if (time <= 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
