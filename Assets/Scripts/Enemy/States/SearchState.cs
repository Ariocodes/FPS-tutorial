using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;

    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnownPlayerPosition);
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            if(searchTimer > enemy.losePlayerTime)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
        
    }
}
