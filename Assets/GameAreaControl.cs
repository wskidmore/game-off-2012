using UnityEngine;
using System.Collections;

public class GameAreaControl : MonoBehaviour {
	
	public GameObject Player; 
	
	void OnCollisionExit(Collision other) {
		Debug.Log("COLLISION EXIT!");
		
        if (other.gameObject.CompareTag("Comet"))
			Player.GetComponent<PlayerState>().RemoveComet(other.gameObject);
		
    }	
}
