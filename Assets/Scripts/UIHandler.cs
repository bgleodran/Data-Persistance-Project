using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public void Start()
    {
        DataManager.dataInstance.LoadData();
    }
    public void StartGame()
    {
        DataManager.dataInstance.currentPlayer = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitMainMenu()
    {
        DataManager.dataInstance.SaveHighscore();
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        DataManager.dataInstance.SaveHighscore();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
