using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Command //Отдельно взятая команда
{
    public int commandNumber;
    public GameObject command;
    public GameObject id;
}

public class CommandStorage : MonoBehaviour // Хранилище и показ команд для использования
{
    public List<Command> commandStorageList;

    void Start()
    {
        DrawingCommands();
    }

    public void DrawingCommands()
    {
        var offset = 0.5f;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        foreach(Command obj in commandStorageList)
        {
            if (obj.commandNumber > 0)
            {
                obj.id = Instantiate(obj.command, new Vector3(leftBorder.x+offset, Camera.main.transform.position.y-4.1f, -1), obj.command.transform.rotation, gameObject.transform);
                obj.id.GetComponent<ActionBlockAbstract>().Notification.GetComponentInChildren<Transform>().GetComponentInChildren<TextMesh>().text = obj.commandNumber.ToString();
                offset += 0.7f;
                
            }
            
        }
    }

    public void ClearShownCommands()
    {
        foreach(Command obj in commandStorageList)
        {
            if (obj.id != null)
            if (obj.id.GetComponent<ActionBlockAbstract>().IamInMovingBlock)
            {
                Destroy(obj.id.GetComponent<ActionBlockAbstract>().Notification);
            }
            else
            if (obj.id != null)
            {
                Destroy(obj.id);
            }
        }
    }

    public void DeleteCommandFromCommandStorage(GameObject arrowObj)
    {
        foreach(Command obj in commandStorageList)
        {
            if (obj.id != null)
            if (obj.id == arrowObj && obj.commandNumber > 0)
            {
                obj.commandNumber -= 1;
                ClearShownCommands();
                DrawingCommands();
            }
        }
    }

    public void AddCommandToCommandStorage(GameObject arrowObj)
    {
        foreach(Command obj in commandStorageList)
        {
            if (obj.id != null)
            if (obj.id.name == arrowObj.name)
            {
                obj.commandNumber += 1;
                ClearShownCommands();
                DrawingCommands();
            }
        }
    }
}
