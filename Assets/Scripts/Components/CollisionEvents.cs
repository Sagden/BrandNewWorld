using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvents : MonoBehaviour
{
    public GameObject CollisionWithTag(string objName, Vector3 pos)  //Смотрит все объекты под pos, проверяет есть ли objName
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(pos))
        {
            if (s.tag == objName)
                return s.gameObject;
        }
        return null;
    }


    public GameObject CollisionWithTag(string objName)  //Смотрит все объекты под курсором, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))))
        {
            if (s.tag == objName)
                return s.gameObject;
        }
        return null;
    }
    public GameObject CollisionWithObj(string objName)  //Смотрит все объекты под курсором, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))))
        {
            if (s.name == objName)
                return s.gameObject;
        }
        return null;
    }


    public GameObject CollisionWithObj(GameObject obj)  //Смотрит все объекты под курсором, проверяет есть ли нужный
    {
        foreach(Collider2D s in Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))))
        {
            if (s.gameObject == obj)
                return s.gameObject;
        }
        return null;
    }
}
