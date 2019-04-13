using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Transition
{
    NullTransition,
    SawPlayer,
    LostPlayer
}

public enum StateId
{
    NullStateId,
    Patrol,
    Chase
}

public abstract class FSMState  {
    protected StateId _StateId;
    public StateId State
    {
        get { return _StateId; }
    }
    protected Dictionary<Transition, StateId> map = new Dictionary<Transition, StateId>();
    public FSMSystem fsm;
    
    public GameObject player;
    public GameObject npc;
    public Rigidbody npcRb;
    public FSMState(GameObject npc,GameObject player)
    {
        this.player = player;
        this.npc = npc;
        npcRb = this.npc.GetComponent<Rigidbody>();
    }
    public void AddTransition(Transition trans,StateId id)
    {
        //检验是否包含和是否有状态和条件
        if (map.ContainsKey(trans))
        {
            Debug.LogError(id);
        }
        map.Add(trans, id);
    }
    public void DeleteTransition(Transition trans)
    {
        //安全检验
        map.Remove(trans);
    }
    public StateId GetOutputState(Transition trans)
    {//根据条件判断是否发生转换
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateId.NullStateId;
    }
    public virtual void DoBeforeEntering()
    {

    }
    public virtual void DoBeforeLeaving()
    {

    }
    public abstract void DoUpdate();
    public abstract void CheckTransition();
}
