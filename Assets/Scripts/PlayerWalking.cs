using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWalking : MonoBehaviour
{
    public GameObject currentBlock;
    public Animation _animation;

    public int currentStep = 0;
    public bool pause = false;


    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public void StartMoving()
    {
        if (IsListHaveBlock()) // Проверка не пустой ли список
        {
            currentBlock = AllObjectList.Instance.movingBlockScript.showArrows[currentStep];

            AllEventList.Instance.startMovingEvent.Invoke();
            
            Invoke("StepTime", 1.1f / AllGlobalVariable.overallSpeed);
        }
        else
        {
            Debug.Log("Команды кончились!");
            AllEventList.Instance.walkingFinished.Invoke();
        }
    }

    void Step(Vector2 direction, AnimationClip _anim) //Сделать шаг
    {
        if (CollisionPointWith("Floor", direction)) //есть ли пол?
        {
            gameObject.transform.parent.transform.position = gameObject.transform.position;

            _animation.AddClip(_anim, _anim.name);
            _animation[_anim.name].speed = AllGlobalVariable.overallSpeed / 1f;
            _animation.Play(_anim.name);

            AllObjectList.Instance.playerSpriteDrawing.SetSprite(currentStep);
            
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
        AllObjectList.Instance.playerReactionOnFloor.CheckFloorType();

        if (!pause)
        {
            Step(currentBlock.GetComponent<ArrowTestScript>().get(), currentBlock.GetComponent<ArrowTestScript>().getAnimation());
        }
    }



    bool CollisionPointWith(string tag, Vector3 direction)  //Смотрит все объекты в точке, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(transform.position + direction))
        {
            if (s.tag == tag)
                return true;
        }
        return false;
    }

    bool IsListHaveBlock()
    {
        if (AllObjectList.Instance.movingBlockScript.showArrows.Count > currentStep)
            return true;
        else
            return false;
    }
}