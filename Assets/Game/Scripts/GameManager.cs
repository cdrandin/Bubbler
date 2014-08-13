using UnityEngine;
using System.Collections;

public enum GameState { NullState, Intro, MainMenu, Game, Pause }

public class GameManager : MonoBehaviour
{
	public GameState game_state { get; private set;}
	public delegate void on_state_change_handler();
	public event on_state_change_handler on_state_change;

	private static GameManager _instance;

	// Public methods
	public static GameManager instance
	{
		get
		{
			if(_instance == null)
			{
				GameObject go = new GameObject("_gamemanager");
				DontDestroyOnLoad(go);
				_instance = go.AddComponent<GameManager>();
			}

			return _instance;
		}
	}

	public void set_game_state(GameState game_state)
	{
		this.game_state = game_state;
		if(on_state_change != null)
		{
			on_state_change();
		}
	}

	public bool is_active 
	{ 
		get { return _instance != null; } 
	}
}