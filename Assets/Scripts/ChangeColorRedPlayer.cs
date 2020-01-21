using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRedPlayer : MonoBehaviour
{
    private float distance;
    private float maxDistance;
    private GameObject redFinishFloor;
    private SpriteRenderer spriteRenderer;
    private float rStart, gStart, bStart;
    private float rFinish, gFinish, bFinish;
    private float rCurrent, gCurrent, bCurrent;
    private Color rgbStart;

    void Start()
    {
        redFinishFloor = AllObjectList.Instance.redRobotFinishFloor;
        spriteRenderer = GetComponent<SpriteRenderer>();

        maxDistance = Vector3.Distance(transform.position, redFinishFloor.transform.position) - 1;

        spriteRenderer.color = AllObjectList.Instance.redRobotStartFloor.GetComponent<SpriteRenderer>().color;

        rStart = spriteRenderer.color.r;
        gStart = spriteRenderer.color.g;
        bStart = spriteRenderer.color.b;
        
        rFinish = redFinishFloor.GetComponent<SpriteRenderer>().color.r;
        gFinish = redFinishFloor.GetComponent<SpriteRenderer>().color.g;
        bFinish = redFinishFloor.GetComponent<SpriteRenderer>().color.b;
    }
    void FixedUpdate()
    {   
        
        distance = ((Vector3.Distance(transform.position, redFinishFloor.transform.position) - 1) / maxDistance);

        if ((Vector3.Distance(transform.position, redFinishFloor.transform.position) - 1) <= maxDistance)
        {
            rCurrent = rFinish + ((rStart - rFinish) * distance);
            gCurrent = gFinish + ((gStart - gFinish) * distance);
            bCurrent = bFinish + ((bStart - bFinish) * distance);
        }

        spriteRenderer.color = new Color(rCurrent,gCurrent,bCurrent,1);
    }
}
