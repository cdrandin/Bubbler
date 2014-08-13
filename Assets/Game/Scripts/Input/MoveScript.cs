using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour 
{
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));// * (Screen.height/Screen.width);
			position.z = 0.0f;
			transform.position = position;
		}
	}
}
