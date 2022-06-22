using UnityEngine;
using Arman.AI;
using System;
using Arman.Decisions;

namespace Arman.Actions
{
    public class AiActionFighting_EnemyFighter : AIAction
    {

        AiActionPatrolling_EnemyFighter patrolling;
        AiDecisionPatrolToFight FightDecision;

        private float accspeed = 20f;

        public float normalspeed;
        public float ShootAngle;
        public AAPod aaPod;



        public override void OnEnterState()
        {
            print("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }

        public override void PerformAction()
        {
            Fight();

            patrolling.movetotarget();
        }

        protected override void Initialization()
        {
            patrolling = GetComponent<AiActionPatrolling_EnemyFighter>();
            FightDecision = GetComponent<AiDecisionPatrolToFight>();
        }


        public void Fight()
        {
            if (patrolling.AIspeed > normalspeed)
            {
                patrolling.AIspeed -= Time.deltaTime * accspeed;
                //print(patrolling.AIspeed);
            }

            patrolling.curTargetPos = FightDecision.targetTrans.position;

            if (Vector3.Angle(patrolling.m_transform.forward, FightDecision.targetTrans.position - patrolling.m_transform.position) < ShootAngle )//&& Vector3.Distance(transform.position, FightDecision.targetTrans.position) < FightDecision.FightDistance * 0.4f)
            {
                aaPod.Launch(FightDecision.targetTrans);
            }


        }





    }
}

