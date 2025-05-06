using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCamera : CameraController
{
    MiniGamePlayer miniGamePlayer;
    bool isPlayerDead = false;

    protected override void Awake()
    {
        miniGamePlayer = GameObject.FindObjectOfType<MiniGamePlayer>();
        cameraPos = transform;
        MiniGamePlayer.OnPlayerDied += ChangeState;
    }

    protected override void Update()
    {
        if (isPlayerDead == false)
        {
            Vector3 pos = cameraPos.position;
            Vector3 targetPos = new Vector3(miniGamePlayer.transform.position.x, 0, -10f);
            cameraPos.position = Vector3.Lerp(pos, targetPos, Time.deltaTime * 4);
        }
    }

    private void ChangeState()
    {
        isPlayerDead = true;
        enabled = false;
        return;
    }

}
