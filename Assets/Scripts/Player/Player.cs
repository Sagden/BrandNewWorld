using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Player : MonoBehaviour
{
    protected GameObject myPlayersSolidBlock;

    public GameObject MyMovingBlock { get; set; }
    public MovingBlockScript MyMovingBlockScript { get; set; }
    public GameObject Iam { get; set; }
    public int CurrentStep { get; set; }

    void Start()
    {
        myPlayersSolidBlock = Instantiate(AllObjectList.Instance.playersSolidBlock, transform.position, Quaternion.identity);
    }

    public bool IsListHaveBlock() // Проверяет есть ли команды для выполнения
    {
        return MyMovingBlockScript.allCommands.Count > CurrentStep;
    }
    public bool CollisionPointWith(string tag, Vector3 direction) //Проверяет объект с тегом tag в точке direction
    {
        return Physics2D.OverlapPointAll(transform.position + direction)?.Any(s => s.tag == tag)?? false;
    }
    public void ReshapeBlocks(GameObject CurrentBlock) // Выделяет выполняемый блок, остальные уменьшает и затемняет
    {
        ISelectableBlockInMovingBlock reshapeBlock = MyMovingBlock.GetComponentInParent<SelectBlockInMovingBlock>();
        reshapeBlock.SelectingBlockInMovingBlock(MyMovingBlockScript.allCommands, CurrentBlock);
    }
}
