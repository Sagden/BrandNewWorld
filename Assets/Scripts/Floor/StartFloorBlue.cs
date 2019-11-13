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
        CreateBluePlayer();

        AllEventList.Instance.stopButtonClick.AddListener(CreateBluePlayer);
        AllEventList.Instance.stopButtonClick.AddListener(InitBluePlayer);
    }

    void Start()
    {
        InitBluePlayer();
    }

    public void InitBluePlayer()
    {
        var path = AllObjectList.Instance.bluePlayerObj.GetComponent<PlayerWalking>();

            path.myMovingBlockScript = AllObjectList.Instance.movingBlockBlue.GetComponent<MovingBlockScript>();
            path.myFinishFloorName = "BlueRobotFinishFloor";
            path.iam = AllObjectList.Instance.bluePlayerObj;
            path.myMovingBlock = AllObjectList.Instance.movingBlockBlue;
            path.myEventStart = AllEventList.Instance.startMovingEventBlue;
            path.myEventFinish = AllEventList.Instance.walkingFinishedBlue;
    }

    public void CreateBluePlayer()
    {
        AllObjectList.Instance.bluePlayerObj = CreatePlayer(player, playerParent);

            AllEventList.Instance.playersIsCreate.Invoke();
    }
}
