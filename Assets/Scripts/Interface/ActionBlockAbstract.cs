using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBlockAbstract : MonoBehaviour
{
    private static GameObject selectArrow = null;
    private bool iamInMovingBlock = false;
    protected CollisionEvents collisionEvents;

    public static bool banOnArrowDrag = false;

    public static GameObject prefabObject;

    public static GameObject SelectArrow { get => selectArrow; set => selectArrow = value; }
    public bool IamInMovingBlock { get => iamInMovingBlock; set => iamInMovingBlock = value; }

    void Start()
    {
        collisionEvents = GetComponent<CollisionEvents>();
        banOnArrowDrag = false;

        AllEventList.Instance.bluePlayerOnFinishFloor.AddListener(BanOnArrowDrag);
    }

    public abstract void AddArrowToMovingBlock();


    void BanOnArrowDrag()
    {
        banOnArrowDrag = true;
    }
    
}
