using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController player;

    Transform cameraPos;
    Transform targetPos;


    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        targetPos = player.transform;
        cameraPos = transform;
    }

    void Start()
    {
        
    }


    void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        cameraPos.position = Vector3.Lerp(cameraPos.position, targetPos, Time.deltaTime * 4);
    }
}
