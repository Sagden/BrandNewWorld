using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum TypeBlock
{
    Step,
    Jump
}
public class ArrowScript : ActionBlockAbstract
{
    private UnityEvent thisArrowSelect = new UnityEvent();
    public GameObject arrowPrefab;
    public GameObject notificationPrefab;
    private GameObject notification;
    private AnimationClip animClip;
    private bool canDelete = true;
    [SerializeField] private Vector3 dir;
    [SerializeField] private TypeBlock type;
    public bool showStatus = true;

    public AnimationClip AnimClip { get => animClip; set => animClip = value; }
    public Vector3 Dir { get => dir; set => dir = value; }
    internal TypeBlock Type { get => type; set => type = value; }
    public GameObject Notification { get => notification; set => notification = value; }

    void Awake()
    {
        Init();
    }
    void Init()
    {
        if (gameObject.GetComponent<Animation>() != null)
            AnimClip = gameObject.GetComponent<Animation>().clip;
            
        Notification = Instantiate(notificationPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, -1), Quaternion.identity);
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
            Invoke("ChangeCanDeleteStatus", 0.2f);
        }
    }

    void OnMouseUp()
    {
        if (IamInMovingBlock)
        {
            //if (!AllGlobalVariable.Instance.GetStartedWalking(currentPlayer))
            if (canDelete)
            {
                collisionEvents.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().DeleteArrow(gameObject);
            }

            canDelete = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            thisArrowSelect.Invoke();
            thisArrowSelect.RemoveAllListeners();
        }
    }

    public override void AddArrowToMovingBlock()
    {

        if ((collisionEvents.CollisionWithTag("MovingBlock") && (collisionEvents.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().playPauseStatus == "Play"))) //AllObjectList.Instance.playPauseScript.status == "Play") // || (canCreateArrowAtClick == true)
            {
                collisionEvents.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().AddArrow(SelectArrow);
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
        Destroy(Notification);
    }
}
