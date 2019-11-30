using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MovingBlockScript : MovingBlockParent
{
    public Animation _animation;
    public string playPauseStatus;
    public GameObject myMovingBlock;
    public string myName;
    public float myOffset;


    void Start()
    {
        myName = gameObject.name;
        _animation = gameObject.GetComponent<Animation>();

        gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y+myOffset) - Camera.main.transform.position; 
    }

    public void AddArrow(GameObject arrow)
    {
        allArrows.Add(arrow);
        DrawingArrowOnMovingBlock();
        AllObjectList.Instance.createArrow.ArrowBlockCountChangedMinus(arrow);
    }


    public void DeleteArrow(GameObject deleteObj)
    {
        var index = allArrows.IndexOf(deleteObj);

        AllObjectList.Instance.createArrow.ArrowBlockCountChangedPlus(allArrows[index].name);
        allArrows.RemoveAt(index);
        Destroy(deleteObj);

        DrawingArrowOnMovingBlock();
    }


    void DrawingArrowOnMovingBlock()
    {
        for(int i = 0; i < allArrows.Count; i++)
        {
            var offset = i * 0.7f;

            allArrows[i].transform.position = new Vector3(transform.position.x-2+offset, Camera.main.transform.position.y+myOffset, -1);
            allArrows[i].GetComponent<ArrowScript>().IamInMovingBlock = true;
            allArrows[i].transform.SetParent(gameObject.transform);
        }
    }
}
