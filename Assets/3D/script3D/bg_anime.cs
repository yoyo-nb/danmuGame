using UnityEngine;
using System.Collections;

public class bg_anime : MonoBehaviour {

	public Material bg;

	private float offset;

	// Use this for initialization
	void Start () {
		offset = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.deltaTime == 0f)
			return;
		bg.SetFloat ("_Offset", offset);
		offset += 0.01f;
		if (offset > 1f) {
			offset = 0f;		
		}
	}
}
