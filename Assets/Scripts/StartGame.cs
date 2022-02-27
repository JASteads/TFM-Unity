using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public Transform gameManagerPrefab;

	public void ChangeToScene (string scene) {
        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        DontDestroyOnLoad(Instantiate(gameManagerPrefab));

    }

}
