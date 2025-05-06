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
        spawnTimer += Time.deltaTime; //�ð� �귯���� ����
        if (spawnTimer >= spawnInterval) //�귯�� �ð��� ���� ���� ���ں��� ũ�� ���� ����
        {
            SpawnCoin();
            spawnTimer = 0;
        }

    }

    private GameObject RandomCoin() //���� ������Ʈ �������� ������
    {
        int count = coinPosTrans.childCount;
        if (count == 0) return null;

        int getCoinIndex = Random.Range(0, count);
        Transform child = coinPosTrans.GetChild(getCoinIndex);
        return child.gameObject;
    }

    private Vector3 SetRandomPlace() //������Ʈ ���� ��ġ
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
