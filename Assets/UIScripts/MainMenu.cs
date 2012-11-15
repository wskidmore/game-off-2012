using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnPlayClick() {
		LoadStartLevel();
	}
	
	void LoadStartLevel() {
		Application.LoadLevel("level1"); 
	}
}
