using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    protected PlayerController player;
    protected Transform cameraPos;

    protected virtual void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        cameraPos = transform;
    }

    protected virtual void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        cameraPos.position = Vector3.Lerp(cameraPos.position, targetPos, Time.deltaTime * 4);
    }
}
