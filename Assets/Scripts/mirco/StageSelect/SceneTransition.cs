using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void OpenScene(String sceneName){
        SceneManager.LoadScene(sceneName);
    }
    
}
