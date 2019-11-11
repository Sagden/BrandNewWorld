using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBlockAbstract : MonoBehaviour
{
    public static GameObject selectArrow = null;

    public static bool banOnArrowDrag = false;

    public static GameObject prefabObject;

    void Start()
    {
        banOnArrowDrag = false;

        AllEventList.Instance.firstPlayerOnFinishFloor.AddListener(BanOnArrowDrag);
    }

    public abstract void AddArrowToMovingBlock();


    void BanOnArrowDrag()
    {
        banOnArrowDrag = true;
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
