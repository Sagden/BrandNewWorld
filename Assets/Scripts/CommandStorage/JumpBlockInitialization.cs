using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlockInitialization : MonoBehaviour
{
    [SerializeField] private GameObject arrowDecoration;
    [SerializeField] private GameObject arrowFinish;
    private GameObject idArrowFinish;

    public GameObject IdArrow { get; set; }
    public GameObject IdArrowFinish { get => idArrowFinish; set => idArrowFinish = value; }

    public void CreateNewJumpBlock()
    {
        //IdArrow = Instantiate(arrowDecoration, 
        //                    new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), 
        //                    Quaternion.identity);
        //IdArrow.GetComponent<ArrowDecorationBehaviour>().ParentID = gameObject.transform;

        IdArrowFinish = Instantiate(arrowFinish, transform.position, Quaternion.identity, gameObject.transform.parent);

        GetComponentInParent<MovingBlockScript>().allCommands.Add(IdArrowFinish);
    }
}
