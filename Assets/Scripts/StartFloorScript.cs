using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFloorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerParent;
    public Event playerBorn;

    void Start()
    {
        InitPlayer();
    }



    public void InitPlayer()
    {
        var obj = Instantiate(playerParent, gameObject.transform.position, Quaternion.identity);
        AllObjectList.Instance.firstPlayerObj = Instantiate(player, new Vector3(obj.transform.position.x, obj.transform.position.y, -1), Quaternion.identity, obj.transform);
        AllObjectList.Instance.playerWalking = AllObjectList.Instance.firstPlayerObj.GetComponent<PlayerWalking>();
        AllObjectList.Instance.playerReactionOnFloor = AllObjectList.Instance.firstPlayerObj.GetComponent<PlayerReactionOnFloor>();
        AllObjectList.Instance.playerSpriteDrawing = AllObjectList.Instance.firstPlayerObj.GetComponent<PlayerSpriteDrawing>();

        AllEventList.Instance.firstPlayerIsCreate.Invoke();
        //AllObjectList.Instance.playPauseScript.PlayerInit();
    }
}
