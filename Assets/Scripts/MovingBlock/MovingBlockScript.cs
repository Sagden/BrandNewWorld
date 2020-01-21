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
        allCommands.Add(arrow);
        DrawingArrowOnMovingBlock();
    }


    public void DeleteArrow(GameObject deleteObj)
    {
        var index = allCommands.IndexOf(deleteObj);

        allCommands.RemoveAt(index);
        Destroy(deleteObj);

        DrawingArrowOnMovingBlock();
    }


    public void DrawingArrowOnMovingBlock()
    {
        var offset = 0.5f;

        for(int i = 0; i < allCommands.Count; i++)
        {
            
            var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
            
            allCommands[i].transform.position = new Vector3(leftBorder.x+offset, Camera.main.transform.position.y+myOffset, -1);
            allCommands[i].transform.SetParent(gameObject.transform);
            if (allCommands[i].GetComponent<ActionBlockAbstract>()?.IamInMovingBlock == false)
            {
                allCommands[i].GetComponent<ActionBlockAbstract>().IamInMovingBlock = true;
            }
            offset += 0.7f;
        }
    }
}
