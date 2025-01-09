using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private IState currentState;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeState(IState state)
    {
        if (currentState != null && state.GetType() == this.currentState.GetType()) return;

        if (currentState != null) currentState.Exit();
        currentState = state;

        if (currentState != null) currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) currentState.Execute();
    }
}
