
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Animator animator;

    public void takeDamage (float amount){
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Update()
    {
        animator = animator.GetComponent<Animator>();
    }

    void Die(){
        animator.SetBool("death", true);
        return;
    }
}
