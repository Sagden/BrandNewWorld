using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFloorScript : StartFloorParent
{
    public GameObject player;
    public GameObject playerParent;

    void Awake()
    {
        InitPlayer();
    }



    public override void InitPlayer()
    {
        var objParrent = Instantiate(playerParent, gameObject.transform.position, Quaternion.identity);
        var obj = Instantiate(player, new Vector3(objParrent.transform.position.x, objParrent.transform.position.y, -1), Quaternion.identity, objParrent.transform);

        if (player.name == "PlayerBlue")
        {
            AllObjectList.Instance.bluePlayerObj = obj;
        }
        else
        if (player.name == "PlayerRed")
        {
            AllObjectList.Instance.redPlayerObj = obj;
        }

    }
}
