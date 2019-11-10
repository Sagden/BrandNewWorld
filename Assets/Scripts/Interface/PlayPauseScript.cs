using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseScript : MonoBehaviour
{
    public Button button;
    public GameObject player;
    public PlayerWalking playerScript;
    public string status;

    void Start()
    {
        status = "Play";

        playerScript = AllObjectList.Instance.playerWalking;

        button = transform.GetComponent<Button>();


        button.onClick.AddListener(ClickOnButton);
        AllEventList.Instance.walkingFinished.AddListener(WalkingFinished);
        AllEventList.Instance.firstPlayerIsCreate.AddListener(PlayerInit);
    }

//--------------------------------------------------------------------------------------------//

    void ClickOnButton()
    {
        if (status == "Play" && !playerScript._animation.isPlaying)
        {
            status = "Pause";
            gameObject.GetComponent<Image>().sprite = AllObjectList.Instance.pauseButtonSprite;

            playerScript.pause = false;
            playerScript.StartMoving();
        }
        else
            if (status == "Pause")
                WalkingPaused();
    }

    void WalkingFinished()
    {
        status = "Play";
        gameObject.GetComponent<Image>().sprite = AllObjectList.Instance.playButtonSprite;
    }
    public void WalkingPaused()
    {
        playerScript.pause = true;
        status = "Play";
        gameObject.GetComponent<Image>().sprite = AllObjectList.Instance.playButtonSprite;
    }



    public void PlayerInit()
    {
        playerScript = AllObjectList.Instance.playerWalking;
    }

}
