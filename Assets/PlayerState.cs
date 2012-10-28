using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState : MonoBehaviour
{
    public int ActiveCometIndex;
    public List<GameObject> Comets = new List<GameObject>();
    public GameObject CometPrefab;

    // Use this for initialization
    void Start()
    {
        GameObject newComet = Instantiate(CometPrefab, transform.position, transform.rotation) as GameObject;
        Comets.Add(newComet);
        ActiveCometIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // detect fork
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Fork();
		
		var pos = Comets[ActiveCometIndex].transform.position;
		transform.position = new Vector3(pos.x, pos.y, 0);
    }

    void Fork()
    {
        // get active pos/rot
        Vector3 activePosition = Comets[ActiveCometIndex].transform.position;
        Quaternion activeRotation = Comets[ActiveCometIndex].transform.rotation;

        // create a new comet at same spot
        GameObject newComet = Instantiate(CometPrefab, activePosition, activeRotation) as GameObject;
        Comets.Add(newComet);

        // set the active comet to 45 degrees ---/
        Comets[ActiveCometIndex].GetComponent<CometMove>().SetRotation(45);
		
		
		var newCometMove = newComet.GetComponent<CometMove>();
        // set the new comet to 315 degrees ---\
        newCometMove.SetRotation(315);
		
		// set the new comet to the old comets force
		newCometMove.SetVelocity(Comets[ActiveCometIndex].rigidbody.velocity);
    }

}
