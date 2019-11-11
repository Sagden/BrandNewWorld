using System.Collections;
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
    
    public GameObject buttonPlay;
    public PlayPauseScript playPauseScript;

    public GameObject buttonStop;
    public StopScript stopScript;

    public GameObject startFloor;
    public StartFloorScript startFloorScript;

    public GameObject finishLevelUI;

    public GameObject playArea;
    public GameAreaScrolling gameAreaScrolling;

    public GameObject firstPlayerObj; //создается чуть позже
    public PlayerWalking playerWalking;
    public PlayerReactionOnFloor playerReactionOnFloor;
    public PlayerSpriteDrawing playerSpriteDrawing;

    public GameObject movingBlockBlue;
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
        buttonPlay = GameObject.Find("ButtonPlay");
        buttonStop = GameObject.Find("ButtonStop");
        finishLevelUI = GameObject.Find("FinishLevelUI");
        behavior = GameObject.Find("Behavior");
        movingBlockBlue = GameObject.Find("MovingBlockBlue");
        startFloor = GameObject.Find("StartFloor");
    


        // Объявление скриптов
        createArrow = actionBlock.GetComponent<CreateArrow>();
        sliderScript = slider.GetComponent<SliderScript>();
        gameAreaScrolling = playArea.GetComponent<GameAreaScrolling>();
        playPauseScript = buttonPlay.GetComponent<PlayPauseScript>();
        stopScript = buttonStop.GetComponent<StopScript>();
        startFloorScript = startFloor.GetComponent<StartFloorScript>();
        movingBlockScript = movingBlockBlue.GetComponent<MovingBlockScript>();
        movingBlockScrolling = movingBlockBlue.GetComponent<MovingBlockScrolling>();
    }
}
