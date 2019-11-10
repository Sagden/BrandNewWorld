using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockScrolling : BehaviorLikeUI
{
    private Vector3 mouseCoordinateStart;
    [SerializeField] private float movingBlockCoordinateXStart;
    [SerializeField] private Vector3 coordinateDifference;
    [SerializeField] private float difference;
    [SerializeField] private bool canScrolling = false;


    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && AllObjectList.Instance.playerReactionOnFloor.WhatUnderMe("MovingBlock", Camera.main.ScreenToWorldPoint(Input.mousePosition)))
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

    void Scrolling()
    {
        if (canScrolling && AllObjectList.Instance.movingBlockScript.allArrows.Count != 0)
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

    public void OffsetAddArrow(GameObject arrow)
    {
        difference = 0;

        if (arrow.transform.position.x+0.6f > AllObjectList.Instance.buttonPlay.transform.position.x)
        {
            var offset = AllObjectList.Instance.buttonPlay.transform.position.x - (arrow.transform.position.x+0.6f);
            Debug.Log(offset);
            gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x += offset;
        }
    }
}