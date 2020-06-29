using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadController : MonoBehaviour
{
    public GameObject BreadPrefab;
    int ratio = 5;
    // Start is called before the first frame update
    void Start()
    {
        int dice = Random.Range(1, 11);
        if (dice <= this.ratio)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
