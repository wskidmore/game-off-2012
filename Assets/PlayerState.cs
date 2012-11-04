using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState : MonoBehaviour
{
    public List<GameObject> Comets = new List<GameObject>();
    public GameObject CometPrefab;
	GameObject SelectedComet;

    // Use this for initialization
    void Start()
    {
		AddComet(transform.position, transform.rotation);
    }
	
	GameObject AddComet(Vector3 position, Quaternion rotation)
	{
        GameObject newComet = Instantiate(CometPrefab, position, rotation) as GameObject;
		CometActions cometProps = newComet.GetComponent<CometActions>();
		
		cometProps.Player = gameObject;
		
        Comets.Add(newComet);
		
		return newComet;
	}

    // Update is called once per frame
    void Update()
    {
		// detect lose
		if (!SelectedComet)
		{
			if (Comets.Count > 0)
			{
				SelectRandomComet();
			}
			else
			{
				// lose
			}
		}
		
        // detect fork
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Fork();
		// detect branch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Branch();
		
		// detect selecting
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			// Casts the ray and get the first game object hit
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.gameObject.CompareTag("Comet"))
				{
					SelectedComet.GetComponent<CometActions>().DeSelectComet();
					SelectedComet = hit.transform.gameObject;
					SelectedComet.GetComponent<CometActions>().SelectComet();
				}
			}
			
		}
		
		// update player pos to active comet
		if (SelectedComet) 
		{
			var pos = SelectedComet.transform.position;
			transform.position = new Vector3(pos.x, pos.y, 0);
		}
    }
	
	void SelectRandomComet()
	{
		int i = Random.Range(0, Comets.Count - 1);
		SelectedComet = Comets[i];
		SelectedComet.GetComponent<CometActions>().SelectComet();
	}
	
	public void RemoveComet(GameObject comet)
	{
		Debug.Log("REMOVING COMET!");
		
		if (SelectedComet.Equals(comet))
		{
			SelectRandomComet();
		}
		
		Comets.Remove(comet);
		Destroy(comet);
	}
	

    void Fork()
    {
        // get active pos/rot
        Vector3 activePosition = SelectedComet.transform.position;
        Quaternion activeRotation = SelectedComet.transform.rotation;

        // create a new comet at same spot
		GameObject newComet = AddComet(activePosition, activeRotation);

        // set the active comet to 45 degrees ---/
        SelectedComet.GetComponent<CometMove>().SetVelocity(20, 7);
		
		
		var newCometMove = newComet.GetComponent<CometMove>();
        // set the new comet to 315 degrees ---\
        newCometMove.SetVelocity(20, -7);
		
		// set the new comet to the old comets force
    }
	
	void Branch()
	{
        // get active pos/rot
        Vector3 activePosition = SelectedComet.transform.position;
        Quaternion activeRotation = SelectedComet.transform.rotation;

		Vector3 newPosition = activePosition;
		newPosition.y = activePosition.y + 10;
		
        // create a new comet at same spot
		AddComet(newPosition, activeRotation);
	}

}
