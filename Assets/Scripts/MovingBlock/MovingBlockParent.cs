using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingBlockParent : MonoBehaviour
{
    public List<GameObject> allArrows;
    void Start()
    {
        AllEventList.Instance.stopButtonClick.AddListener(
            delegate { gameObject.GetComponentInParent<SelectBlockInMovingBlock>().AllBlockToActive(allArrows); }
            );
    }

    void AllBlockToActive()
    {
        
    }

}
