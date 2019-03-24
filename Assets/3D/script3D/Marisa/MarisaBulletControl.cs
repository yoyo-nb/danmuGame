using UnityEngine;
using System.Collections;

public class MarisaBulletControl : MonoBehaviour {

	public GameObject bullet;

	private readonly Vector3 angle = new Vector3 (0, 0, 12.5f);
	private readonly Vector3 offset = new Vector3(0.18f, 0, 0);
	private const int SparkHit = 50;
	private const float slowScale = 0.875f;

	private Transform t;
	private GameObject checkPoint;
	private bool isSlow = false;
	private Vector3 tScale;

	void Start () {
		//velocity = new Vector3 (0, 1, 0);
		t = transform;
		checkPoint = GameObject.Find ("CheckPoint");
		//checkPoint.transform.localPosition = new Vector3(0,0,-1);
		checkPoint.transform.localScale = Vector3.zero;
        this.Spark = this.gameObject.GetComponent<MarisaMove>();
	}

	void Update () {
		_CheckPoint ();
		_OnShoot ();
		_Spark ();
	}

    void LateUpdate()
    {
        if (isSlow)
        {
            checkPoint.transform.position = new Vector3(t.position.x,
                t.position.y,
                checkPoint.transform.position.z);
        }
    }

    void OnDestroy()
    {
        checkPoint.transform.position = t.position;
        checkPoint.transform.localScale = Vector3.one;
    }

    //===================private=====================
    private void _OnShoot() {
		if (Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.J)){
			GameObject o =  GameObject.Instantiate(bullet,
                               t.position + Vector3.forward,
                               t.rotation);
            o.GetComponent<AudioSource>().Play();
            o = (GameObject)GameObject.Instantiate(bullet,
			                       t.position + Vector3.forward + offset,
			                       t.rotation);
			if(!isSlow) {
				o.transform.Rotate(-angle);
			}
			o = (GameObject)GameObject.Instantiate(bullet,
			                       t.position + Vector3.forward - offset,
			                       t.rotation);
			if(!isSlow) {
				o.transform.Rotate(angle);
			}
		}
		return;
	}

	private void _CheckPoint(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isSlow = true;
			checkPoint.transform.localScale = Vector3.one;
			tScale = t.transform.localScale;
			t.transform.localScale *= slowScale;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			isSlow = false;		
			checkPoint.transform.localScale = Vector3.zero;
			t.transform.localScale = tScale;
		}
        
	}

    private MarisaMove Spark;
	private void _Spark(){
		if (!Input.GetKeyDown (KeyCode.X)) {
			return;
		}
        Spark.MasterSpark(out bool isDying);
        //if (!isDying)
        //    return;
		GameObject[] dangan = GameObject.FindGameObjectsWithTag ("EBullet");
		ReimuBoss r = GameObject.Find ("Reimu").GetComponent<ReimuBoss> ();
		for (int i=0; i<dangan.Length; i++) {
			Destroy(dangan[i]);
		}
        if(r)
		    r.GetHit (SparkHit);
	}

}
