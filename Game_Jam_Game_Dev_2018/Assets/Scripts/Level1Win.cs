﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Win : MonoBehaviour {
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.Level1BlocksPlaced > 1)
        {
            StartCoroutine(SceneTransition());
        }
	}

    private IEnumerator SceneTransition()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
