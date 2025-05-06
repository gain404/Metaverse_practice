using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{

    public float highPosY = 1f;
    public float lowPosY = 1f;

    public float holeSizeMin = 2f;
    public float holeSizeMax = 4f;

    //transform을 값 타입으로 가지는 변수?
    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    private void Start()
    {
        
    }

    internal Vector3 SetRandomPlace(Vector3 lastPosition, int obstactCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfholeSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfholeSize);
        bottomObject.localPosition = new Vector3(0, -halfholeSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    

}
