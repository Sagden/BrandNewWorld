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
    public UnityEvent walkingFinishedBlue = new UnityEvent(); // Когда прошел все команды
    public UnityEvent walkingFinishedRed = new UnityEvent(); // Когда прошел все команды
    public UnityEvent startMovingEventBlue = new UnityEvent(); //ГГ сменил команду из списка (сменил направление или начал идти)
    public UnityEvent startMovingEventRed = new UnityEvent(); //ГГ сменил команду из списка (сменил направление или начал идти)
    public UnityEvent stopButtonClick = new UnityEvent(); // Была нажата кнопка стоп
    public UnityEvent playersIsCreate = new UnityEvent(); // Игрок 1 был созда или пересоздан
}
