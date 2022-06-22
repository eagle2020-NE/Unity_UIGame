using UnityEngine;

public class JDController : MonoBehaviour
{
	public Vector3 pos;

	public Vector3 rot;

	public void setpos()
	{
		base.transform.localPosition = pos;
		base.transform.localRotation = Quaternion.Euler(rot);
	}
}
