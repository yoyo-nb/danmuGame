using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReimuBoss : MonoBehaviour {

	public Text show;
	public Slider hitBar;
	public float speed = 5f;

	private const float xBorder = 8f;  // 11.0f

	private int hitPoint = 1000;
	private Transform t;
	private Vector3 velocity;
    private AudioSource BGM;
    //private AudioSource hitSound;
    private MainLoop deadSend;

	void Start () {
		t = this.gameObject.GetComponent<Transform> ();
		t.position.Set (0, 3.7f, 0);
		velocity = new Vector3 (1, 0, 0)*speed;
		show.text = hitPoint.ToString ();
		hitBar.value = hitPoint;
        BGM = this.GetComponent<AudioSource>();
        deadSend = GameObject.Find("MainLoop").GetComponent<MainLoop>();
	}
	
	void Update () {
		_OnMove ();
        
	}

    private void OnDestroy()
    {
        StopCoroutine(_DropperSec());
    }

	public void GetHit(int point = 1){
        //_PlayHitSound();
		hitPoint-= point;
		show.text = hitPoint.ToString ();
		hitBar.value = hitPoint;
		_CheckDead ();
	}

    public void Begin()
    {
        BGM.Play();
        StartCoroutine(_DropperSec());
    }

	//=============private=================//

	private void _CheckDead(){
		if (hitPoint <= 0) {
			show.text =  "Marisa You Win!";
			show.color = Color.yellow;
			Destroy(hitBar.gameObject);
            this.GetComponent<ReimuBulletManager>().Clear();
            deadSend.BossDead();
			Destroy(this.gameObject);
		}
        return;
	}

	private void _OnMove(){
		Vector3 sPosition = t.position + velocity * Time.deltaTime;
		sPosition.x = Mathf.Clamp (sPosition.x, -xBorder, xBorder);
		t.position = sPosition;
		if (sPosition.x >= xBorder || sPosition.x <= -xBorder) {
			velocity = -velocity;
			t.localScale = new Vector3(-t.localScale.x, t.localScale.y, t.localScale.z);
		}
        BGM.panStereo = sPosition.x / xBorder;
	}

    private IEnumerator _DropperSec()
    {
        while (true)
        {
            GetHit(2);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //private void _PlayHitSound()
    //{
    //    //hitSound.Play();
    //}
}
