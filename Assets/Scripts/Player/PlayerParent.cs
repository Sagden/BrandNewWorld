using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class PlayerParent : MonoBehaviour
{
    private int currentStep = 0;
    private MovingBlockScript myMovingBlockScript;
    private GameObject iam;
    private Animation animationPlayer;
    protected GameObject myPlayersSolidBlock;

    public Animation AnimationPlayer 
    { 
        get => animationPlayer; 
        set => animationPlayer = value; 
    }
    public MovingBlockScript MyMovingBlockScript 
    { 
        get => myMovingBlockScript; 
        set => myMovingBlockScript = value; 
    }
    public GameObject Iam 
    { 
        protected get => iam; 
        set => iam = value; 
    }
    public int CurrentStep { get => currentStep; set => currentStep = value; }

    void Start()
    {
        AnimationPlayer = GetComponent<Animation>();
        myPlayersSolidBlock = Instantiate(AllObjectList.Instance.playersSolidBlock, transform.position, Quaternion.identity);
    }

    public void ChangeSpriteAndRunAnimation(AnimationClip _anim) //Меняет спрайт, запускает анимацию ходьбы
    {
        AnimationPlayer.AddClip(_anim, _anim.name);
        AnimationPlayer[_anim.name].speed = AllGlobalVariable.overallSpeed / 1f;
        AnimationPlayer.Play(_anim.name);

        iam.GetComponent<PlayerSpriteDrawing>().SetSprite(CurrentStep);
    }
    public bool IsListHaveBlock() // Проверяет есть ли команды для выполнения
    {
        return MyMovingBlockScript.showArrows.Count > CurrentStep;
    }
    public bool CollisionPointWith(string tag, Vector3 direction)
    {
        return Physics2D.OverlapPointAll(transform.position + direction)?.Any(s => s.tag == tag)?? false;
    }
}
