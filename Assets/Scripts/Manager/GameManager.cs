using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    internal int currentCoin;
    internal int newCoin;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    internal void AddCoin(int newCoinAmount)
    {
        newCoin += newCoinAmount;
        currentCoin += newCoinAmount;
    }

}
