using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorLikeUI : MonoBehaviour
{
    public Vector3 coordinateRelativeCamera;
    void Awake()
    {
        coordinateRelativeCamera = transform.position - Camera.main.transform.position;
    }
    void Update()
    {
        MoveLikeUI();
    }

    void MoveLikeUI()
    {
        transform.position = Camera.main.transform.position + coordinateRelativeCamera;
    }
}
