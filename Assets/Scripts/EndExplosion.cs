using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExplosion : MonoBehaviour {

    public GameObject explosion;
    float startFuse;

    // Use this for initialization
    void Awake()
    {
        startFuse = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - startFuse > 0.5f)
        {

            DestroyObject(explosion);
        }
    }

}
