using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void RetryBtn()
    {
        SceneManager.LoadScene("MiniGameScene");
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
