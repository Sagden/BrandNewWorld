using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingBlockScrollingParent : MonoBehaviour
{
    public Vector3 mouseCoordinateStart;
    public float movingBlockCoordinateXStart;
    public Vector3 coordinateDifference;
    public float difference;


    public abstract void Scrolling();

    public void OffsetAddArrow(GameObject arrow)
    {
        difference = 0;

        if (arrow.transform.position.x+0.6f > AllObjectList.Instance.buttonPlayBlue.transform.position.x)
        {
            var offset = AllObjectList.Instance.buttonPlayBlue.transform.position.x - (arrow.transform.position.x+0.6f);
            Debug.Log(offset);
            gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera.x += offset;
        }
    }
}
