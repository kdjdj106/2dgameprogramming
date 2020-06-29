﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSparksManager : MonoBehaviour
{
    private static GameSparksManager instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
