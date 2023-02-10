using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Game";

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
