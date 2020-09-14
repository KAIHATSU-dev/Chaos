
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public LayerMask whatisground, whatisplayer;

    public GameObject projectile;

    public float health;

    public Vector3 walkpoint;
    bool walkpointSet;
    public float walkpointrange;


    public float timebetweenattacks;
    bool alreadyattacked;


    public float sightrange, attackrange;
    public bool playerinsightrange, playerinattackrange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatisplayer);

        if (!playerinattackrange && !playerinsightrange) Patrolling();
        if (playerinsightrange && !playerinattackrange) Chase();
        if (playerinattackrange && playerinsightrange) Attack();
    }
    
    private void Patrolling()
    {
        if (walkpointSet) Destination();
        if (walkpointSet)
            agent.SetDestination(walkpoint);
        
        Vector3 distancetowalkpoint = transform.position - walkpoint;

        if (distancetowalkpoint.magnitude < 1f)
            walkpointSet = false;
    }

    private void Destination()
    {
        float randomZ = Random.Range(-walkpointrange, walkpointrange);
        float randomX = Random.Range(-walkpointrange, walkpointrange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatisground))

        walkpointSet = true;
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyattacked)
        {
            ///Attack here this is just for example!!
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///The attack code ends here

            alreadyattacked = true;
            Invoke(nameof(ResetAttack), timebetweenattacks);
        }
    }
    
    private void ResetAttack()
    {
        alreadyattacked = false;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
