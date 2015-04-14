using UnityEngine; 
using System.Collections;

public class Xbox360CameraController : MonoBehaviour {
	
	public float sticksSensitivity = 2F;
	public float triggersSensitivity = 1F;
	
	float mHdg = 0F;
	float mPitch = 0F;
	
	void Start()
	{
		//
	}
	
	void Update()
	{
		float translateX = Input.GetAxis("JoyLeft X") * sticksSensitivity;
		float translateY = Input.GetAxis("Triggers") * triggersSensitivity;
		float translateZ = -Input.GetAxis("JoyLeft Y") * sticksSensitivity;
		float rotateX = Input.GetAxis("JoyRight X") * sticksSensitivity;
		float rotateY = Input.GetAxis("JoyRight Y") * sticksSensitivity;

		Strafe(translateX);
		ChangeHeight(translateY);
		MoveForwards(translateZ);
		ChangeHeading(rotateX);
		ChangePitch(rotateY);
	}
	
	void MoveForwards(float aVal)
	{
		Vector3 fwd = transform.forward;
		fwd.y = 0;
		fwd.Normalize();
		transform.position += aVal * fwd;
	}
	
	void Strafe(float aVal)
	{
		transform.position += aVal * transform.right;
	}
	
	void ChangeHeight(float aVal)
	{
		transform.position += aVal * Vector3.up;
	}
	
	void ChangeHeading(float aVal)
	{
		mHdg += aVal;
		WrapAngle(ref mHdg);
		transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
	}
	
	void ChangePitch(float aVal)
	{
		mPitch += aVal;
		WrapAngle(ref mPitch);
		transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
	}
	
	public static void WrapAngle(ref float angle)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
	}
}