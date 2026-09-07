using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    private int searchPoints;

    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnownPlayerPosition);
        searchPoints = enemy.searchPoints;
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance * 10)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(2, 4) && searchPoints > 0)
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
                searchPoints--;
            }
            if(searchTimer > enemy.losePlayerTime && searchPoints <= 0)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
        
    }
}
