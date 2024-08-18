using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectHandler : MonoBehaviour
{
    public void OpenScene(String sceneName){
        SceneManager.LoadScene(sceneName);
    }
    
}
