using UnityEngine;
using System.Collections;

public class PlaneFollow : MonoBehaviour {
	
	public GameObject FollowTarget;
    public float xOffset = 50;
    public float yOffset = 0;
	public float zOffset = -440;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(FollowTarget.transform.position.x - xOffset, yOffset, zOffset);
    }
}
