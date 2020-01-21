using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockManager : MonoBehaviour
{
    public GameObject movingBlockBlue, movingBlockRed;

    void OnEnable()
    {
            AllObjectList.Instance.movingBlockBlue = Instantiate(movingBlockBlue, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            

            if (AllObjectList.Instance.redRobotStartFloor != null)
            {
                AllObjectList.Instance.movingBlockRed = Instantiate(movingBlockRed, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            }
            else
            {
                GameObject.Destroy(AllObjectList.Instance.buttonPlayRed);
            }
    }

    void Start()
    {
        AllObjectList.Instance.buttonPlayBlue.SetActive(true);
        AllObjectList.Instance.buttonPlayRed.SetActive(true);

        MovingBlockBlueInit();
        if (AllObjectList.Instance.redRobotStartFloor != null)
            MovingBlockRedInit();
    }

    void MovingBlockBlueInit()
    {
        var blue = AllObjectList.Instance.movingBlockBlue.GetComponent<MovingBlockScript>();
            blue.myOffset = -3.18f;
            blue.playPauseStatus = AllObjectList.Instance.buttonPlayBlue.GetComponent<PlayPauseBlue>().status;
            blue.myMovingBlock = AllObjectList.Instance.movingBlockBlue;
    }
    void MovingBlockRedInit()
    {
        var red = AllObjectList.Instance.movingBlockRed.GetComponent<MovingBlockScript>();
            red.myOffset = -2.2f;
            red.playPauseStatus = AllObjectList.Instance.buttonPlayRed.GetComponent<PlayPauseRed>().status;
            red.myMovingBlock = AllObjectList.Instance.movingBlockRed;
    }
}
