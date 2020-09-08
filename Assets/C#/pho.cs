using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pho : MonoBehaviour {
    public void scenceSkip(int sceNum) {
        SceneManager.LoadScene(sceNum);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }
    public void p1()
    {
        SceneManager.LoadScene("p1");
    }
    public void p2()
    {
        SceneManager.LoadScene("p2");
    }
    public void p3()
    {
        SceneManager.LoadScene("p3");
    }

}
