using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
 	}

	void OnGUI ()
	{
		foreach(Touch touch in Input.touches)
		{
			string message = "";
			message += string.Format("ID: {0} \nPhase: {1}\nTap Count: {2}\nPosition: ({3},{4})", 
			                         touch.fingerId, touch.phase.ToString(), touch.tapCount, touch.position.x, touch.position.y);

			int num = touch.fingerId;
			GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), message);
		}
	}
}