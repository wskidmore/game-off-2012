using UnityEngine;
using System.Collections;

public class CometMove : MonoBehaviour
{
    private float _xVelocity = 5;


    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
        rigidbody.AddRelativeForce(_xVelocity, 0, 0);
    }

    public void SetRotation(float degrees)
    {
		transform.Rotate(new Vector3(0, 0, degrees));
    }
	public void SetVelocity(Vector3 velocity) 
	{
		rigidbody.velocity = velocity;
	}

}
