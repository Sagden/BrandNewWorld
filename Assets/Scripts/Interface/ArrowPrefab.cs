using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{
    public Sprite arrowJumpSprite;
    void Update()
    {
        MoveToMouse();
    }

    void MoveToMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1), 0);
    }

}
