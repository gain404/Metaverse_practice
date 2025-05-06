using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentCoin = 0;
    private int newCoin = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    internal void AddCoin(int newCoin)
    {
        currentCoin += newCoin;
    }

}
