using UnityEngine;
using System.Collections;

public class ReimuMove : MonoBehaviour {

	public Transform t;
	public float speed = 10.0f;

	private Vector3 v;

	private const float slowRate = 0.382f;

	// Use this for initialization
	void Start () {
		v = new Vector3 (0, -4, 0);
		t.position = v;
	}
	
	// Update is called once per frame
	void Update () {
		v = new Vector3 (Input.GetAxisRaw ("Horizontal"),
		                 Input.GetAxisRaw ("Vertical"),
		                 0);
		v.Normalize ();
		float fixedSpeed = 0f;
		if (Input.GetAxisRaw ("Fire1")!=0f) {
			fixedSpeed = speed * slowRate;	
		}else {
			fixedSpeed = speed;
		}

		t.position += v*Time.deltaTime*fixedSpeed;
	}
}
