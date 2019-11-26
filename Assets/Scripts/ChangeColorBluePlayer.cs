using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorBluePlayer : MonoBehaviour
{
    private float distance;
    private float maxDistance;
    private GameObject blueFinishFloor;
    private SpriteRenderer spriteRenderer;
    private float rStart, gStart, bStart;
    private float rFinish, gFinish, bFinish;
    private float rCurrent, gCurrent, bCurrent;
    private Color rgbStart;

    void Start()
    {
        blueFinishFloor = AllObjectList.Instance.blueRobotFinishFloor;
        spriteRenderer = GetComponent<SpriteRenderer>();

        maxDistance = Vector3.Distance(transform.position, blueFinishFloor.transform.position) - 1;

        spriteRenderer.color = AllObjectList.Instance.blueRobotStartFloor.GetComponent<SpriteRenderer>().color;

        rStart = spriteRenderer.color.r;
        gStart = spriteRenderer.color.g;
        bStart = spriteRenderer.color.b;
        
        rFinish = 80f / 256f;
        gFinish = 86f / 256f;
        bFinish = 130f / 256f;
    }
    void FixedUpdate()
    {   
        
        distance = ((Vector3.Distance(transform.position, blueFinishFloor.transform.position) - 1) / maxDistance);

        if ((Vector3.Distance(transform.position, blueFinishFloor.transform.position) - 1) <= maxDistance)
        {
            rCurrent = rFinish + ((rStart - rFinish) * distance);
            gCurrent = gFinish + ((gStart - gFinish) * distance);
            bCurrent = bFinish + ((bStart - bFinish) * distance);
        }

        spriteRenderer.color = new Color(rCurrent,gCurrent,bCurrent,1);
    }
}
