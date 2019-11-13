using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWalking : PlayerParent
{
    public GameObject currentBlock;
    public bool pause = false;


    public void StartMoving()
    {
        if (IsListHaveBlock()) // Проверка не пустой ли список
        {
            currentBlock = myMovingBlockScript.showArrows[currentStep];

            myEventStart.Invoke();
            
            Invoke("StepTime", 1.1f / AllGlobalVariable.overallSpeed);
        }
        else
        {
            Debug.Log("Команды кончились!");
            myEventFinish.Invoke();
        }
    }

    void Step(Vector2 direction, AnimationClip _anim) //Сделать шаг
    {
        if (CollisionPointWith("Floor", direction)) //есть ли пол?
        {
            gameObject.transform.parent.transform.position = gameObject.transform.position;

            ChangeSpriteAndRunAnimation(_anim);
            
            Invoke("StepTime", 1.1f / AllGlobalVariable.overallSpeed);
        }
        else
        {
            Debug.Log("Там стена!");
            currentStep += 1;
            StartMoving();
        }
    } 

    void StepTime()
    {
        iam.GetComponent<PlayerReactionOnFloor>().CheckFloorType(myFinishFloorName);

        if (!pause)
        {
            Step(currentBlock.GetComponent<ArrowTestScript>().get(), currentBlock.GetComponent<ArrowTestScript>().getAnimation());
        }
    }
}