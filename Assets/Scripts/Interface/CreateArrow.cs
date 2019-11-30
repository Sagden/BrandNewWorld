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
        var offset = 0f;

        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.commandNumber > 0)
            {
                obj.id = Instantiate(obj.command, new Vector3(Camera.main.transform.position.x-2+offset, Camera.main.transform.position.y-4.1f, -1), obj.command.transform.rotation, gameObject.transform);
                obj.id.GetComponent<ArrowScript>().Notification.GetComponentInChildren<Transform>().GetComponentInChildren<TextMesh>().text = obj.commandNumber.ToString();
                offset += 0.7f;
            }
            
        }
    }

    public void ClearArrowBlock()
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.id.GetComponent<ArrowScript>().IamInMovingBlock)
            {
                Destroy(obj.id.GetComponent<ArrowScript>().Notification);
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
            if (obj.id == arrowObj && obj.commandNumber > 0)
            {
                obj.commandNumber -= 1;
                ClearArrowBlock();
                CreateArrowBlock();
            }
        }
    }

    public void ArrowBlockCountChangedPlus(string arrowObj)
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.id.name == arrowObj)
            {
                obj.commandNumber += 1;
                ClearArrowBlock();
                CreateArrowBlock();
            }
        }
    }
}
