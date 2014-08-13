using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	private GameManager GM;

	// Particles
	private Dictionary<int, GameObject> trails = new Dictionary<int, GameObject>();
	private Touch pinch_finger1, pinch_finger2;
	private ParticleSystem vortex;

	void Awake ()
	{
		GM = GameManager.instance;
		GM.on_state_change += HandleOnStateChange;

		Debug.Log("Current game state when Awake: " + GM.game_state);

		GM.set_game_state(GameState.Intro);

		GameObject.FindGameObjectWithTag("Bound_Down").AddComponent<BubbleCleaner>();
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log("Current game state when Start: " + GM.game_state);
	}
	
	public void HandleOnStateChange()
	{
		Debug.Log("Handle state change to: " + GM.game_state);
	}

	void Update()
	{
		/*
		// -- Pinch
		if(Input.touchCount == 2)
		{
			Touch finger1 = Input.GetTouch(0);
			Touch finger2 = Input.GetTouch(1);

			if(finger1.phase == TouchPhase.Began || finger2.phase == TouchPhase.Moved)
			{
				this.pinch_finger1 = finger1;
				this.pinch_finger2 = finger2;
			}

			// On move
			if(finger1.phase == TouchPhase.Moved || finger2.phase == TouchPhase.Moved)
			{
				float base_dist = Vector2.Distance(this.pinch_finger1.position, this.pinch_finger2.position);
				float cur_dist  = Vector2.Distance(finger1.position, finger2.position);

				// % change
				float cur_dist_percentage = cur_dist/base_dist;

				// create effect between fingers
				if(vortex == null || !vortex.isPlaying)
				{
					Vector3 finger1_pos = Camera.main.ScreenToWorldPoint(this.pinch_finger1.position);
					Vector3 finger2_pos = Camera.main.ScreenToWorldPoint(this.pinch_finger2.position);

					// Find the center between two fingers
					Vector3 vortex_pos = Vector3.Lerp(finger1_pos, finger2_pos, 0.5f);
					vortex = SpecialEffectsScript.MakeVortex(vortex_pos);
				}

				// Scale particle according to zoom in/out
				vortex.gameObject.transform.localScale = Vector3.one * (cur_dist_percentage * 1.5f);
			}
		}
		// release pinch
		else
		{
			if(vortex != null)
			{
				PS_TEST.instance.PS_Destroy(vortex.gameObject);
			}
		}
		*/

		/*
		// all fingers
		for(int i=0;i<Input.touchCount;++i)
		{
			Touch touch = Input.GetTouch(i);
			
			//world to screen
			Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
			
			// -- Tap: quick touch and release
			if(touch.phase == TouchPhase.Ended && touch.tapCount == 1)
			{
				SpecialEffectsScript.MakeExplosion(position);
			}
			
			// -- Drag
			if(touch.phase == TouchPhase.Began)
			{
				// store new value
				if(!trails.ContainsKey(i))
				{
					position.z = 0.0f;
					
					GameObject trail = SpecialEffectsScript.MakeTrail(position);
					
					// add to list
					if(trail != null)
					{
						trails.Add(i, trail);
					}
				}
			}
			else if(touch.phase == TouchPhase.Moved)
			{
				// Move trail
				if(trails.ContainsKey(i))
				{
					GameObject trail = trails[i];
					
					position.z = 0.0f;
					
					trail.transform.position = position;
				}
			}
			else if(touch.phase == TouchPhase.Ended)
			{
				if(trails.ContainsKey(i))
				{
					GameObject trail = trails[i];
					
					PS_TEST.instance.PS_Destroy(trail, trail.GetComponent<TrailRenderer>().time);
					trails.Remove(i);
				}
				
			}
		} // - end for loop
		*/
	}
}