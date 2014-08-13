using UnityEngine;
using System.Collections;

public class AccelScript : MonoBehaviour
{
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Input.acceleration.x * Time.deltaTime, 
		                    0,
		                    -Input.acceleration.z * Time.deltaTime);
	}
}
