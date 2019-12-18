using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaScrolling : MonoBehaviour
{
    private bool gameAreaScrollingOn = false;
    private bool banOnScroll = false;
    private Vector3 startMouseCoordinate;
    private Vector3 startCameraCoordinate;
    [SerializeField] private Vector3 differentMouseCoordinate;

    void Start()
    {
        AllEventList.Instance.allPlayersOnFinishFloor.AddListener(BanOnScroll);
        gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y+5.9f) - Camera.main.transform.position;
    }

    void FixedUpdate()
    {
        if (gameAreaScrollingOn && !banOnScroll)
            Scrolling();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            gameAreaScrollingOn = false;
    }

    void OnMouseDown()
    {
        startMouseCoordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startCameraCoordinate = Camera.main.transform.position;

        gameAreaScrollingOn = true;
    }
    void BanOnScroll()
    {
        banOnScroll = true;
    }
    void Scrolling()
    {
        differentMouseCoordinate = (startMouseCoordinate - Camera.main.ScreenToWorldPoint(Input.mousePosition)) / 3;

        Camera.main.transform.position = new Vector3(
            startCameraCoordinate.x + differentMouseCoordinate.x, 
            startCameraCoordinate.y + differentMouseCoordinate.y, 
            -10);
    }
}
