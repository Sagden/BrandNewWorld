using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllEventList : MonoBehaviour
{
    public static AllEventList Instance {get; set;}
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
//----------------------- SINGLETONE---------------------------//


    public UnityEvent firstPlayerOnFinishFloor = new UnityEvent();
    public UnityEvent speedSliderIsChanged = new UnityEvent();
    public UnityEvent walkingFinished = new UnityEvent(); // Когда прошел все команды
    public UnityEvent startMovingEvent = new UnityEvent(); //ГГ сменил команду из списка (сменил направление или начал идти)
    public UnityEvent stopButtonClick = new UnityEvent(); // Была нажата кнопка стоп
    //public UnityEvent firstPlayerIsCreate = new UnityEvent(); // Игрок 1 был созда или пересоздан
}
