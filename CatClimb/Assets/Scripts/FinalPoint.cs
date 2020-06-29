using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPoint : MonoBehaviour
{
    public GameObject fianlpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = Gamedirector.finalpoint.ToString("F0") + "point";
    }
}
