using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MovingBlockScript : MovingBlockParent
{
    public List<string> allArrows;
    public List<GameObject> showArrows;
    public GameObject testArrow;
    public Animation _animation;
    public GameObject playObj;
    private string myName;
    private float myOffset;

    void Awake()
    {
        myName = gameObject.name;
        _animation = gameObject.GetComponent<Animation>();

        if (myName == "MovingBlockBlue")
        {
            myOffset = -3.18f;
            playObj = GameObject.Find("ButtonPlayBlue");
        }
        else
        if (myName == "MovingBlockRed")
        {
            myOffset = -2.2f;
            playObj = GameObject.Find("ButtonPlayRed");
        }

    }
    void Start()
    {
            gameObject.GetComponent<BehaviorLikeUI>().coordinateRelativeCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y+myOffset) - Camera.main.transform.position; 
    }


    public void AddArrow(GameObject arrow)
    {
        allArrows.Add(arrow.name);
        RefreshMovingBlock();
        AllObjectList.Instance.createArrow.ArrowBlockCountChangedMinus(arrow);
    }

    public void DeleteArrow(GameObject deleteObj)
    {
        var index = showArrows.IndexOf(deleteObj);

        AllObjectList.Instance.createArrow.ArrowBlockCountChangedPlus(allArrows[index]);

        allArrows.RemoveAt(index);
        showArrows.RemoveAt(index);

        

        Destroy(deleteObj);

        RefreshMovingBlock();
    }

    public void RefreshMovingBlock()
    {
        ClearList();
        DrawingArrowOnMovingBlock();
    }


    void ClearList()
    {
        for(int i = 0; i < showArrows.Count; i++)
        {
            Destroy(showArrows[i]);
        }

        showArrows.Clear();
    }

    void DrawingArrowOnMovingBlock()
    {
        for(int i = 0; i < allArrows.Count; i++)
        {
            var offset = i * 0.7f;
            var obj = Instantiate(testArrow, new Vector3(transform.position.x-2+offset, Camera.main.transform.position.y+myOffset, -1), Quaternion.identity, gameObject.transform);
            var objScript = obj.GetComponent<ArrowTestScript>();

            if (i+1 == allArrows.Count) //перемещение камеры в movingblock к последнему элементу
                AllObjectList.Instance.movingBlockScrolling.OffsetAddArrow(obj);

            switch (allArrows[i])
            {
                case "ArrowRight(Clone)": 
                obj.transform.rotation = new Quaternion(0,0,0,0); 
                objScript.set(new Vector2(0.5f, 0), _animation.GetClip("PlayerAnimationRight")); 
                break;

                case "ArrowUp(Clone)": 
                obj.transform.rotation = new Quaternion(0,0,1,1); 
                objScript.set(new Vector2(0, 0.5f), _animation.GetClip("PlayerAnimationUp")); 
                break;

                case "ArrowLeft(Clone)": 
                obj.transform.rotation = new Quaternion(0,0,1,0); 
                objScript.set(new Vector2(-0.5f, 0), _animation.GetClip("PlayerAnimationLeft")); 
                break;
                
                case "ArrowDown(Clone)": 
                obj.transform.rotation = new Quaternion(0,0,1,-1); 
                objScript.set(new Vector2(0, -0.5f), _animation.GetClip("PlayerAnimationDown")); 
                break; 
            }
            showArrows.Add(obj);
        }
    }
}
