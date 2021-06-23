using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
