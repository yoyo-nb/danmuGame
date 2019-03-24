using UnityEngine;
using System.Collections;

public class ReimuBulletManager : MonoBehaviour {

	public GameObject bullet;
    public GameObject bullet_r;
    public bool simpleMode = false;

	private Vector3 velocity;
	private int count = 0;
	private Transform t;
	private GameObject Marisa;
	private Transform MarisaTrans;

	void Start () {
		t = transform;
		Marisa = GameObject.Find ("Marisa");
		if(Marisa){
			MarisaTrans = Marisa.GetComponent<Transform>();
		}
	}
	
	void Update () {
		count++;
        _ChasingBullet(count);
        if (!simpleMode)
        {
            _CircleBullet (count);
            _CirnoEnter(count);
        }
		if (count == 200) {
			count = 0;
		}
	}

    public void Clear()
    {
        count = 1;
        GameObject[] dangan = GameObject.FindGameObjectsWithTag("EBullet");
        for (int i = 1; i < dangan.Length; i++)
        {
            Destroy(dangan[i]);
        }
    }

    //===============private================//

    private const float ChasingBulletSpeed = 2f;
	private void _ChasingBullet(int count){
		if(count%30 != 0 || Time.timeScale<=0f ) 
			return;
		Vector3 self = new Vector3(t.position.x, t.position.y,0);

        if (MarisaTrans){
			velocity = MarisaTrans.position - t.position;
			velocity.z = 0;
			velocity.Normalize();
		}
		else{
			// 金发的孩子真可怜
			velocity = new Vector3 (0,-1,0) ;//* flySpeed;
		}
		GameObject o = (GameObject) GameObject.Instantiate (bullet,
		                       								 self,
		                       								 t.rotation);
		EBullet e = o.GetComponent<EBullet> ();
		e.SetMarisa (Marisa);
		e.flySpeed = ChasingBulletSpeed;
		e.SetVelocity (velocity);
	}

    private const float CircleBulletSpeed = 1f;
	private void _CircleBullet(int count){
		if(count%10 != 0|| Time.timeScale<=0f )
			return;
		int bias = (int)(Random.value * 30);
		Vector3 self = new Vector3(t.position.x, t.position.y,0);
		for (int angle=-180+bias; angle <180+bias; angle+= 30) {
			GameObject o = (GameObject) GameObject.Instantiate(bullet,
			                                            self,
			                                            t.rotation);
			o.transform.Rotate(0,0,angle);
			EBullet e = o.GetComponent<EBullet>();
			e.flySpeed = CircleBulletSpeed;
			e.SetVelocity(1,0,0);
		}
	}

    private const float CirnoBulletSpeed = 6f;
    private void _CirnoEnter(int count)
    {
        const int deltaFrame = 100;
        if (count % deltaFrame == 0 && Time.timeScale != 0)
        {
            StartCoroutine(_Cirno());
        }
    }

	private IEnumerator _Cirno() {
		const int radius = 2;
		const int deltaAngle = 15;
		Vector3 self = new Vector3 (t.position.x, t.position.y, 0);
		Vector3 cirPos = new Vector3();
		int angle = -180;
        for (int i=0; i<30 ; angle+= deltaAngle,i++) {
        //for (; angle < 180; angle += deltaAngle) { 
			//angle%= 180;
			cirPos.x = Mathf.Cos (angle/180f * Mathf.PI);
			cirPos.y = Mathf.Sin(angle/180f * Mathf.PI);
			cirPos.z = 0;
			cirPos *= radius;
			cirPos += self;
			// Chasing
			if(MarisaTrans){
				velocity = MarisaTrans.position - cirPos;
				velocity.z = 0;
				velocity.Normalize();
			}
			else{
				// 金发的孩子真可怜
				velocity = new Vector3 (0,-1,0) ;//* flySpeed;
			}
			GameObject o = (GameObject) GameObject.Instantiate (bullet_r,
			                                                    cirPos,
			                                                    t.rotation);
			EBullet e = o.GetComponent<EBullet> ();
			e.SetMarisa (Marisa);
			e.flySpeed = CirnoBulletSpeed;
			e.SetVelocity (velocity);
            o.GetComponent<AudioSource>().Play();   

			yield return null;
		}
	}

}
