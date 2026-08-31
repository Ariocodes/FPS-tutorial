using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private bool wasMoving;

    [Header("AI Navigation")]
    public NavMeshAgent Agent { get => agent; }
    public Path path;

    public GameObject Player {  get => player; }

    // animations
    public Animator legAnimator;
    public Animator armAnimator;




    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;





    // ONLY FOR DEBUGGING PURPOSES
    [SerializeField]
    [Header("DEBUGGING")]
    private string currentState;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        UpdateMovementAnimation();
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }





    // updating animation from idle to walking based on enemy movement.
    public void UpdateMovementAnimation()
    {
        bool isMoving = agent.velocity.magnitude > 0.1f;
        if(isMoving != wasMoving)
        {
            legAnimator.Play(isMoving ? "legsAnimation" : "Idle");


            bool isAttacking = stateMachine.activeState is AttackState;
            bool isHolstering = armAnimator.GetCurrentAnimatorStateInfo(0).IsName("HolsterWeapon");

            if (!isAttacking && !isHolstering)
            {
                armAnimator.Play(isMoving ? "armsAnimation" : "Idle");
            }
            wasMoving = isMoving;
        }
    }

    public bool CanSeePlayer()
    {
        if(player != null)
        {
            // is the player close enough to be seen?
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                // is the player within the field of view of enemy?
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);



                    RaycastHit hitInfo = new RaycastHit();

                    // is enemy's sight blocked by any object?
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }



                }
            }
        }



        return false;
    }




}
