using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : Player
{
    public Animation AnimationComponent { get; set; }

    void Start()
    {
        AnimationComponent = GetComponent<Animation>();
    }

    public void RunAnimation(AnimationClip _anim)
    {
        AnimationComponent.AddClip(_anim, _anim.name);
        AnimationComponent[_anim.name].speed = AllGlobalVariable.Instance.overallSpeed / 1f;
        AnimationComponent.Play(_anim.name);
    }
}
