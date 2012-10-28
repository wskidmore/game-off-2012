using UnityEngine;
using System.Collections;

public class CometMove : MonoBehaviour
{
	public float xVelocity = 20;
	public float yVelocity = 0;

    // Use this for initialization
    void Start()
    {
		rigidbody.AddRelativeForce(xVelocity, yVelocity, 0);
    }

    void FixedUpdate()
    {
	    rigidbody.velocity = new Vector3(xVelocity, yVelocity, 0);
    }

	public void SetVelocity(float x, float y)
	{
		xVelocity = x;
		yVelocity = y;
	}
}
