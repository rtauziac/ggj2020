using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgMenu : MonoBehaviour
{
    public void Commencer()
    {
        SceneManager.LoadScene("Niveau");
    }
    public void Quitter()
    {
        Application.Quit();
    }
}
