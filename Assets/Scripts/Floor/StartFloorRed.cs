using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFloorRed : StartFloorParent
{
    public GameObject player;
    public GameObject playerParent;

    void OnEnable()
    {
        CreateRedPlayer();
        //InitRedPlayer();

        AllEventList.Instance.stopButtonClick.AddListener(CreateRedPlayer);
        AllEventList.Instance.stopButtonClick.AddListener(InitRedPlayer);
    }

    void Start()
    {
        InitRedPlayer();
    }

    public void CreateRedPlayer()
    {
        AllObjectList.Instance.redPlayerObj = CreatePlayer(player, playerParent);
    }
    public void InitRedPlayer()
    {
        var path = AllObjectList.Instance.redPlayerObj.GetComponent<PlayerWalking>();

            path.MyMovingBlockScript = AllObjectList.Instance.movingBlockRed.GetComponent<MovingBlockScript>();
            path.myFinishFloorName = "RedRobotFinishFloor";
            path.Iam = AllObjectList.Instance.redPlayerObj;
            path.MyMovingBlock = AllObjectList.Instance.movingBlockRed;
            path.myEventStart = AllEventList.Instance.startMovingEventRed;
            path.myEventFinish = AllEventList.Instance.walkingFinishedRed;
    }
}
