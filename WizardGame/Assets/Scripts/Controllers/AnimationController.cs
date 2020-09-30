using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator characterAnimator;
    private SoundController soundController;
    private bool footstepSounds = false;

    void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();
        soundController = GetComponent<SoundController>();
    }

    public void MoveAnimationStart()
    {
        characterAnimator.SetBool("isMoving", true);
        soundController.Footsteps();
        footstepSounds = true;
    }
    
    public void MoveAnimationStop()
    {
        characterAnimator.SetBool("isMoving", false);
        if (footstepSounds)
        {
            soundController.StopSounds();
            footstepSounds = false;
        }
    }

    public void AttackAnimation()
    {
        characterAnimator.SetTrigger("attack01");
        soundController.Attack();
    }

    public void HitAnimation()
    {
        characterAnimator.SetTrigger("hit");
        soundController.GetHit();
    }

    public void DieAnimation()
    {
        characterAnimator.SetBool("isDead", true);
        soundController.Dead();
    }
}


