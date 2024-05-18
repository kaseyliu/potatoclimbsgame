using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void playIntro(){
        SceneManager.LoadScene(1); 
    }

    public void playLvl1(){
        SceneManager.LoadScene(2); 
    }

    public void QuitGame(){
        Application.Quit();
    }

}
