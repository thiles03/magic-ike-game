using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Reference the object's Animator and Sound  Controller
    private Animator characterAnimator;
    private SoundController soundController;

    private bool footstepSounds = false;

    void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();
        soundController = GetComponent<SoundController>();
    }

    //Walk
    public void MoveAnimationStart()
    {
        characterAnimator.SetBool("isMoving", true);
        soundController.Footsteps();
        footstepSounds = true;
    }
    
    public void MoveAnimationStop()
    {
        characterAnimator.SetBool("isMoving", false);

        //Check if footsteps are playing and stop
        if (footstepSounds)
        {
            soundController.StopSounds();
            footstepSounds = false;
        }
    }

    //Attack
    public void AttackAnimation()
    {
        characterAnimator.SetTrigger("attack01");
        soundController.Attack();
    }

    //Hit
    public void HitAnimation()
    {
        characterAnimator.SetTrigger("hit");
        soundController.GetHit();
    }

    //Die
    public void DieAnimation()
    {
        characterAnimator.SetBool("isDead", true);
        soundController.Dead();
    }
}


