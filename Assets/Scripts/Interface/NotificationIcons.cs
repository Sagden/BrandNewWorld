using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationIcons : MonoBehaviour
{
    [SerializeField] private Sprite iconWall;
    [SerializeField] private Sprite iconRobot;

    public Sprite IconWall { get => iconWall; }
    public Sprite IconRobot { get => iconRobot; }
}