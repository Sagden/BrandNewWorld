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
    protected bool canDelete = true;
    protected CollisionEvents collisionEventsComponent;

    public static bool banOnTakingCommandBlock = false;
    public bool showStatus = true;
    public static GameObject prefabObject;

    public static GameObject SelectedCommand { get; set; } = null;
    public GameObject Notification { get; set; }
    public bool IamInMovingBlock { get; set; }
    public TypeBlock TypeParent { get; set; }

    void Start()
    {
        collisionEventsComponent = GetComponent<CollisionEvents>();
        banOnTakingCommandBlock = false;

        AllEventList.Instance.allPlayersOnFinishFloor.AddListener(BanOnTakingCommandBlock);
    }
 
    void BanOnTakingCommandBlock()
    {
        banOnTakingCommandBlock = true;
    }
    
    public virtual void DeleteArrow()
    {
        if (IamInMovingBlock && !collisionEventsComponent.CollisionWithTag("ButtonPlay"))
        {
            if (!MyHeroIsStarted())
                if (canDelete)
                {
                    collisionEventsComponent.CollisionWithTag("MovingBlock").GetComponent<MovingBlockScript>().DeleteArrow(gameObject);
                    AllObjectList.Instance.createArrow.AddCommandToCommandStorage(gameObject);
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
