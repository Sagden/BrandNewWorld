﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StopScript : MonoBehaviour
{
    public bool _banOnStopClick = false;
    private Animation anim;
    public Button stopButton;

    void Start()
    {
        stopButton = transform.GetComponent<Button>();
        anim = GetComponent<Animation>();

        stopButton.onClick.AddListener(ClickOnButton);
        AllEventList.Instance.firstPlayerOnFinishFloor.AddListener(BanOnStopClick);
    }


    void ClickOnButton()
    {
        if (!_banOnStopClick)
        {
            Destroy(AllObjectList.Instance.bluePlayerObj);
            Destroy(AllObjectList.Instance.redPlayerObj);
            Destroy(GameObject.Find("PlayerParent(Clone)"));
            Destroy(GameObject.Find("PlayerParent(Clone)"));

            AllEventList.Instance.stopButtonClick.Invoke();
            
            AllObjectList.Instance.firstRobotStartFloor.GetComponent<StartFloorScript>().InitPlayer();
            AllObjectList.Instance.secondRobotStartFloor.GetComponent<StartFloorScript>().InitPlayer();
            AllObjectList.Instance.buttonPlayBlue.GetComponent<PlayPauseScript>().WalkingPaused();
            AllObjectList.Instance.buttonPlayRed.GetComponent<PlayPauseScript>().WalkingPaused();
        }
    }

    void BanOnStopClick()
    {
        _banOnStopClick = true;
    }

    public void Shake()
    {
        anim.Play();
    }
}
