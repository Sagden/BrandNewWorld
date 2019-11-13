using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockManager : MonoBehaviour
{
    public GameObject movingBlockBlue, movingBlockRed;

    void Awake()
    {
        
        AllObjectList.Instance.movingBlockBlue = Instantiate(movingBlockBlue, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        

        if (GameObject.Find("RedRobotStartFloor"))
        {
            AllObjectList.Instance.movingBlockRed = Instantiate(movingBlockRed, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
    }

    void Start()
    {
        AllObjectList.Instance.buttonPlayBlue.SetActive(true);

        if (GameObject.Find("RedRobotStartFloor"))
        {
            AllObjectList.Instance.buttonPlayRed.SetActive(true);
        }
        else
        {
            GameObject.Destroy(AllObjectList.Instance.buttonPlayRed);
        }
    }
}
