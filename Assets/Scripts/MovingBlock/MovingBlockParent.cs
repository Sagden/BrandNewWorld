using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingBlockParent : MonoBehaviour
{
    public List<GameObject> showArrows;

    
    public void ClearList() //очистить коллекцию
    {
        for(int i = 0; i < showArrows.Count; i++)
        {
            Destroy(showArrows[i]);
        }
        showArrows.Clear();
    }
}
