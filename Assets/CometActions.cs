using UnityEngine;
using System.Collections;

public class CometActions : MonoBehaviour
{
	private Transform _selectedBubble;
	public GameObject Player;
	
    // Use this for initialization
    void Start()
	{
		_selectedBubble = transform.Find("Selected");
    }
	
    // Update is called once per frame
    void Update()
    {
    }
	
	void OnBecameInvisible () 
	{
		Player.GetComponent<PlayerState>().RemoveComet(gameObject);
	}	
	
	public void DeSelectComet()
	{
		_selectedBubble.renderer.enabled = false;
	}
	public void SelectComet()
	{
		_selectedBubble.renderer.enabled = true;
	}
}
