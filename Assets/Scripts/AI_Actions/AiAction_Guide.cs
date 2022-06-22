using UnityEngine;
using Arman.AI;
using System;
using Arman.Decisions;

namespace Arman.Actions
{

    public class AiAction_Guide : AIAction
    {

        public Vector3 inversepos;

        AiDecision_GuideToPatrol PatrolDecision;
        AiActionPatrolling_EnemyFighter patrolling;

        public override void OnEnterState()
        {
            
        }

        public override void OnExitState()
        {
            
        }

        public override void PerformAction()
        {
            print("GGGGGGGGGGGGGGGGGGGGGG");
            Guide();
            patrolling.movetotarget();
        }

        private void Guide()
        {
            inversepos = PatrolDecision.targetTrans.InverseTransformPoint(patrolling.m_transform.position);
            if (Vector3.Angle(inversepos, Vector3.forward) > 10f)
            {
                patrolling.AIspeed = 150f;
            }
            else if (Vector3.Distance(patrolling.m_transform.position, PatrolDecision.targetTrans.position) < 100f)
            {
                patrolling.AIspeed = patrolling.AIspeed + 10f;
            }
            else
            {
                patrolling.AIspeed = patrolling.AIspeed - 10f;
            }
        }

        protected override void Initialization()
        {
            PatrolDecision = GetComponent<AiDecision_GuideToPatrol>();
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
        }
    }
}

