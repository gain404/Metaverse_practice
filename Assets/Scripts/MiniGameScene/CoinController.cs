using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    MiniGamePlayer miniGamePlayer;
    bool isPlayerDead = false;

    private Transform coinPosTrans;
    Transform miniGamePlayerTrans;

    private float spawnInterval;
    private float spawnTimer;

    private void Awake()
    {
        miniGamePlayerTrans = GameObject.FindWithTag("Player").transform;
        GameObject coinPrefabs = Resources.Load<GameObject>("Prefabs/Coin");
        miniGamePlayer = GameObject.FindObjectOfType<MiniGamePlayer>();
        coinPosTrans = coinPrefabs.transform;
        MiniGamePlayer.OnPlayerDied += ChangeState;
    }

    void Update()
    {
        spawnInterval = Random.Range(1f, 3f);
        spawnTimer += Time.deltaTime; //시간 흘러가는 로직
        if (spawnTimer >= spawnInterval) //흘러간 시간이 스폰 간격 숫자보다 크면 코인 스폰
        {
            SpawnCoin();
            spawnTimer = 0;
        }

    }

    private GameObject RandomCoin() //코인 오브젝트 랜덤으로 가져옴
    {
        int count = coinPosTrans.childCount;
        if (count == 0) return null;

        int getCoinIndex = Random.Range(0, count);
        Transform child = coinPosTrans.GetChild(getCoinIndex);
        return child.gameObject;
    }

    private Vector3 SetRandomPlace() //오브젝트 랜덤 배치
    {
        float xPositionPlus = Random.Range(7f, 15f);
        float xPosition = miniGamePlayerTrans.transform.localPosition.x + xPositionPlus;
        float yPosition = Random.Range(-5f, 5f);

        return new Vector3(xPosition, yPosition);
    }

    void SpawnCoin()
    {
        GameObject coin = Instantiate(RandomCoin());
        if (coin != null)
        {
            Vector3 pos = SetRandomPlace();
            coin.transform.position = pos;

        }
    }
    private void ChangeState()
    {
        isPlayerDead = true;
        enabled = false;
        return;
    }

}
