using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerReactionOnFloor : MonoBehaviour
{
    public void CheckFloorType(string floorName)
    {
        if (WhatUnderMe(floorName, gameObject.transform.position))
        {
            AllEventList.Instance.bluePlayerOnFinishFloor.Invoke();
        }
    }


    public bool WhatUnderMe(string name, Vector3 positionObj)  //Смотрит все имена объектов под игроком
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(positionObj))
        {
            if (s.name == name)
                return true;
        }
        return false;
    }
}
