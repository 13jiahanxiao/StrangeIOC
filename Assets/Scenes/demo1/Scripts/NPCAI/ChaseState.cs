using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    public ChaseState(GameObject npc, GameObject player):base(npc,player)
    {
        _StateId = StateId.Chase;
    }
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        Debug.Log("Chase");
    }

    public override void DoUpdate()
    {
        CheckTransition();
        ChaseMove();
    }
    public override void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) >= 5)
        {
            fsm.ProfermTransiton(Transition.LostPlayer);
        }
    }
    public void ChaseMove()
    {
        Vector3 traget = player.transform.position;
        npcRb.velocity = npc.transform.forward * 3;
        npc.transform.LookAt(player.transform.position);
    }
}
