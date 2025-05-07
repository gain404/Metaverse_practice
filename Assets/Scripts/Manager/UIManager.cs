using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentCoin;
    [SerializeField] private TextMeshProUGUI currentCoinPanel;
    [SerializeField] private TextMeshProUGUI newCoinPanel;

    internal int saveCoin;

    private void Awake()
    {
        saveCoin = PlayerPrefs.GetInt("saveCoin", 0);
    }

    private void Update()
    {
        currentCoin.text = saveCoin.ToString();
    }

    public void SaveCoin()
    {
        //현재 가지고 있는 코인 저장
        saveCoin += GameManager.Instance.currentCoin;
        PlayerPrefs.SetInt("saveCoin", saveCoin);
        PlayerPrefs.Save();

        SetText();
    }

    public void SetText()
    {
        //UI에 연결
        newCoinPanel.text = GameManager.Instance.newCoin.ToString();
        currentCoinPanel.text = saveCoin.ToString();
    }

}
