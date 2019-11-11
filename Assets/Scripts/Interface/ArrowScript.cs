using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowScript : ActionBlockAbstract
{
    public UnityEvent thisArrowSelect = new UnityEvent();
    public GameObject arrowPrefab;
    public GameObject notificationPrefab, notification;

    public bool canCreateArrowAtClick = true;
    
    void Awake()
    {
        notification = Instantiate(notificationPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, -1), Quaternion.identity);

    }

    void OnMouseDown()
    {
        if (!banOnArrowDrag)
        {
            canCreateArrowAtClick = true;
            Invoke("CanCreateArrowAtClick", 0.3f);
            selectArrow = gameObject;
            prefabObject = Instantiate(arrowPrefab, new Vector3(0,0,-1), transform.rotation);
            thisArrowSelect.AddListener(AddArrowToMovingBlock);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            thisArrowSelect.Invoke();
            thisArrowSelect.RemoveAllListeners();
        }
    }

    public override void AddArrowToMovingBlock()
    {
        if ((CollisionMouseWith("MovingBlock")) && AllObjectList.Instance.playPauseScript.status == "Play") // || (canCreateArrowAtClick == true)
            {
                CollisionMouseWith("MovingBlock").GetComponent<MovingBlockScript>().AddArrow(selectArrow);
            }
            
        Destroy(prefabObject);
        selectArrow = null;
    }

    void OnDestroy()
    {
        Destroy(notification);
    }

    void CanCreateArrowAtClick()
    {
        canCreateArrowAtClick = false;
    }
}
