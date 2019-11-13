using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFloorRed : StartFloorParent
{
    public GameObject player;
    public GameObject playerParent;

    void Awake()
    {
        CreateAndInitRedPlayer();
    }

    public void CreateAndInitRedPlayer()
    {
        AllObjectList.Instance.redPlayerObj = CreatePlayer(player, playerParent);

        var path = AllObjectList.Instance.redPlayerObj.GetComponent<PlayerWalking>();
            path.myFinishFloorName = "RedRobotFinishFloor";
            path.iam = AllObjectList.Instance.redPlayerObj;
            path.myMovingBlock = AllObjectList.Instance.movingBlockRed;
            path.myMovingBlockScript = AllObjectList.Instance.movingBlockRed.GetComponent<MovingBlockScript>();
            path.myEventStart = AllEventList.Instance.startMovingEventRed;
            path.myEventFinish = AllEventList.Instance.walkingFinishedRed;
    }
}
