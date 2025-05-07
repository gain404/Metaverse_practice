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
        float angleX = player.transform.position.x;
        float angleY = player.transform.position.y;

        angleX = Mathf.Clamp(angleX, -5.9f, 5.9f);
        angleY = Mathf.Clamp(angleY, -3.9f, 4.3f);

        Vector3 targetPos = new Vector3(angleX, angleY, -10f);
        cameraPos.position = Vector3.Lerp(cameraPos.position, targetPos, Time.deltaTime * 4);
    }
}
