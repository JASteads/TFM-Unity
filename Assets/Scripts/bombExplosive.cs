using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplosive : MonoBehaviour {

    public GameObject bomb;
    public GameObject explosion;
    public LayerMask isPlayer;
    public bool detonatable = false;
    float startFuse;
    
	// Use this for initialization
	void Awake () {
        startFuse = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time - startFuse > 3)
        {
            detonatable = true;
        }
		if (Time.time - startFuse > 5)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyObject(bomb);
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (detonatable && isPlayer == (isPlayer | 1 << collision.gameObject.layer))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyObject(bomb);
        }
    }
}
