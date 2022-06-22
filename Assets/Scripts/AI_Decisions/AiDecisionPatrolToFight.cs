using Arman.AI;
using UnityEngine;


namespace Arman.Decisions
{
    public class AiDecisionPatrolToFight : AIDecision
    {
        public Transform targetTrans;
        public float FightDistance;

        public override bool Decide()
        {
            if (targetTrans.gameObject != null)
            {
                print(Vector3.Distance(transform.position, targetTrans.position));
            }
            
            return CanFight();
        }



        public override void Initialization()
        {
            if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            {
                targetTrans = GameObject.FindGameObjectWithTag("Player").transform;
            }
            
        }

        public override void OnEnterState()
        {
            

        }

        private bool CanFight()
        {

            if (targetTrans.gameObject != null && Vector3.Distance(transform.position, targetTrans.position) < FightDistance)
                return true;
            else
                return false;
                    

        }



    }
}

