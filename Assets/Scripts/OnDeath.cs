using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{

    public MouseControlScript mouse;
    public Scene scene;

    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        mouse = GetComponent<MouseControlScript>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (mouse.gameObject.transform.position.y <= -7 || mouse.gameObject.transform.position.y >= 35)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
