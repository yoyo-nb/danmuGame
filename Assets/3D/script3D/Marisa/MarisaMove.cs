using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarisaMove : MonoBehaviour {

	public readonly float speed = 8.0f;
	private const float xBorder = 11f;
	private const float yBorder = 5f;
	//private readonly Vector3 initPos = new Vector3 (0, -4, 0);
	private const float slowRate = 0.382f;

	private Transform t;
	private Vector3 v;
	private bool isDying = false;
	//private Text show;

	void Start () {
		t = this.transform;
		//t.position = initPos;
		//show = GameObject.Find
	}
	
	void Update () {
		_OnMove ();
	}

    public void YouDead() => StartCoroutine(_YouDead());

    public void MasterSpark(out bool isD)
    {
        isD = isDying;
        if (isDying)
        {
            customTime = Time.time - customTime;
            print("Your Dying Time: " + customTime.ToString());
            isDying = false;
        }
    }

    //======================private==============================

    private void _OnMove(){
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
		_TurnAround (v);
		v = t.position + v * Time.deltaTime * fixedSpeed;
		v.x = Mathf.Clamp (v.x, -xBorder, xBorder);
		v.y = Mathf.Clamp (v.y, -yBorder, yBorder);
		t.position = v;
	}

	private void _TurnAround(Vector3 tv) {
		if(tv.x < 0 && tv.y>0)
			return;
		Vector3 tScale = new Vector3 (Mathf.Abs(t.localScale.x),Mathf.Abs(t.localScale.y),0);
		if(tv.x>0) {
			tScale.x = -tScale.x;
		}
		if (tv.y < 0) {
			tScale.y = -tScale.y;
		}
		t.localScale = tScale;
	}

    private const float DyingTime = 0.2f;
    private float customTime;
    private IEnumerator _YouDead()
    {
        customTime = Time.time;
        isDying = true;
        yield return new WaitForSeconds(DyingTime);
        if (!isDying)
        {
            yield break;
        }
        GameObject.Find("YouDead").GetComponent<TextInit>().GameOver();
        Destroy(this.gameObject);
    }

}
