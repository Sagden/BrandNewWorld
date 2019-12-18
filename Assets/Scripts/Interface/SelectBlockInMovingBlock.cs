using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISelectableBlockInMovingBlock
{
    void SelectingBlockInMovingBlock(List<GameObject> commands, GameObject currentBlock);
}
public class SelectBlockInMovingBlock : MonoBehaviour, ISelectableBlockInMovingBlock
{
    void Start()
    {
        AllEventList.Instance.stopButtonClick.AddListener(
            delegate { gameObject.GetComponentInParent<SelectBlockInMovingBlock>().AllBlockToActive(
                AllObjectList.Instance.movingBlockBlue.GetComponent<MovingBlockScript>().allCommands
            );});
        if (AllObjectList.Instance.redPlayerObj != null)
            AllEventList.Instance.stopButtonClick.AddListener(
                delegate { gameObject.GetComponentInParent<SelectBlockInMovingBlock>().AllBlockToActive(
                    AllObjectList.Instance.movingBlockRed.GetComponent<MovingBlockScript>().allCommands
                );});
    }
    public void SelectingBlockInMovingBlock(List<GameObject> commands, GameObject currentBlock)
    {
        foreach (GameObject obj in commands)
        {
            if (obj == currentBlock)
            {
                ChangeStatusOnEnable(obj);
            }
            else
            {
                ChangeStatusOnDisable(obj);
            }
        }
    }

    public void AllBlockToActive(List<GameObject> commands)
    {
        foreach(GameObject obj in commands)
        {
            if (obj.GetComponent<ActionBlockAbstract>().showStatus == false)
            {
                obj.GetComponent<Animation>()["ReshapeBlockAnimation"].speed = -1;
                obj.GetComponent<Animation>()["ReshapeBlockAnimation"].time = obj.GetComponent<Animation>()["ReshapeBlockAnimation"].length;
                obj.GetComponent<Animation>().Play("ReshapeBlockAnimation");
                obj.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);

                obj.GetComponent<ActionBlockAbstract>().showStatus = true;
            }
        }
    }
    void ChangeStatusOnEnable(GameObject obj)
    {
        if (obj.GetComponent<ActionBlockAbstract>().showStatus == false)
        {
            obj.GetComponent<Animation>()["ReshapeBlockAnimation"].speed = -1;
            obj.GetComponent<Animation>()["ReshapeBlockAnimation"].time = obj.GetComponent<Animation>()["ReshapeBlockAnimation"].length;
            obj.GetComponent<Animation>().Play("ReshapeBlockAnimation");
            obj.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);

            obj.GetComponent<ActionBlockAbstract>().showStatus = true;
        }
    }
    void ChangeStatusOnDisable(GameObject obj)
    {
        if (obj.GetComponent<ActionBlockAbstract>().showStatus == true)
        {
            obj.GetComponent<Animation>()["ReshapeBlockAnimation"].speed = 1;
            obj.GetComponent<Animation>().Play("ReshapeBlockAnimation");
            obj.GetComponent<SpriteRenderer>().color = new Color32(200,200,200,255);

            obj.GetComponent<ActionBlockAbstract>().showStatus = false;
        }
    }
}
