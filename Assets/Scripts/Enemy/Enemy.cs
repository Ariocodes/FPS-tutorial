using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Path path;



    // animations
    public Animator legAnimator;
    public Animator armAnimator;
    private bool wasMoving;

    // ONLY FOR DEBUGGING PURPOSES
    [SerializeField]
    private string currentState;


    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
    }



    void Update()
    {
        UpdateMovementAnimation();
    }


    // updating animation from idle to walking based on enemy movement.
    public void UpdateMovementAnimation()
    {
        bool isMoving = agent.velocity.magnitude > 0.1f;
        if(isMoving != wasMoving)
        {
            legAnimator.Play(isMoving ? "legsAnimation" : "Idle");
            armAnimator.Play(isMoving ? "armsAnimation" : "Idle");
            wasMoving = isMoving;
        }
        
    }
}
