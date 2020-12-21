using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterMovementController characterMovement;
    CharacterAnimationController characterAnimation;
    CharacterCombat characterCombat;
    Health health;

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovementController>();
        characterAnimation = GetComponent<CharacterAnimationController>();
        characterCombat = GetComponent<CharacterCombat>();
        health = GetComponent<Health>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetCharacterState();

        if(Input.GetMouseButton(0) && 
        characterMovement.movementState != CharacterMovementController.MovementStates.Jumping)
        {
            StartCoroutine(AttackOrder());
        }
    }

    private void SetCharacterState()
    {
        if (characterCombat.isAttacking)
            return;
        if (characterMovement.IsGrounded())
        {
            if (rigidBody2D.velocity.x == 0)
            {
                characterMovement.SetMovementState(CharacterMovementController.MovementStates.Idle);
            }
            else if (rigidBody2D.velocity.x > 0)
            {
                characterMovement.facingDirection = CharacterMovementController.FacingDirection.Right;
                characterMovement.SetMovementState(CharacterMovementController.MovementStates.Running);
            }
            else if (rigidBody2D.velocity.x < 0)
            {
                characterMovement.facingDirection = CharacterMovementController.FacingDirection.Left;
                characterMovement.SetMovementState(CharacterMovementController.MovementStates.Running);
            }
        }
        else
        {
            characterMovement.SetMovementState(CharacterMovementController.MovementStates.Jumping);
        }
    }

    private IEnumerator AttackOrder()
    {
        if (characterCombat.isAttacking)
            yield break;
        
        characterCombat.isAttacking = true;
        
        characterMovement.movementState = CharacterMovementController.MovementStates.Attacking;

        characterAnimation.TriggerAttackAnimation();

        yield return new WaitForSeconds(0.8f);

        characterCombat.Attack();

        characterCombat.isAttacking = false;
        
        yield break;
    }

}
