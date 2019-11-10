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
    public static bool heroStartedWalking = false;

    void Start()
    {
        heroStartedWalking = false;

        AllEventList.Instance.startMovingEvent.AddListener(delegate {heroStartedWalking = true;});
        AllEventList.Instance.stopButtonClick.AddListener(delegate {heroStartedWalking = false;});
    }
}
