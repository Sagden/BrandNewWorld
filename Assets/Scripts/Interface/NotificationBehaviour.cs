using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationBehaviour : MonoBehaviour
{
    void Update()
    {
        if (!gameObject.GetComponent<Animation>().isPlaying)
        {
            Delete();
        }
    }

    void Delete()
    {
        GameObject.Destroy(gameObject);
    }
}
