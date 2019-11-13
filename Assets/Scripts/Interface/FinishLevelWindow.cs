using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelWindow : MonoBehaviour
{
    void Start()
    {
        AllEventList.Instance.bluePlayerOnFinishFloor.AddListener(ShowFinishLevelUI);
        gameObject.SetActive(false);
    }

    void ShowFinishLevelUI()
    {
        gameObject.SetActive(true);
    }
}
