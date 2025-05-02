using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCamera : CameraController
{

    MiniGamePlayer miniGamePlayer;

    protected override void Awake()
    {
        miniGamePlayer = GameObject.FindObjectOfType<MiniGamePlayer>();
        cameraPos = transform;
    }
    protected override void Update()
    {
        Vector3 pos = cameraPos.position;
        Vector3 targetPos = new Vector3(miniGamePlayer.transform.position.x, 0f, -10f);
        cameraPos.position = Vector3.Lerp(pos, targetPos, Time.deltaTime * 4);
    }
}
