using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : CameraController
{
    
    protected override void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        cameraPos = transform;
    }

    protected override void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        cameraPos.position = Vector3.Lerp(cameraPos.position, targetPos, Time.deltaTime * 4);
    }
}
