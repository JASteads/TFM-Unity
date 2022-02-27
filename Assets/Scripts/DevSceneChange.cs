using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DevSceneChange : MonoBehaviour
{
    
    MouseControlScript mouse;
    Scene currentLevel;
    int totalScenes;
    int levelNum;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene();
        levelNum = currentLevel.buildIndex;
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }
    void Awake()
    {

        //Make sure there are copies are not made of the GameObject when it isn't destroyed
        if (FindObjectsOfType(GetType()).Length > 1)
            //Destroy any copies
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetButtonDown("Dev: Restart"))
        {
            SceneManager.LoadScene(sceneBuildIndex: levelNum);
        }
        if (Input.GetButtonDown("Dev: Map Change"))
        {
            levelNum++;
            if (levelNum == totalScenes)
            {
                SceneManager.LoadScene(sceneBuildIndex: 2);
                levelNum = 2;
                Debug.unityLogger.Log("Now Playing: " + currentLevel.name);
            }
            else
            {
                SceneManager.LoadScene(levelNum);
                Debug.unityLogger.Log("Now Playing: " + currentLevel.name);
            }
        }
    }
}
