using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour {

    private AudioSource WinBGM;
    private GameObject Win;

	void Start () {
        WinBGM = this.GetComponent<AudioSource>();
        Win = GameObject.Find("Win");
        Win.transform.localScale = Vector3.zero;
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            //Application.LoadLevel ("Main");
            SceneManager.LoadScene("Main");
            Time.timeScale = 1f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    public void BossDead()
    {
        Win.transform.localScale = Vector3.one;
        WinBGM.Play();
    }
}
