using UnityEngine;
using System.Collections;

// Specfically move the shooter only on the z-axis

public class MoveShooter : MonoBehaviour 
{
	[Range(0.01f, 1.0f)]
	public float rotation_rate;

	[Range(0.0f, 360.0f)]
	public float left_bound, right_bound;

	private Vector3 touch_world_pos;
	private GameObject dot;
	private float angle;
	// Use this for initialization
	void Start () 
	{
		dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		dot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
	}

	void Update ()
	{
		if(Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			
			touch_world_pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 
			                                                             touch.position.y, 
			                                                             5.0f));
		}

		DebugTouchLocation(true);
	}

	void FixedUpdate () 
	{
		if(Input.touchCount == 1 /*&& Input.GetTouch(0).phase == TouchPhase.Moved*/)
		{
			// Get the angle between the shooter and finger touch. Then add an offset since the shooter is up, 90 degrees
			angle = Mathf.Atan2(touch_world_pos.y - this.transform.position.y, touch_world_pos.x - this.transform.position.x) * Mathf.Rad2Deg;
			angle -= 90.0f; // offset correctly

			// Create a rotation around the axis. Forward being into the game, allowing the shooter to rotate 
			//    left and right from the PoV of the screen, Apply lerping affect to prevent jerking
			Quaternion new_rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, new_rotation, rotation_rate);

			// Constrain rotation to be allowed only on the z-axis (left and right movement, screen PoV)
			Vector3 rot = this.transform.rotation.eulerAngles;
			rot.x = rot.y = 0.0f;

			// Restrict within degree bounds
			rot.z = (rot.z > left_bound && rot.z < 180.0f)?
						left_bound:
						(rot.z < right_bound && rot.z > 180.0f)?
							right_bound:
							rot.z;

			// Convert appropriate euler coordinates into Unity's quaternion system
			this.transform.rotation = Quaternion.Euler(rot);
		}
	}

	// Displays a sphere where the touch locaiton is at, only for 1 finger
	void DebugTouchLocation(bool v)
	{
		if(!v) return;

		if(Input.touchCount == 1)
		{
			dot.transform.position = touch_world_pos;
		}
		else
		{
			dot.transform.position = new Vector3(0, 0, -50);
		}
	}
}