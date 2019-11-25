using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseRed : MonoBehaviour
{
    public Button button;
    public GameObject player;
    public PlayerWalking playerScript;
    public string status;

    void Awake()
    {
        status = "Play";

        gameObject.SetActive(false);
    }

    void Start()
    {
        PlayerInit();

        button = transform.GetComponent<Button>();

        button.onClick.AddListener(ClickOnButton);
        playerScript.myEventFinish.AddListener(WalkingFinished);
        AllEventList.Instance.playersIsCreate.AddListener(PlayerInit);
    }

//--------------------------------------------------------------------------------------------//

    void ClickOnButton()
    {
        if (status == "Play" && !playerScript.AnimationPlayer.isPlaying)
        {
            status = "Pause";
            gameObject.GetComponent<Image>().sprite = AllObjectList.Instance.pauseButtonSprite;

            playerScript.Pause = false;
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
        PlayerInit();
        playerScript.Pause = true;
        status = "Play";
        gameObject.GetComponent<Image>().sprite = AllObjectList.Instance.playButtonSprite;
    }



    public void PlayerInit()
    {
        playerScript = AllObjectList.Instance.redPlayerObj.GetComponent<PlayerWalking>();
    }

}
