using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class BoolArrowCheck
{
    public int commandNumber;
    public GameObject command;
    public GameObject id;
}

public class CreateArrow : MonoBehaviour
{
    public List<BoolArrowCheck> arrowList;

    void Start()
    {
        CreateArrowBlock();
    }

    public void CreateArrowBlock()
    {
        var offset = 0.5f;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.commandNumber > 0)
            {
                obj.id = Instantiate(obj.command, new Vector3(leftBorder.x+offset, Camera.main.transform.position.y-4.1f, -1), obj.command.transform.rotation, gameObject.transform);
                obj.id.GetComponent<ActionBlockAbstract>().Notification.GetComponentInChildren<Transform>().GetComponentInChildren<TextMesh>().text = obj.commandNumber.ToString();
                offset += 0.7f;

                Debug.Log("Создан блок " + obj.id);
            }
            
        }
    }

    public void ClearArrowBlock()
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.id != null)
            if (obj.id.GetComponent<ActionBlockAbstract>().IamInMovingBlock)
            {
                Destroy(obj.id.GetComponent<ActionBlockAbstract>().Notification);
            }
            else
            if (obj.id != null)
            {
                Destroy(obj.id);
            }
        }
    }

    public void ArrowBlockCountChangedMinus(GameObject arrowObj)
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.id != null)
            if (obj.id == arrowObj && obj.commandNumber > 0)
            {
                obj.commandNumber -= 1;
                ClearArrowBlock();
                CreateArrowBlock();
            }
        }
    }

    public void ArrowBlockCountChangedPlus(GameObject arrowObj)
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.id != null)
            if (obj.id.name == arrowObj.name)
            {
                obj.commandNumber += 1;
                ClearArrowBlock();
                CreateArrowBlock();
            }
        }
    }
}
