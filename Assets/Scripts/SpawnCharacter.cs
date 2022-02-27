using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour {

    public Transform spawnObj;
    public bool playerSpawned = false;

	// Use this for initialization
	void Start () {
        Transform spawnTrans = Instantiate(spawnObj);
        spawnTrans.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
