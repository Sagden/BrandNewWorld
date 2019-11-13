using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFloorBlue : StartFloorParent
{
    public GameObject player;
    public GameObject playerParent;

    void Awake()
    {
        CreateAndInitBluePlayer();
    }

    public void CreateAndInitBluePlayer()
    {
        AllObjectList.Instance.bluePlayerObj = CreatePlayer(player, playerParent);

        var path = AllObjectList.Instance.bluePlayerObj.GetComponent<PlayerWalking>();
            path.myFinishFloorName = "BlueRobotFinishFloor";
            path.iam = AllObjectList.Instance.bluePlayerObj;
            path.myMovingBlock = AllObjectList.Instance.movingBlockBlue;
            path.myMovingBlockScript = AllObjectList.Instance.movingBlockBlue.GetComponent<MovingBlockScript>();
            path.myEventStart = AllEventList.Instance.startMovingEventBlue;
            path.myEventFinish = AllEventList.Instance.walkingFinishedBlue;
    }
}
