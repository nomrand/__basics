using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public bool isFix = true;

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        if (isFix)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(5.0f, 0f, 0f));
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);
        }

        GetComponent<Rigidbody>().AddForce(new Vector3(0f, 8.0f, 0f));
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isFix)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(500.0f, 0f, 0f) * Time.deltaTime );
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);
        }
    }
}
