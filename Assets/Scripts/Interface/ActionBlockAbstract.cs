using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBlock
{
    Step,
    Jump,
    Empty
}

public abstract class ActionBlockAbstract : MonoBehaviour
{
    private bool iamInMovingBlock = false;
    protected bool canDelete = true;
    private static GameObject selectArrow = null;

    protected CollisionEvents collisionEvents;

    public static bool banOnArrowDrag = false;
    public bool showStatus = true;
    private GameObject notification;
    protected TypeBlock typeParent;
    public static GameObject prefabObject;

    public static GameObject SelectArrow { get => selectArrow; set => selectArrow = value; }
    public GameObject Notification { get => notification; set => notification = value; }
    public bool IamInMovingBlock { get => iamInMovingBlock; set => iamInMovingBlock = value; }
    public TypeBlock TypeParent { get => typeParent; set => typeParent = value; }

    void Start()
    {
        collisionEvents = GetComponent<CollisionEvents>();
        banOnArrowDrag = false;

        AllEventList.Instance.allPlayersOnFinishFloor.AddListener(BanOnArrowDrag);
    }
 
    void BanOnArrowDrag()
    {
        banOnArrowDrag = true;
    }
    
    public virtual void DeleteArrow()
    {
        if (iamInMovingBlock && !collisionEvents.CollisionWithTag("ButtonPlay"))
        {
            if (!MyHeroIsStarted())
                if (canDelete)
                {
                    collisionEvents.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().DeleteArrow(gameObject);
                    AllObjectList.Instance.createArrow.ArrowBlockCountChangedPlus(gameObject);
                }
            canDelete = true;
        }
    }

    public bool MyHeroIsStarted()
    {
        switch(transform.parent.name)
        {
            case "MovingBlockBlue(Clone)": return AllGlobalVariable.Instance.HeroBlueStartedWalking;
            case "MovingBlockRed(Clone)": return AllGlobalVariable.Instance.HeroRedStartedWalking;
            default: return false;
        }
    }
}
