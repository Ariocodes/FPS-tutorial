using UnityEngine;

public class AttackState : BaseState
{

    private float moveTimer;
    private float losePlayerTimer;
    [SerializeField]
    private float waitBeforeSearchTime = 8; // time to stay in attack state when lost sight of player
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > waitBeforeSearchTime)
            {
                // Change to search state.
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

}
