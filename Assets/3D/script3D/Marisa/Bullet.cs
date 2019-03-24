using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private const float flySpeed = 0.5f;
	private const float yBorder = 5f;
	private const float safeDis = 1f;

	private Transform t;
	private Transform reimu;
	private ReimuBoss hit;

	void Start () {
		t = this.transform;
		GameObject temp =  GameObject.Find ("Reimu");
		if(temp){
			reimu = temp.GetComponent<Transform>();
			hit = temp.GetComponent<ReimuBoss> ();
		}
	}
	
	void Update () {
		_OnMove ();
		_OnCheck ();
	}

	//==========private==============//

	private void _OnMove(){
		t.Translate (0, flySpeed, 0);
		if (t.position.y > yBorder) {
			Destroy(this.gameObject);
		}
	}

	private void _OnCheck(){
		if (!reimu)
			return;
		Vector3 v = reimu.position - t.position;
		float dis = Mathf.Sqrt (v.x * v.x + v.y * v.y);
		if (dis <= safeDis) {
			if(hit)
				hit.GetHit ();
			Destroy(this.gameObject);
		}
	}

}
