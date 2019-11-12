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
    public GameObject currentPlayer;
    public bool myHeroStart;


    void Start()
    {
        Init();

        spriteRenderer = GetComponent<SpriteRenderer>();

        currentPlayer.GetComponent<PlayerWalking>().myEventStart.AddListener(ChangeColor);
        currentPlayer.GetComponent<PlayerWalking>().myEventFinish.AddListener(ChangeColorOnWhite);
        AllEventList.Instance.stopButtonClick.AddListener(ChangeColorOnWhite);
        AllEventList.Instance.stopButtonClick.AddListener(Init);
    }

    void OnMouseDown()
    {
        Invoke("ChangeCanDeleteStatus", 0.2f);
    }

    void OnMouseUp()
    {
        if (canDelete)
        {
            if (!myHeroStart)
            {
                CollisionWith("MovingBlock", Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))).GetComponent<MovingBlockScript>().DeleteArrow(gameObject);
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
        if (!myHeroStart)
            canDelete = false;
    }
    void ChangeColor()
    {
        spriteRenderer.color = new Color32(110,110,110,255);

        currentPlayer.GetComponent<PlayerWalking>().currentBlock.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
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

    public GameObject CollisionWith(string objName, Vector3 pos)  //Смотрит все объекты под курсором, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(pos))
        {
            if (s.tag == objName)
                return s.gameObject;
        }
        return null;
    }

    void Init()
    {
        

        if (CollisionWith("MovingBlock", transform.position).name == "MovingBlockBlue")
        {
            currentPlayer = AllObjectList.Instance.bluePlayerObj;
            myHeroStart = AllGlobalVariable.heroBlueStartedWalking;
        }
        else
        if (CollisionWith("MovingBlock", transform.position).name == "MovingBlockRed")
        {
            Debug.Log("Инициализация сработала");
            currentPlayer = AllObjectList.Instance.redPlayerObj;
            myHeroStart = AllGlobalVariable.heroRedStartedWalking;
        }
    }
}
