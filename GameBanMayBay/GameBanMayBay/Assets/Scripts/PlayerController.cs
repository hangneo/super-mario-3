using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 5 ;
	public GameObject dan;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a")) {
			transform.Translate (-Vector3.right * speed * Time.deltaTime);

		} else if (Input.GetKey ("d")) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
		else if (Input.GetKey ("s")) {
			transform.Translate (-Vector3.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey ("w")) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}

		if ( Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (dan, transform.position, Quaternion.identity);

		}

	}
}
