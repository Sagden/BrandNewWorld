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
            CurrentBlock = MyMovingBlockScript.showArrows[currentStep];

            myEventStart.Invoke();
            
            Invoke("StepTime", 1.1f / AllGlobalVariable.overallSpeed);

        }
        else
        {
            Debug.Log("Команды кончились!");
            myEventFinish.Invoke();
        }
    }

    public void Step(Vector3 direction, AnimationClip _anim) //Сделать шаг
    {
        if (CollisionPointWith("Floor", direction) && !CollisionPointWith("SolidBarrier", direction)) //есть ли пол?
        {
            myPlayersSolidBlock.transform.position = gameObject.transform.position + direction;
            gameObject.transform.parent.transform.position = gameObject.transform.position;

            ChangeSpriteAndRunAnimation(_anim);
            
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
            currentStep += 1;
            StartMoving();
        }
    } 

    void StepTime()
    {
        Iam.GetComponent<PlayerReactionOnFloor>().CheckFloorType(myFinishFloorName);

        if (!Pause)
        {
            Step(CurrentBlock.GetComponent<ArrowTestScript>().Direction, CurrentBlock.GetComponent<ArrowTestScript>().Animate);
        }
    }

    void OnDestroy()
    {
        Destroy(myPlayersSolidBlock);
    }
}