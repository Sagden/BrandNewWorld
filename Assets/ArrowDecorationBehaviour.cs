using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDecorationBehaviour : MonoBehaviour
{

    public Transform ParentID { get; set; }
    void Update()
    {
        gameObject.transform.position = new Vector3(ParentID.position.x, ParentID.position.y+0.28f, -5);
    }
}
