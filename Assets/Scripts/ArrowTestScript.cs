using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTestScript : MonoBehaviour
{
    [SerializeField]private Vector2 direction;
    [SerializeField]private AnimationClip animate;
    [SerializeField] private bool canDelete = true;
    //private bool playerIsStop = true;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        AllEventList.Instance.startMovingEvent.AddListener(ChangeColor);
        AllEventList.Instance.walkingFinished.AddListener(ChangeColorOnWhite);
        AllEventList.Instance.stopButtonClick.AddListener(ChangeColorOnWhite);
    }

    void OnMouseDown()
    {
        Invoke("ChangeCanDeleteStatus", 0.2f);
    }

    void OnMouseUp()
    {
        if (canDelete)
        {
            if (!AllGlobalVariable.heroStartedWalking)
            {
                CollisionMouseWith("MovingBlock").GetComponent<MovingBlockScript>().DeleteArrow(gameObject);
            }
            else
            {
                AllObjectList.Instance.stopScript.Shake();
            }
        }

        canDelete = true;
    }

    void ChangeCanDeleteStatus()
    {
        if (!AllGlobalVariable.heroStartedWalking)
            canDelete = false;
    }
    void ChangeColor()
    {
        spriteRenderer.color = new Color32(110,110,110,255);
        AllObjectList.Instance.playerWalking.currentBlock.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }

    void ChangeColorOnWhite()
    {
        spriteRenderer.color = new Color32(255,255,255,255);
    }
    public Vector2 get()
    {
        return direction;
    }

    public AnimationClip getAnimation()
    {
        return animate;
    }

    public void set(Vector2 _dir, AnimationClip _animation)
    {
        direction = _dir;
        animate = _animation;
    }

    public GameObject CollisionMouseWith(string objName)  //Смотрит все объекты под курсором, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))))
        {
            if (s.tag == objName)
                return s.gameObject;
        }
        return null;
    }
}
