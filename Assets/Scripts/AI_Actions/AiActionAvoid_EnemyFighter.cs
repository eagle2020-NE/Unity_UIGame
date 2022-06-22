using UnityEngine;
using Arman.AI;
using System;
using Arman.Decisions;

namespace Arman.Actions
{
    public class AiActionAvoid_EnemyFighter : AIAction
    {

        public float maxspeed;


        AiActionPatrolling_EnemyFighter patrolling;
        AiDecisionPatrolToFight FightDecision;

        private float accspeed = 20f;
        private Vector3 inversepos;


        public bool isavoid;

        public bool repatrol;


        public override void OnEnterState()
        {
            print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }

        public override void OnExitState()
        {
            
        }

        public override void PerformAction()
        {
            Avoid();

            patrolling.movetotarget();
        }

        protected override void Initialization()
        {
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
            FightDecision = GetComponent<AiDecisionPatrolToFight>();
        }

        public void Avoid()
        {
            if (patrolling.AIspeed < maxspeed)
            {
                patrolling.AIspeed += Time.deltaTime * accspeed;
            }
            if (!isavoid)
            {
                inversepos = FightDecision.targetTrans.InverseTransformPoint(patrolling.m_transform.position);
                patrolling.curTargetPos = FightDecision.targetTrans.position + Mathf.Sign(inversepos.x) * FightDecision.targetTrans.right * FightDecision.FightDistance * 1f + Mathf.Sign(inversepos.y) * Vector3.up * FightDecision.FightDistance * 0.2f - Mathf.Sign(inversepos.z) * FightDecision.targetTrans.forward * FightDecision.FightDistance * 0.2f;

                if (patrolling.curTargetPos.y < 450f || patrolling.curTargetPos.y > 2000f)
                {
                    patrolling.curTargetPos.y = UnityEngine.Random.Range(4, 11) * 200;
                }
                if (Mathf.Abs(patrolling.curTargetPos.x - patrolling.centerpoint.x) > (float)patrolling.flyrange_AI)
                {
                    patrolling.curTargetPos.x = (float)(UnityEngine.Random.Range(-6, 7) * 200) + patrolling.centerpoint.x;
                }
                if (Mathf.Abs(patrolling.curTargetPos.z - patrolling.centerpoint.z) > (float)patrolling.flyrange_AI)
                {
                    patrolling.curTargetPos.z = (float)(UnityEngine.Random.Range(-6, 7) * 200) + patrolling.centerpoint.z;
                }

                isavoid = true;
                repatrol = false;
            }
            
        }
    }
}

