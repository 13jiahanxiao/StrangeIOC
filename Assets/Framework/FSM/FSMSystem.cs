using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem
{
    public Dictionary<StateId, FSMState> states;
    private FSMState _CurrentState;
    public FSMState CurrentState
    {
        get { return _CurrentState; }
    }
    public FSMSystem(){
        states = new Dictionary<StateId,FSMState>();
    }
    public void AddState(FSMState state)
    {
        if (state == null)
        {
            return;
        }
        if (states.ContainsKey(state.State))
        {
            return;
        }
        state.fsm=this;
        states.Add(state.State, state);
    }
    public void DeleteState(FSMState state)
    {
        //安全检查
        states.Remove(state.State);
    }
    public void ProfermTransiton(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            return;
        }
        StateId id = CurrentState.GetOutputState(trans);
        if (id == StateId.NullStateId)
        {
            return;
        }
        FSMState state;
        states.TryGetValue(id, out state);
        CurrentState.DoBeforeLeaving();
        _CurrentState = state;
        CurrentState.DoBeforeEntering();
    }

    public void Start(StateId id)
    {
        FSMState state;
        if(states.TryGetValue(id, out state))
        {
            state.DoBeforeEntering();
            _CurrentState = state;
        }
        else
        {
            //no exist
            return;
        }
    }
}
