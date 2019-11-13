using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StartFloorParent : MonoBehaviour
{ 

    public GameObject CreatePlayer(GameObject player, GameObject playerParent)
    {
        var objParrent = Instantiate(playerParent, gameObject.transform.position, Quaternion.identity);
        var obj = Instantiate(player, new Vector3(objParrent.transform.position.x, objParrent.transform.position.y, -1), Quaternion.identity, objParrent.transform);

        return obj;
    }
}
