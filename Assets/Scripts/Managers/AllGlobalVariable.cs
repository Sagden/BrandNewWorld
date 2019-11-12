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

    public static float overallSpeed = 1.5f;
    public static bool heroBlueStartedWalking = false;
    public static bool heroRedStartedWalking = false;

    void Start()
    {
        heroBlueStartedWalking = false;
        heroRedStartedWalking = false;

        AllEventList.Instance.startMovingEventBlue.AddListener(delegate {heroBlueStartedWalking = true;});
        AllEventList.Instance.startMovingEventRed.AddListener(delegate {heroRedStartedWalking = true;});

        AllEventList.Instance.stopButtonClick.AddListener(delegate {heroBlueStartedWalking = false;});
        AllEventList.Instance.stopButtonClick.AddListener(delegate {heroRedStartedWalking = false;});
    }
}
