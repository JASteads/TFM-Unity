using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleScript : MonoBehaviour {

    public LayerMask charMask;
    public int cheeseNum;
    public int cheeseFound;
    bool loaded = false;
    Scene currentLevel;
    public int totalScenes;
    public int levelNum;

    public void Start()
    {
        currentLevel = SceneManager.GetActiveScene();
        levelNum = currentLevel.buildIndex;
        totalScenes = SceneManager.sceneCountInBuildSettings;
        cheeseNum = FindObjectsOfType(typeof(CheeseGrab)).Length;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (charMask == (charMask | 1 << collision.gameObject.layer))
        {
            MouseControlScript enter = collision.gameObject.GetComponent<MouseControlScript>();
            if (enter.hasCheese)
            {
                cheeseFound++;
                enter.hasCheese = false;
                if (cheeseFound == cheeseNum)
                {
                    levelNum++;

                    if (levelNum == totalScenes && !loaded)
                    {
                        levelNum = 2;
                        SceneManager.LoadSceneAsync(levelNum, LoadSceneMode.Additive);
                        SceneManager.UnloadSceneAsync(totalScenes);
                        loaded = true;
                        Debug.unityLogger.Log("Unloaded: " + totalScenes);
                        Debug.unityLogger.Log("Now Playing: " + levelNum);
                    }
                    else
                    {
                        if (!loaded)
                        {
                            SceneManager.LoadSceneAsync(levelNum, LoadSceneMode.Additive);
                            loaded = true;
                            SceneManager.UnloadSceneAsync(levelNum - 1);
                            Debug.unityLogger.Log("Unloaded: " + (levelNum - 1));
                            Debug.unityLogger.Log("Now Playing: " + levelNum);
                        }
                        
                    }
                    
                }
            }
            
        }
    }
}
