using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ArrowScript : ActionBlockAbstract
{
    private UnityEvent thisArrowSelect = new UnityEvent();
    public GameObject arrowPrefab;
    public GameObject notificationPrefab;
    private AnimationClip animClip;
    [SerializeField]protected TypeBlock type;

    [SerializeField] private Vector3 dir;

    public AnimationClip AnimClip { get => animClip; set => animClip = value; }
    public Vector3 Dir { get => dir; set => dir = value; }
    internal TypeBlock Type { get => type; set => type = value; }

    void Awake()
    {
        Init();
    }
    void Init()
    {
        TypeParent = type;

        if (gameObject.GetComponent<Animation>() != null)
            AnimClip = gameObject.GetComponent<Animation>().clip;
            Notification = Instantiate(notificationPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, -5), Quaternion.identity);
    }

    void OnMouseDown()
    {
        if (!banOnArrowDrag && !IamInMovingBlock)
        {
            SelectArrow = gameObject;
            prefabObject = Instantiate(arrowPrefab, new Vector3(0,0,-1), transform.rotation);
            thisArrowSelect.AddListener(AddArrowToMovingBlock);
        }
        else
        if (IamInMovingBlock)
        {
            canDelete = true;
            Invoke("ChangeCanDeleteStatus", 0.2f);
        }
    }

    void OnMouseUp()
    {
        DeleteArrow();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            thisArrowSelect.Invoke();
            thisArrowSelect.RemoveAllListeners();
        }
    }

    public void AddArrowToMovingBlock()
    {

        if ((collisionEvents.CollisionWithTag("MovingBlock") && (collisionEvents.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().playPauseStatus == "Play"))) //AllObjectList.Instance.playPauseScript.status == "Play") // || (canCreateArrowAtClick == true)
            {
                if (!AllGlobalVariable.Instance.HeroBlueStartedWalking)
                {
                    collisionEvents.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().AddArrow(SelectArrow);
                    AllObjectList.Instance.createArrow.ArrowBlockCountChangedMinus(SelectArrow);
                }
                else
                {
                    AllObjectList.Instance.stopScript.Shake();
                }
            }
            
        Destroy(prefabObject);
        SelectArrow = null;
    } 
    void ChangeCanDeleteStatus()
    {
        canDelete = false;
    }
    void OnDestroy()
    {
        var parent = GetComponent<CreateJumpBlock>()?.IdArrowFinish?.transform.parent;

        Destroy(Notification);
    }
}
