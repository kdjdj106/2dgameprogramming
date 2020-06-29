using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject.Find("cat").GetComponent<PlayerController>().StartCoroutine("BombSound");
        }
    }
}
