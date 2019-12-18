using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovingBlockScrolling : MovingBlockScrollingParent
{
    private string myName;
    private bool canScrolling = false;
    private PlayerReactionOnFloor checkUnderMe;

    void Awake()
    {
        myName = gameObject.name;
        Debug.Log(myName);
    }
    void Start()
    {
        checkUnderMe = AllObjectList.Instance.bluePlayerObj.GetComponent<PlayerReactionOnFloor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && 
        checkUnderMe.WhatUnderMe(myName, Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
             if (checkUnderMe.WhatUnderMeReturnObj("ArrowEmpty(Clone)", Camera.main.ScreenToWorldPoint(Input.mousePosition))
                ||
                (!checkUnderMe.WhatUnderMe("ArrowEmpty(Clone)", Camera.main.ScreenToWorldPoint(Input.mousePosition))))
            {
                mouseCoordinateStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                movingBlockCoordinateXStart = gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x;
                canScrolling = true;
            }
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
        if (gameObject.GetComponent<MovingBlockScript>().allCommands.Count > 6)
        {
            if (canScrolling && gameObject.GetComponent<MovingBlockScript>().allCommands.Count != 0)
            {           
                coordinateDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseCoordinateStart;
                
                if (difference <= 0)
                {
                    if (gameObject.GetComponent<MovingBlockScript>().allCommands.Last().transform.position.x >= AllObjectList.Instance.buttonPlayBlue.gameObject.transform.position.x-0.6f)
                    {
                        gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x = movingBlockCoordinateXStart + coordinateDifference.x;
                        var i = movingBlockCoordinateXStart + coordinateDifference.x;
                    }
                    else
                    {
                        if (gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x < movingBlockCoordinateXStart + coordinateDifference.x)
                            gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x = movingBlockCoordinateXStart + coordinateDifference.x;
                    }
                }
                else
                {
                    movingBlockCoordinateXStart = 0;
                    gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x = 0;
                }
                difference = movingBlockCoordinateXStart + coordinateDifference.x;
            }
        }
        else
        {
            gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x = 0;
        }
    }


}