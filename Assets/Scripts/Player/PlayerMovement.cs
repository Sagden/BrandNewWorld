using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : Player
{
    public string myFinishFloorName;
    public UnityEvent FinishPlayerMovement, StartPlayerMovement;

    public GameObject CurrentCommand { get; set; }
    public bool Pause { get; set; }

    public void StartMovement()
    {
        if (IsListHaveBlock()) // Проверка не пустой ли список
        {
            CurrentCommand = MyMovingBlockScript.allCommands[CurrentStep];

            StartPlayerMovement.Invoke();
            
            Invoke("CheckCommandType", 1.1f / AllGlobalVariable.Instance.overallSpeed);
            ReshapeBlocks(CurrentCommand);
        }
        else
        {
            FinishPlayerMovement.Invoke();
        }
    }
    public void Step() //Сделать шаг
    {
        var direction = CurrentCommand.GetComponent<ArrowScript>().Dir;

        if (CollisionPointWith("Floor", direction) && !CollisionPointWith("SolidBarrier", direction)) //есть ли пол?
        {
            myPlayersSolidBlock.transform.position = gameObject.transform.position + direction;
            gameObject.transform.parent.transform.position = gameObject.transform.position;

            GetComponent<PlayerMovementAnimation>().RunAnimation(CurrentCommand.GetComponent<ArrowScript>().AnimClip);
            
            Invoke("CheckCommandType", 1.1f / AllGlobalVariable.Instance.overallSpeed);
        }
        else
        {
            CurrentStep += 1;
            StartMovement();
        }
    } 
    public void JumpToCommand(GameObject obj)
    {
        CurrentStep = MyMovingBlockScript.allCommands.IndexOf(obj.GetComponent<JumpBlockInitialization>().IdArrowFinish);
        StartMovement();
    }
    void EmptyCommand()
    {
        CurrentStep += 1;
        StartMovement();
    }

    void CheckCommandType()
    {
        Iam.GetComponent<PlayerReactionOnFloor>().CheckFloorType(); // Проверить какой тип пола под игроком

        if (!Pause)
        { 
            switch (CurrentCommand.GetComponent<ActionBlockAbstract>().TypeParent)
            {
                case TypeBlock.Step:
                    Step();
                    break;
                case TypeBlock.Jump:
                    JumpToCommand(CurrentCommand);
                    break;
                case TypeBlock.Empty:
                    EmptyCommand();
                    break;
            }
        }
    }
    void OnDestroy()
    {
        Destroy(myPlayersSolidBlock);
    }
}