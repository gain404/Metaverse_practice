using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject Panel;

    
    void Start()
    {
        Panel.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void SetRetry()
    {
        Panel.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
