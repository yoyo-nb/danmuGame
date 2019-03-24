using UnityEngine;
using System.Collections;

public class TextInit : MonoBehaviour {

	void Start () {
		this.transform.localScale = Vector3 .zero;
	}
	
	void Update () {

	}

	public void GameOver(){
		this.transform.localScale = Vector3.one;
		Time.timeScale = 0;

	}
}
