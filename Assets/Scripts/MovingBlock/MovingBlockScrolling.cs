using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockScrolling : MovingBlockScrollingParent
{
    private string myName;
    private bool canScrolling = false;

    void Awake()
    {
        myName = gameObject.name;
        Debug.Log(myName);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && AllObjectList.Instance.bluePlayerObj.GetComponent<PlayerReactionOnFloor>().WhatUnderMe(myName, Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            mouseCoordinateStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movingBlockCoordinateXStart = gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x;
            canScrolling = true;
        }

        Scrolling();

        if (Input.GetMouseButtonUp(0))
        {
            canScrolling = false;
            movingBlockCoordinateXStart = gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x;
        }
    }

    public override void Scrolling()
    {
        if (canScrolling && gameObject.GetComponent<MovingBlockScript>().allArrows.Count != 0)
        {           
            coordinateDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseCoordinateStart;
            
            if (difference <= 0)
            {
                gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x = movingBlockCoordinateXStart + coordinateDifference.x;
            }
            else
            {
                movingBlockCoordinateXStart = 0;
                gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x = 0;
            }
            difference = movingBlockCoordinateXStart + coordinateDifference.x;
        }
    }


}