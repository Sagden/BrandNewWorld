using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INotification
{
    void ShowNotification(Sprite iconSprite, Transform parent);
}


public class Notifications : MonoBehaviour, INotification
{
    public void ShowNotification(Sprite iconSprite, Transform parent)
    {
        var notification = Instantiate(AllObjectList.Instance.notificationObj,
                                       new Vector3(parent.transform.position.x, parent.transform.position.y, 0),
                                       Quaternion.identity,
                                       parent);
        notification.GetComponent<SpriteRenderer>().sprite = iconSprite;
    }
}
