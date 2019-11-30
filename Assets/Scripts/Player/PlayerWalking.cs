using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWalking : PlayerParent
{
    private GameObject currentBlock;
    private bool pause = false;
    public string myFinishFloorName;
    public UnityEvent myEventFinish, myEventStart;
    private GameObject myMovingBlock;

    public GameObject MyMovingBlock { get => myMovingBlock; set => myMovingBlock = value; }
    public GameObject CurrentBlock { get => currentBlock; set => currentBlock = value; }
    public bool Pause { get => pause; set => pause = value; }

    public void StartMoving()
    {
        var text = GameObject.Find("New Text");
        text.GetComponent<TextMesh>().text = MyMovingBlockScript.ToString();

        if (IsListHaveBlock()) // Проверка не пустой ли список
        {
            CurrentBlock = MyMovingBlockScript.allArrows[CurrentStep];

            myEventStart.Invoke();
            
            Invoke("StepTime", 1.1f / AllGlobalVariable.overallSpeed);
            ReshapeBlocks();
        }
        else
        {
            Debug.Log("Команды кончились!");
            myEventFinish.Invoke();
        }
    }

    public void Step() //Сделать шаг
    {
        var direction = CurrentBlock.GetComponent<ArrowScript>().Dir;

        if (CollisionPointWith("Floor", direction) && !CollisionPointWith("SolidBarrier", direction)) //есть ли пол?
        {
            myPlayersSolidBlock.transform.position = gameObject.transform.position + direction;
            gameObject.transform.parent.transform.position = gameObject.transform.position;

            ChangeSpriteAndRunAnimation(CurrentBlock.GetComponent<ArrowScript>().AnimClip);
            
            Invoke("StepTime", 1.1f / AllGlobalVariable.overallSpeed);
        }
        else
        {
            /*if (!CollisionPointWith("Floor", direction))
            {
                var notificationIcon = AllObjectList.Instance.notification.GetComponent<NotificationIcons>().IconWall;
                AllObjectList.Instance.notificationScript.ShowNotification(notificationIcon, transform);
            }
            if (CollisionPointWith("SolidBarrier", direction))
            {
                var notificationIcon = AllObjectList.Instance.notification.GetComponent<NotificationIcons>().IconRobot;
                AllObjectList.Instance.notificationScript.ShowNotification(notificationIcon, transform);
            } 
            
             уведомления  */

            Debug.Log("Там стена!");
            CurrentStep += 1;
            StartMoving();
        }
    } 
    public void JumpToCommand(int i)
    {
        Debug.Log("hahahah");
        CurrentStep = i;
        StartMoving();
    }

    void StepTime()
    {
        Iam.GetComponent<PlayerReactionOnFloor>().CheckFloorType(myFinishFloorName);

        if (!Pause)
        { 
            switch (CurrentBlock.GetComponent<ArrowScript>().Type)
            {
                case TypeBlock.Step:
                    Step();
                    break;

                case TypeBlock.Jump:
                    JumpToCommand(1);
                    break;
            }
            
        }
    }

    void ReshapeBlocks()
    {
        ISelectableBlockInMovingBlock reshapeBlock = myMovingBlock.GetComponentInParent<SelectBlockInMovingBlock>();
        reshapeBlock.SelectingBlockInMovingBlock(MyMovingBlockScript.allArrows, CurrentBlock);
    }
    void OnDestroy()
    {
        Destroy(myPlayersSolidBlock);
    }
}