using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockWin : MonoBehaviour {
    //public bool BlockWinLocal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if (CollisionInfo.gameObject.tag == "BlockSwitch")
        {
            GameManager.Instance.Level1BlocksPlaced = (GameManager.Instance.Level1BlocksPlaced + 1);
            Debug.Log(GameManager.Instance.Level1BlocksPlaced);
           // BlockWinLocal = true;
        }
    }
}