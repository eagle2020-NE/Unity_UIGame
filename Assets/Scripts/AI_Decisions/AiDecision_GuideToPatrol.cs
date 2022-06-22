using Arman.AI;
using UnityEngine;
using Arman.Actions;

namespace Arman.Decisions
{
    public class AiDecision_GuideToPatrol : AIDecision
    {

        AiActionPatrolling_EnemyFighter patrolling;
        public Transform targetTrans;
        AiAction_Guide guide;

        public override bool Decide()
        {
            print("guide to patrol distance > 100 : " + Vector3.Distance(patrolling.m_transform.position, patrolling.curTargetPos));
            //print("guide to patrol angle : " + Vector3.Angle(guide.inversepos, Vector3.forward));

            guide.inversepos = targetTrans.InverseTransformPoint(patrolling.curTargetPos);
            if (Vector3.Distance(patrolling.m_transform.position, patrolling.curTargetPos) > 100f)// || Vector3.Angle(guide.inversepos, Vector3.forward) > 10f)
            {
                return true;
            }
            else
                return false;
            

        }

        public override void Initialization()
        {
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
            if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            {
                targetTrans = GameObject.FindGameObjectWithTag("Player").transform;
            }
            guide = GetComponent<AiAction_Guide>();
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
        }

        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}

