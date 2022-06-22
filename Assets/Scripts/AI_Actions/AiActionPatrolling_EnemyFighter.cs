using UnityEngine;
using Arman.AI;
using System;

namespace Arman.Actions
{

	public class AiActionPatrolling_EnemyFighter : AIAction
	{
		public Transform m_transform;
		public Vector3 curTargetPos;
		public float AIspeed;
		public Vector3 centerpoint;
		public int flyrange_AI = 4000;
		public Vector3 patrolpoint;
		public float patroldis;
		public Vector3 tempdir;
		public float rotatediss;
		public float curangleZ;
		public Transform bodyself;
		public float maxangleZ = 45f;

		private Vector3 tempcaldir;
		private int calangle;
		private Vector3 tempcalpos;

		/// <summary>
		/// update in AIBrain 
		/// </summary>
		public override void PerformAction()
		{
			print("PPPPPPPPPPPPPPPPPPPPPPPPPPPPPP");


			Patrolling();
			movetotarget();
		}

		protected override void Initialization()
		{
			
			patrolpoint = m_transform.position;
			curTargetPos = patrolpoint;
			bodyself.localRotation = Quaternion.Euler(0f, 0f, 0f);

		}

		public override void OnEnterState()
		{
			
		}
		public override void OnExitState()
		{
			
		}
		private void Patrolling()
		{

			if (Vector3.Distance(m_transform.position, curTargetPos) <= AIspeed)
			{
				curTargetPos = getRandomPoint();

				if (curTargetPos.y < 450f || curTargetPos.y > 2000f)
				{
					curTargetPos.y = UnityEngine.Random.Range(4, 11) * 200;
				}
				if (Mathf.Abs(curTargetPos.x - centerpoint.x) > (float)flyrange_AI)
				{
					curTargetPos.x = (float)(UnityEngine.Random.Range(-6, 7) * 200) + centerpoint.x;
				}
				if (Mathf.Abs(curTargetPos.z - centerpoint.z) > (float)flyrange_AI)
				{
					curTargetPos.z = (float)(UnityEngine.Random.Range(-6, 7) * 200) + centerpoint.z;
				}
			}
		}

		public Vector3 getRandomPoint()
		{
			tempcaldir = m_transform.position - patrolpoint;
			tempcaldir.y = 0f;
			calangle = (calangle + UnityEngine.Random.Range(45, 100)) % 360;
			tempcaldir = new Vector3(Mathf.Cos((float)calangle * ((float)Math.PI / 180f)), 0f, Mathf.Sin((float)calangle * ((float)Math.PI / 180f)));
			tempcalpos = patrolpoint + -tempcaldir * patroldis + Vector3.up * UnityEngine.Random.Range(-30, 30);
			return tempcalpos;
		}

		public void movetotarget()
		{
			m_transform.Translate(0f, 0f, AIspeed * Time.deltaTime);
			tempdir = m_transform.InverseTransformPoint(curTargetPos);
			m_transform.rotation = Quaternion.Slerp(m_transform.rotation, Quaternion.LookRotation(curTargetPos - m_transform.position), Time.deltaTime * rotatediss);
			curangleZ = bodyself.localEulerAngles.z;
			if (Mathf.Abs(tempdir.x) > 50f)
			{
				curangleZ = Mathf.LerpAngle(curangleZ, (0f - tempdir.x) / Mathf.Abs(tempdir.x) * maxangleZ, Time.deltaTime * 2f);
			}
			else
			{
				curangleZ = Mathf.LerpAngle(curangleZ, (0f - tempdir.x) / 50f * maxangleZ, Time.deltaTime * 2f);
			}
			bodyself.localRotation = Quaternion.Euler(0f, 0f, curangleZ);
		}

	}
}

