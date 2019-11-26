using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRedPlayer : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField]private float maxDistance;
    [SerializeField] private GameObject redFinishFloor;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float rStart, gStart, bStart;
    [SerializeField] private float rFinish, gFinish, bFinish;
    [SerializeField] private float rCurrent, gCurrent, bCurrent;
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
        
        rFinish = 111f / 256f;
        gFinish = 69f / 256f;
        bFinish = 73f / 256f;
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
