using UnityEngine;

public class RandomAnimationZombi : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        //animator.SetFloat("randAnim", Random.Range(0.0f, 1.0f));
    }
}
