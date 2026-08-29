using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;


    public void Initialize()
    {
        ChangeState(new PatrolState());
    }

    void Start() { }
    void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        // check activeState != null
        if (activeState != null)
        {
            activeState.Exit();
        }
        // change to a new state
        activeState = newState;

        // fail-safe null check to make sure new state wasn't null
        if (activeState != null)
        {
            // setup new state.
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
