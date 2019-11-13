using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerParent : MonoBehaviour
{
    public int currentStep = 0;
    public MovingBlockScript myMovingBlockScript;
    public Animation animationPlayer;
    public GameObject iam;
    public GameObject myMovingBlock;
    public UnityEvent myEventStart;
    public UnityEvent myEventFinish;
    public string myFinishFloorName;

    void Awake()
    {
        animationPlayer = GetComponent<Animation>();
    }

    public void ChangeSpriteAndRunAnimation(AnimationClip _anim) //Меняет спрайт, запускает анимацию ходьбы
    {
        animationPlayer.AddClip(_anim, _anim.name);
        animationPlayer[_anim.name].speed = AllGlobalVariable.overallSpeed / 1f;
        animationPlayer.Play(_anim.name);

        iam.GetComponent<PlayerSpriteDrawing>().SetSprite(currentStep);
    }
    public bool IsListHaveBlock() // Проверяет есть ли команды для выполнения
    {
        if (myMovingBlockScript.showArrows.Count > currentStep)
            return true;
        else
            return false;
    }
    public bool CollisionPointWith(string tag, Vector3 direction)  //Смотрит все объекты в точке, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(transform.position + direction))
        {
            if (s.tag == tag)
                return true;
        }
        return false;
    }
}
