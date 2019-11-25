using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteDrawing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteUp;
    public Sprite spriteDown;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void SetSprite(int currentStepIndex)
    {
        switch (gameObject.GetComponent<PlayerWalking>().MyMovingBlock.GetComponent<MovingBlockScript>().allArrows[currentStepIndex])
            {
                case "ArrowRight(Clone)": 
                    spriteRenderer.sprite = spriteRight;
                break;

                case "ArrowUp(Clone)": 
                    spriteRenderer.sprite = spriteUp;
                break;

                case "ArrowDown(Clone)": 
                    spriteRenderer.sprite = spriteDown;
                break;

                case "ArrowLeft(Clone)": 
                    spriteRenderer.sprite = spriteLeft;
                break;
            }
    }
}
