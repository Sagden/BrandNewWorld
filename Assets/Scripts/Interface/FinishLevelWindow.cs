using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelWindow : MonoBehaviour
{
    void Start()
    {
        AllEventList.Instance.allPlayersOnFinishFloor.AddListener(delegate { Invoke("ShowFinishLevelUI", 1); });
        gameObject.SetActive(false);
    }

    void ShowFinishLevelUI()
    {
        gameObject.SetActive(true);
    }
}
