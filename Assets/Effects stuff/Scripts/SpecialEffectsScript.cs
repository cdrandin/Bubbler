using UnityEngine;
using System.Collections;

public class SpecialEffectsScript : MonoBehaviour 
{
	private static SpecialEffectsScript _instance;
	public SpecialEffectsScript instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = this;
			}

			return _instance;
		}
	}

	public ParticleSystem explosion_effect, vortex_effect;
	public GameObject trail_object;

	void Awake ()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		if(explosion_effect == null)
		{
			Debug.Log("Missing explosion effect prefabs");
		}
		if(vortex_effect == null)
		{
			Debug.Log("Missing vortex effect prefabs");
		}
		if(trail_object == null)
		{
			Debug.Log("Missing explosion effect prefabs");
		}
	}


	public static ParticleSystem MakeExplosion(Vector3 position)
	{
		GameObject particle   = PS_TEST.instance.PS_Instantiate(_instance.explosion_effect.gameObject);
		ParticleSystem effect = particle.GetComponent<ParticleSystem>();

		effect.transform.position = position;

		PS_TEST.instance.PS_Destroy(effect.gameObject, effect.duration);

		return effect;
	}

	public static ParticleSystem MakeVortex(Vector3 position)
	{
		GameObject particle   = PS_TEST.instance.PS_Instantiate(_instance.vortex_effect.gameObject);
		ParticleSystem effect = particle.GetComponent<ParticleSystem>();

		effect.transform.position = position;

		return effect;
	}

	public static GameObject MakeTrail(Vector3 position)
	{
		GameObject trail = PS_TEST.instance.PS_Instantiate(_instance.trail_object);

		trail.transform.position = position;

		return trail;
	}
}