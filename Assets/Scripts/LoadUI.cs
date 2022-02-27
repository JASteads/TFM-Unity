using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUI : MonoBehaviour {

    GameData data;
    Transform gameStage;
    Transform gameScore;

	void Start () {

        data = GameObject.Find("GameManager").GetComponent<GameData>();
        
	}
	
	void Update () {
		
        

	}
}
