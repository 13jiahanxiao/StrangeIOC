using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] wayPoint;
    public GameObject npc;
    public GameObject player;
    //int transitionDis = 5;
    FSMSystem fsm;
    void Start()
    {
        InitFSM();
    }
    void InitFSM()
    {
        fsm = new FSMSystem();

        PatrolState patrol = new PatrolState(wayPoint, npc, player);
        patrol.AddTransition(Transition.SawPlayer, StateId.Chase);

        ChaseState chase = new ChaseState(npc, player);
        chase.AddTransition(Transition.LostPlayer, StateId.Patrol);

        fsm.AddState(patrol);
        fsm.AddState(chase);

        fsm.Start(StateId.Patrol);
    }
    void Update()
    {
        fsm.CurrentState.DoUpdate();

    }
    /*利用状态机在一个脚本里转换
     * public void CheckCondition()
    {
        if (CheckTrans() && fsm.CurrentState.State == StateId.Patrol)
        {
            fsm.ProfermTransiton(Transition.SawPlayer);
        }
        if (!CheckTrans() && fsm.CurrentState.State == StateId.Chase)
        {
            fsm.ProfermTransiton(Transition.LostPlayer);
        }
    }
    public bool CheckTrans()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) < transitionDis)
        {
            return true;
        }
        return false;
    }*/
}
