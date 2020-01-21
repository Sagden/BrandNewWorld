using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ArrowScriptEmpty : ActionBlockAbstract
{
    private UnityEvent thisArrowSelect = new UnityEvent();
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] protected TypeBlock type;

    [SerializeField] private Vector3 dir;

    public AnimationClip AnimationClipComponent { get; set; }
    public Vector3 Dir { get => dir; set => dir = value; }
    internal TypeBlock Type { get => type; set => type = value; }

    void Awake()
    {
        Init();
    }
    void Init()
    {
        TypeParent = type;
        
        //if (gameObject.GetComponent<Animation>() != null)
            AnimationClipComponent = gameObject.GetComponent<Animation>()?.clip;
    }

    void OnMouseDown()
    {
        if (!MyHeroIsStarted())
        {
            thisArrowSelect.AddListener(PutThisEmptyBlock);

            prefabObject = Instantiate(arrowPrefab, new Vector3(0,0,-0.5f), transform.rotation);
            prefabObject.GetComponent<SpriteRenderer>().sprite = prefabObject.GetComponent<ArrowPrefab>().arrowJumpSprite;
        }
    }

    void PutThisEmptyBlock()
    {
        var list = GetComponentInParent<MovingBlockScript>().allCommands;
        var mouseCoordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (collisionEventsComponent.CollisionWithObj(gameObject.transform.parent.gameObject))
            foreach (GameObject obj in list)
            {
                var i = list.IndexOf(obj);
                var t = list.IndexOf(gameObject);

                if (mouseCoordinate.x < obj.transform.position.x)
                {
                    if (mouseCoordinate.x < gameObject.transform.position.x)
                    {
                        list.RemoveAt(t);
                        list.Insert(i, gameObject);
                    }
                    else
                    if (mouseCoordinate.x > gameObject.transform.position.x)
                    {
                        list.RemoveAt(t);
                        list.Insert(i-1, gameObject); 
                    }

                    GetComponentInParent<MovingBlockScript>().DrawingArrowOnMovingBlock();
                    break;
                }
                else
                if (mouseCoordinate.x > list[list.Count-1].transform.position.x)
                {
                    list.RemoveAt(t);
                    list.Add(gameObject); 

                    GetComponentInParent<MovingBlockScript>().DrawingArrowOnMovingBlock();
                    break;
                }

                
            }
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            thisArrowSelect.Invoke();
            thisArrowSelect.RemoveAllListeners();

            Destroy(prefabObject);
        }
    }
}
