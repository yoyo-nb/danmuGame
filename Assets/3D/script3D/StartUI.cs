using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour {

    public ReimuBoss begin;

	void Start () {
		Time.timeScale = 0f;
        begin = GameObject.Find("Reimu").GetComponent<ReimuBoss>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Time.timeScale = 1f;
            begin.Begin();
			Destroy(this.gameObject);
		}
	}
}
