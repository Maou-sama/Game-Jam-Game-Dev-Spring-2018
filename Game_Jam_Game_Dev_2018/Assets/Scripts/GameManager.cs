﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            //Checks to see if manager exists and creates an instance if it doesn't exist
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }

    }

    //Uses Accessors to help implement global accessibility for important variables that must be acccessed accross multiple objects/scripts
    public int Score { get; set; }
    public float pXSpeed { get; set; }
    public bool PlayerSpotted { get; set; }
    public int pHealth { get; set; }

    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
    }
}

