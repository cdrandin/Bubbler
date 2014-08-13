using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleShooter : MonoBehaviour 
{
	public Transform bubble_spawner;
	public float delay;
	public float force;

	private List<GameObject> _bubbles;
	private GameObject _bubble_obj;
	private float timestamp;

	void Awake ()
	{
		if(bubble_spawner == null)
		{
			Debug.LogError("Missing bubbler spawner. Game will break!");
			return;
		}

		_bubbles    = new List<GameObject>();
		_bubble_obj = null;
		timestamp   = 0.0f;
	}

	void LateUpdate ()
	{
		// One finger touch and release
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			if(timestamp == delay)
			{
				Shoot();
				timestamp = 0.0f;
			}
		}

		// Keep value small
		timestamp += Time.deltaTime;
		timestamp = (timestamp >= delay)?delay:timestamp;
	}

	void Shoot()
	{
		if(_bubble_obj == null)
		{
			_bubble_obj =  Resources.Load<GameObject>("Bubble");
		}

		// Get bubble obj
		GameObject obj = PS_TEST.instance.PS_Instantiate(_bubble_obj);
		obj.transform.position = bubble_spawner.position;
		
		if(obj.rigidbody2D == null)
		{
			obj.AddComponent<Rigidbody2D>();
		}
		
		obj.GetComponent<Rigidbody2D>().AddForce(force * bubble_spawner.up);

		// Make sure to not put an object that already exist in the list
		if(!_bubbles.Contains(obj))
		{
			_bubbles.Add(obj);
		}
	}
}