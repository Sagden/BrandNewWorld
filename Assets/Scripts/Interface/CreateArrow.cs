using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class BoolArrowCheck
{
    public int arrowNumber;
    public GameObject arrow;
    public GameObject id;
    public string idName;
}

public class CreateArrow : MonoBehaviour
{
    public List<BoolArrowCheck> arrowList;

    void Start()
    {
        RefreshArrowBlock();
    }

    public void RefreshArrowBlock()
    {
        ClearArrowBlock();

        var offset = 0f;

        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.arrowNumber > 0)
            {
                obj.id = Instantiate(obj.arrow, new Vector3(Camera.main.transform.position.x-2+offset, Camera.main.transform.position.y-4.1f, -1), obj.arrow.transform.rotation, gameObject.transform);
                obj.id.GetComponent<ArrowScript>().notification.GetComponentInChildren<Transform>().GetComponentInChildren<TextMesh>().text = obj.arrowNumber.ToString();
                obj.idName = obj.id.name;
                offset += 0.7f;
            }
        }
    }

    public void ClearArrowBlock()
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            //if (obj.arrowNumber == 0 && obj.id != null)
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
            if (obj.id == arrowObj && obj.arrowNumber > 0)
            {
                obj.arrowNumber -= 1;
                RefreshArrowBlock();
            }
        }
    }

    public void ArrowBlockCountChangedPlus(string arrowObj)
    {
        foreach(BoolArrowCheck obj in arrowList)
        {
            if (obj.idName == arrowObj)
            {
                obj.arrowNumber += 1;
                RefreshArrowBlock();
            }
        }
    }
}
