using UnityEngine.InputSystem;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private Animator animator;

    private void OnEnabale()
    {
        move.action.started += AnimateLegs;
        move.action.canceled += StopAnimation;
    }

    private void OnDisable()
    {
        move.action.started -= AnimateLegs;
        move.action.canceled -= StopAnimation;
    }

    private void AnimateLegs(InputAction.CallbackContext obj)
    {
        bool isMovingForword = move.action.ReadValue<UnityEngine.Vector2>().y > 0;

        if (isMovingForword)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("AnimationSpeed", 1);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("AnimationSpeed", -1);
        }
    }

    private void StopAnimation(InputAction.CallbackContext obj)
    {
        animator.SetBool("isWalking", false);
        animator.SetFloat("AnimationSpeed", 0);
    }
}
