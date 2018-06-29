using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EatText.SetActive(false);
	}
    public GameObject EatText;


	// Update is called once per frame
	void Update () {
        // Bit shift the index of the layer (8) to get a bit mask
   

        int layerMask = 1 << 8;
        float range = 1;
        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            EatText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) 
            {
               // Destroy(hit.transform.gameObject);
                hit.transform.gameObject.SetActive(false);
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did not Hit");
            if (EatText.active) EatText.SetActive(false); 
        }
	}
}
