using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTestScript : MonoBehaviour
{
    [SerializeField]private bool canDelete = true;
    private CollisionEvents collisionEvents;
    private bool playerIsStop = true;
    public SpriteRenderer spriteRenderer;
    public GameObject currentPlayer;

    void Start()
    {
        collisionEvents = GetComponent<CollisionEvents>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Init();

        currentPlayer.GetComponent<PlayerMovement>().StartPlayerMovement.AddListener(ChangeColor);
        currentPlayer.GetComponent<PlayerMovement>().FinishPlayerMovement.AddListener(ChangeColorOnWhite);
        AllEventList.Instance.stopButtonClick.AddListener(ChangeColorOnWhite);
        AllEventList.Instance.stopButtonClick.AddListener(Init);
    }

    void OnMouseDown()
    {
        Invoke("ChangeCanDeleteStatus", 0.2f);
    }

    void OnMouseUp()
    {
        if (canDelete)
        {
            {
                AllObjectList.Instance.stopScript.Shake();
            }
        }
        canDelete = true;
    }

    void ChangeColor()
    {
        spriteRenderer.color = new Color32(110,110,110,255);

        currentPlayer.GetComponent<PlayerMovement>().CurrentCommand.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }

    void ChangeColorOnWhite()
    {
        spriteRenderer.color = new Color32(255,255,255,255);
    }

    void Init()
    {
        if (collisionEvents.CollisionWithTag("MovingBlock", transform.position).name == "MovingBlockBlue(Clone)")
        {
            currentPlayer = AllObjectList.Instance.bluePlayerObj;
        }
        else
        if (collisionEvents.CollisionWithTag("MovingBlock", transform.position).name == "MovingBlockRed(Clone)")
        {
            currentPlayer = AllObjectList.Instance.redPlayerObj;
        }
    }
}