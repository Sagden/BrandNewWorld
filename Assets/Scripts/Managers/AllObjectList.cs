﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectList : MonoBehaviour
{
    public static AllObjectList Instance {get; private set;}
//----------------------- SINGLETONE---------------------------//
    public GameObject actionBlock;
    public CreateArrow createArrow;

    public GameObject slider;
    public SliderScript sliderScript;
    
    public GameObject buttonPlayBlue;
    public GameObject buttonPlayRed;
    public PlayPauseScript playPauseScript;

    public GameObject buttonStop;
    public StopScript stopScript;

    public GameObject firstRobotStartFloor;
    public GameObject secondRobotStartFloor;

    public GameObject finishLevelUI;

    public GameObject playArea;
    public GameAreaScrolling gameAreaScrolling;

    public GameObject bluePlayerObj; //создается чуть позже
    public GameObject redPlayerObj; //создается чуть позже


    public GameObject movingBlockBlue;
    public GameObject movingBlockRed;
    public MovingBlockScript movingBlockScript;
    public MovingBlockScrolling movingBlockScrolling;

    public GameObject behavior;

    public Sprite playButtonSprite;
    public Sprite pauseButtonSprite;
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Application.targetFrameRate = 60;

        //Объявление объектов
        slider = GameObject.Find("Slider");
        actionBlock = GameObject.Find("ActionBlock");
        playArea = GameObject.Find("PlayArea");
        buttonPlayBlue = GameObject.Find("ButtonPlayBlue");
        buttonPlayRed = GameObject.Find("ButtonPlayRed");
        buttonStop = GameObject.Find("ButtonStop");
        finishLevelUI = GameObject.Find("FinishLevelUI");
        behavior = GameObject.Find("Behavior");
        movingBlockBlue = GameObject.Find("MovingBlockBlue");
        movingBlockRed = GameObject.Find("MovingBlockRed");
        firstRobotStartFloor = GameObject.Find("FirstRobotStartFloor");
        secondRobotStartFloor = GameObject.Find("SecondRobotStartFloor");
    


        // Объявление скриптов
        createArrow = actionBlock.GetComponent<CreateArrow>();
        sliderScript = slider.GetComponent<SliderScript>();
        gameAreaScrolling = playArea.GetComponent<GameAreaScrolling>();
        stopScript = buttonStop.GetComponent<StopScript>();
    }
}
