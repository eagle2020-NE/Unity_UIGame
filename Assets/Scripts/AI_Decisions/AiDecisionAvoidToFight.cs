using Arman.AI;
using UnityEngine;
using Arman.Actions;

namespace Arman.Decisions
{
    public class AiDecisionAvoidToFight : AIDecision
    {

        AiActionPatrolling_EnemyFighter patrolling;
        AiDecisionPatrolToFight patrolToFight;
        AiActionAvoid_EnemyFighter avoid;


        public override bool Decide()
        {
            return CanFighting();
        }

        public override void Initialization()
        {
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
            patrolToFight = GetComponent<AiDecisionPatrolToFight>();
            avoid = GetComponent<AiActionAvoid_EnemyFighter>();
        }

        public override void OnEnterState()
        {
            
        }

        public override void OnExitState()
        {
            
        }

        public bool CanFighting()
        {
            if (Vector3.Distance(patrolling.m_transform.position, patrolling.curTargetPos) < patrolling.AIspeed && !avoid.repatrol)
            {
                avoid.repatrol = true;
                return true;
            }
            else return false;

            if (Vector3.Distance(patrolling.m_transform.position, patrolToFight.targetTrans.position) > patrolToFight.FightDistance * 1.2f)
                return true;
            else return false;
        }
    }
}

