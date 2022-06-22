using Arman.AI;
using UnityEngine;
using Arman.Actions;

namespace Arman.Decisions
{
    public class AiDecisionFightToAvoid : AIDecision
    {

        AiDecisionPatrolToFight patrolToFight;
        AiActionPatrolling_EnemyFighter patrolling;
        AiActionAvoid_EnemyFighter avoid;

        public override bool Decide()
        {
            print("can avoid : " + CanAvoid());
            return CanAvoid();
        }



        public override void Initialization()
        {
            patrolToFight = GetComponent<AiDecisionPatrolToFight>();
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
            avoid = GetComponent<AiActionAvoid_EnemyFighter>();

        }

        public override void OnEnterState()
        {


        }


        public bool CanAvoid()
        {
            if (Vector3.Distance(patrolling.m_transform.position, patrolToFight.targetTrans.position) < patrolToFight.FightDistance * 0.2f || patrolling.m_transform.position.y < 450f)
            {
                avoid.isavoid = false;
                avoid.repatrol = true;
                return true;
            }            
            else return false;

            if (Mathf.Abs(patrolling.curTargetPos.x - patrolling.centerpoint.x) > (float)patrolling.flyrange_AI || Mathf.Abs(patrolling.curTargetPos.z - patrolling.centerpoint.z) > (float)patrolling.flyrange_AI || patrolling.m_transform.position.y < 450f)
            {
                avoid.isavoid = false;
                avoid.repatrol = true;
                return true;
            }
            else return false;
        }


    }
}