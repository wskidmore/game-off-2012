using UnityEngine;
using System.Collections;

public class TileBackground : MonoBehaviour {
	
	public Camera TrackingCamera;
	private float _width;
	
	// Use this for initialization
	void Start () {
		_width = transform.lossyScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
		var currentX = transform.position.x;
		var thresholdX = currentX - _width;
		if (TrackingCamera.transform.position.x >= thresholdX)
		{
			transform.position = new Vector3(currentX + (_width * 2),transform.position.y , transform.position.z);
		}
	}
}
