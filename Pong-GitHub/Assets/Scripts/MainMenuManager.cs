using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField]
    private string Scene;
    public void StartGame() {
        SceneManager.LoadScene(Scene);
    }

    public void ExitGame() {
        //Debug.Log("Sair!");
        Application.Quit();
    }
}