using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelWindow : MonoBehaviour
{
    private GameObject finishFloor;

    void Start()
    {
        finishFloor = GameObject.Find("BlueRobotFinishFloor");

        AllEventList.Instance.bluePlayerOnFinishFloor.AddListener(delegate { Invoke("ShowFinishLevelUI", 0.3f); });
        gameObject.SetActive(false);
    }

    void ShowFinishLevelUI()
    {
        
        finishFloor.GetComponent<Animation>().Play();

        //gameObject.SetActive(true);
    }
}
