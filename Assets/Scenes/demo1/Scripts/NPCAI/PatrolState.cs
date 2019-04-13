using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState :FSMState
{
    Transform[] wayPoint;
    int target;
    public PatrolState(Transform[] wayPoint,GameObject npc,GameObject player):base(npc,player)
    {
        _StateId = StateId.Patrol;
        this.wayPoint = wayPoint;
    }
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        Debug.Log("start Entering");
    }

    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }
    public override void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
        {
            fsm.ProfermTransiton(Transition.SawPlayer);
        }
    }
    public void PatrolMove()
    {
        npcRb.velocity = npc.transform.forward * 3;
        Vector3 targetPosition = wayPoint[target].position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(wayPoint[target].position);
        if (Vector3.Distance(npc.transform.position, wayPoint[target].position) < 0.01)
        {
            target++;
            target %= wayPoint.Length;
        }
    }
}
 