using UnityEngine;
using System.Collections;

public class EBullet : MonoBehaviour {

	public float flySpeed = 5f;

	private const float checkRadius = 0.25f;
	private const float xBorder = 11f;
	private const float yBorder = 6f;

	private Vector3 velocity;
	private Transform Marisa;
	private MarisaMove dead;
	private Transform t;
    private Vector3 rotationAngle;

	void Start () {
		t = this.transform;
        rotationAngle = new Vector3(0, 0, flySpeed*100);
	}
	
	void Update () {
		_OnMove ();
        //_OnRotate();
		_Check ();
	}

	public void SetVelocity(Vector3 v){
		this.velocity = v*flySpeed;
	}

	public void SetVelocity(float x, float y, float z){
		this.velocity = new Vector3 (x, y, z) * flySpeed;
	}

	public void SetMarisa(GameObject temp){
		if(temp){
			Marisa = temp.GetComponent<Transform>();
			dead = temp.GetComponent<MarisaMove> ();
		}
	}

	//=================private==================//

	private void _OnMove(){
		t.Translate (velocity*Time.deltaTime);
		if (t.position.y <= -yBorder || t.position.y>= yBorder) {
			Destroy(this.gameObject);		
		}
		if (t.position.x <= -xBorder || t.position.x >= xBorder) {
			Destroy(this.gameObject);		
		}
	}

    private void _OnRotate()
    {
        this.transform.Rotate(rotationAngle*Time.deltaTime);
    }

	private void _Check(){
		if (!Marisa)
			return;
		Vector3 tv = Marisa.position - t.position;
		float dis = Mathf.Sqrt (tv.x * tv.x + tv.y * tv.y);
		if (dis <= checkRadius) {
            dead.YouDead();
			Destroy(this.gameObject);
		}
	}

}
