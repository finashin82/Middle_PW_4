using UnityEngine;

public class RandomAnimationZombi : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();       
    }
}
