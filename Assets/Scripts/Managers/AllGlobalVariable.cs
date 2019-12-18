using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGlobalVariable : MonoBehaviour
{
    public static AllGlobalVariable Instance {get; set;}

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
//----------------------- SINGLETONE---------------------------//

    public float overallSpeed = 1.5f;

    private bool heroBlueStartedWalking = false;
    public bool HeroBlueStartedWalking { get => heroBlueStartedWalking; set => heroBlueStartedWalking = value; }
    
    private bool heroRedStartedWalking = false;
    public bool HeroRedStartedWalking { get => heroRedStartedWalking; set => heroRedStartedWalking = value; }

    private  bool bluePlayerOnFinishFloor;
    public  bool BluePlayerOnFinishFloor { get => bluePlayerOnFinishFloor; set => bluePlayerOnFinishFloor = value; }

    private bool redPlayerOnFinishFloor;
    public bool RedPlayerOnFinishFloor { get => redPlayerOnFinishFloor; set => redPlayerOnFinishFloor = value; }

    private  bool allObjectsOnFinishFloor;
    public bool AllObjectsOnFinishFloor { get => allObjectsOnFinishFloor; set => allObjectsOnFinishFloor = value; }

    void Start()
    {
        AllEventList.Instance.startMovingEventBlue.AddListener(delegate {HeroBlueStartedWalking = true;});
        AllEventList.Instance.startMovingEventRed.AddListener(delegate {HeroRedStartedWalking = true;});

        AllEventList.Instance.stopButtonClick.AddListener(delegate {HeroBlueStartedWalking = false;});
        AllEventList.Instance.stopButtonClick.AddListener(delegate {HeroRedStartedWalking = false;});
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Blue: " + bluePlayerOnFinishFloor);
            Debug.Log("Red: " + redPlayerOnFinishFloor);
        }
    }
}
