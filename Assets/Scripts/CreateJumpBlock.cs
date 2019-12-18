using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJumpBlock : MonoBehaviour
{
    [SerializeField] private GameObject arrowDecoration;
    [SerializeField] private GameObject arrowFinish;
    private GameObject idArrow;
    private GameObject idArrowFinish;

    public GameObject IdArrow { get => idArrow; }
    public GameObject IdArrowFinish { get => idArrowFinish; set => idArrowFinish = value; }

    public void CreateNewJumpBlock()
    {
        idArrow = Instantiate(arrowDecoration, 
                            new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), 
                            Quaternion.identity);
        idArrow.GetComponent<ArrowDecorationBehaviour>().ParentID = gameObject.transform;

        IdArrowFinish = Instantiate(arrowFinish, transform.position, Quaternion.identity, gameObject.transform.parent);

        GetComponentInParent<MovingBlockScript>().allCommands.Add(IdArrowFinish);
    }
}
