using Arman.AI;
using UnityEngine;
using Arman.Actions;

namespace Arman.Decisions
{
    public class AiDecision_patrolToGuide : AIDecision
    {

        public Transform targetTrans;

        AiAction_Guide guide;
        AiActionPatrolling_EnemyFighter patrolling;

        public override bool Decide()
        {
            print("patrol to guide distance < 100 : " + Vector3.Distance(patrolling.m_transform.position, patrolling.curTargetPos));
            guide.inversepos = targetTrans.InverseTransformPoint(patrolling.curTargetPos);

            if (Vector3.Distance(patrolling.m_transform.position, patrolling.curTargetPos) < 100f)// || Vector3.Angle(guide.inversepos, Vector3.forward) < 10f)
            {
                return true;
            }
            else
                return false;
        }

        public override void Initialization()
        {
            if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            {
                targetTrans = GameObject.FindGameObjectWithTag("Player").transform;
            }
            guide = GetComponent<AiAction_Guide>();
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
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
