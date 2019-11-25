using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFloorBlue : StartFloorParent
{
    public GameObject player;
    public GameObject playerParent;

    void OnEnable()
    {
        CreateBluePlayer();
        
        AllEventList.Instance.stopButtonClick.AddListener(CreateBluePlayer);
        AllEventList.Instance.stopButtonClick.AddListener(InitBluePlayer);
    }

    void Start()
    {
        InitBluePlayer();
    }

    public void CreateBluePlayer()
    {
        AllObjectList.Instance.bluePlayerObj = CreatePlayer(player, playerParent);
        AllEventList.Instance.playersIsCreate.Invoke();
    }
    public void InitBluePlayer()
    {
        var path = AllObjectList.Instance.bluePlayerObj.GetComponent<PlayerWalking>();

            path.MyMovingBlockScript = AllObjectList.Instance.movingBlockBlue.GetComponent<MovingBlockScript>();
            path.myFinishFloorName = "BlueRobotFinishFloor";
            path.Iam = AllObjectList.Instance.bluePlayerObj;
            path.MyMovingBlock = AllObjectList.Instance.movingBlockBlue;
            path.myEventStart = AllEventList.Instance.startMovingEventBlue;
            path.myEventFinish = AllEventList.Instance.walkingFinishedBlue;
    }
}
