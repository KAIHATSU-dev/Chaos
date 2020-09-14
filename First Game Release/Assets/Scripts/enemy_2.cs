using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Timers;


public class enemy_2 : MonoBehaviour
{
    private NavMeshAgent Mob;

    public Animator animator;
    private bool attacking  = false;
    private float deathdelay = 3000f;
    public float health = 50f;
    

    public GameObject Player;

    public float MobDistanceRun = 6.0f;

    public float AttackDistance = 6.0f;
    



    

    void Start()
    {
        animator = GetComponent<Animator>();
        Mob = GetComponent<NavMeshAgent>();
        

    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        

        if (distance < MobDistanceRun)
        {
           follow();           
        }
        

        
        if (distance < AttackDistance)
        {
            attack();
        }
     
    
    }
    void follow()
    {
         Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);
            
            animator.SetBool("FP", true);
    }
    void attack()
    {
        attacking = !attacking;
        animator.SetBool("attack", attacking);
    }
        public void takeDamage (float amount){
        health -= amount;
        if (health <= 0f)
        {
            StartCoroutine(death());
        }
    }
 
    IEnumerator death()
    {
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


}
