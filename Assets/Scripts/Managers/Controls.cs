using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
	public static Controls Instance;

	public KeyCode Forward { get; set; }
	public KeyCode Backward { get; set; }
	public KeyCode Left { get; set; }
	public KeyCode Right { get; set; }
	public KeyCode Jump { get; set; }
	public KeyCode AirRollLeft { get; set; }
	public KeyCode AirRollRight { get; set; }
	public KeyCode Restart { get; set; }

	void Awake()
    {
        if(Instance == null) {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if(Instance != this) {
			Destroy(gameObject);
		}

		Forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forward", "W"));
		Backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backward", "S"));
		Left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left", "A"));
		Right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right", "D"));
		Jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jump", "Space"));
		AirRollLeft = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("arleft", "Q"));
		AirRollRight = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("arright", "E"));
		Restart = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("restart", "R"));
	}
}
