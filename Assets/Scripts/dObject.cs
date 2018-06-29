using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnPlatform.spawnPlatformCoin();

	}

    void OnCollisionEnter2D(Collision2D other)
    {
	    spawnPlatform.spawnPlatformCoin();
        Destroy(other.gameObject);
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		//Destroy(other.gameObject);
		//spawnPlatform.spawnPlatformCoin();

	}
}
