using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPlayer : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField]private float maxDistance;
    [SerializeField] private GameObject blueFinishFloor;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float rStart, gStart, bStart;
    [SerializeField] private float rFinish, gFinish, bFinish;
    [SerializeField] private float rCurrent, gCurrent, bCurrent;
    private Color rgbStart;

    void Start()
    {
        blueFinishFloor = GameObject.Find("BlueRobotFinishFloor");
        spriteRenderer = GetComponent<SpriteRenderer>();

        maxDistance = Vector3.Distance(transform.position, blueFinishFloor.transform.position) - 1;

        spriteRenderer.color = new Color32(139,203,253,255);

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
