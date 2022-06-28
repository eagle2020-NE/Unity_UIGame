using UnityEngine;

public class PlaneMoveController : MonoBehaviour
{
	#region Var


	public static PlaneMoveController instance;
	public Transform m_transform;
	public Transform bodypoint;
	public float speed;
	public float TakeoffSpeed;
	public float rotation_base_x = 100f;
	public float rotation_base_y = 150f;
	public AnimationCurve rotateCurve;
	public float body_rotation_z = 100f;


	private float rotationx;
	private float divesalto;
	private float rightleftsoftabs;
	private float diveblocker;
	private float rotationz;
	//private Joystick joyStick;

	#endregion

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	private void OnDestroy()
	{
		if (instance != null)
		{
			instance = null;
		}
	}

    public void android_controller()
    {
        //rotationx = m_transform.eulerAngles.x;
        //rotationz = bodypoint.localEulerAngles.z;
        //if (speed > TakeoffSpeed * 0.75f)
        //{
        //    if (joyStick.Vertical <= 0f)
        //    {
        //        m_transform.Rotate(joyStick.Vertical * Time.deltaTime * rotation_base_x, 0f, 0f);
        //    }
        //    if (joyStick.Vertical > 0f)
        //    {
        //        m_transform.Rotate((0.8f - divesalto) * joyStick.Vertical * Time.deltaTime * rotation_base_x, 0f, 0f);
        //    }
        //}
        //m_transform.Rotate(0f, Time.deltaTime * rotation_base_y * rotateCurve.Evaluate(joyStick.Horizontal), 0f, Space.World);
        //bodypoint.transform.Rotate(0f, 0f, Time.deltaTime * body_rotation_z * (1f - rightleftsoftabs - diveblocker) * joyStick.Horizontal * -1f, Space.Self);
    }


}
