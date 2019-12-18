using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerReactionOnFloor : MonoBehaviour
{
    public void CheckFloorType()
    {
        var myFinishFloorNameLocal = gameObject.GetComponent<PlayerMovement>().myFinishFloorName;

        if (WhatUnderMe(myFinishFloorNameLocal, gameObject.transform.position))
        {
            switch (GetComponent<PlayerMovement>().Iam.name)
            {
                case "PlayerBlue(Clone)": AllGlobalVariable.Instance.BluePlayerOnFinishFloor = true; break;
                case "PlayerRed(Clone)": AllGlobalVariable.Instance.RedPlayerOnFinishFloor = true; break;
                default: Debug.Log("Red"); break;
            }

            GetComponent<PlayerMovement>().Pause = true;
            WhatUnderMe(myFinishFloorNameLocal).GetComponent<Animation>().Play(); 
            Instantiate(AllObjectList.Instance.checkMark, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
            IsPlayerObjectsFinished();
        }
    }

    void IsPlayerObjectsFinished()
    {
        if (AllObjectList.Instance.movingBlockRed == null)
        {
            if (AllGlobalVariable.Instance.BluePlayerOnFinishFloor)
            {
                AllEventList.Instance.allPlayersOnFinishFloor.Invoke();
            }
        }
        else
        {
            if (AllGlobalVariable.Instance.BluePlayerOnFinishFloor && AllGlobalVariable.Instance.RedPlayerOnFinishFloor)
            {
                AllEventList.Instance.allPlayersOnFinishFloor.Invoke();
            }
        }
    }


    public GameObject WhatUnderMe(string name)  //Смотрит все имена объектов под игроком
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(gameObject.transform.position))
        {
            if (s.name == name)
                return s.gameObject;
        }
        return null;
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
    public bool WhatUnderMeReturnObj(string name, Vector3 positionObj)  //Смотрит все имена объектов под игроком
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(positionObj))
        {
            if (s.name == name)
                return s.GetComponent<ArrowScriptEmpty>().MyHeroIsStarted();
        }
        return false;
    }
}
