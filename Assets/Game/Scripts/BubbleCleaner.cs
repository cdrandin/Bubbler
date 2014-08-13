using UnityEngine;
using System.Collections;

// Object is meant to clean bubbles, meaning pooling them and stop rendering them.
// This will force the objects collider to trigger
public class BubbleCleaner : MonoBehaviour 
{
	void Awake()
	{
		GetComponent<BoxCollider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Bubble")
		{
			if(other.GetComponent<PoolID>() != null)
			{
				PS_TEST.instance.PS_Destroy(other.gameObject);
			}
			else
			{
				Debug.Log(string.Format("{0} is not using Pooling System.", other.gameObject));
			}
		}
	}
}