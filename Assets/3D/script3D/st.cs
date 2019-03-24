using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class st : MonoBehaviour
{
    public Rigidbody g;
    public Transform t;
    public Rigidbody boss;
    DateTime d;
    int ci = 0;
    // Start is called before the first frame update
    void Start()
    {
        d = DateTime.Now.ToLocalTime();
        ci = 10;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 1;
            fen.score = 0;
            SceneManager.LoadSceneAsync("Main");
        }

        if (Time.timeScale == 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                fen.score = 0;
                SceneManager.LoadSceneAsync("Main2");
            }
            
            else if (Input.GetKey(KeyCode.Q))
                Application.Quit();
            else
                return;
        }
        if (Input.GetKey(KeyCode.Q))
            Application.Quit();
        DateTime dn = DateTime.Now.ToLocalTime();
        if ((dn - d).Milliseconds < 800)
            return;
        ci++;
        d = DateTime.Now.ToLocalTime();
        Vector3 now = transform.position;
        now.x = UnityEngine.Random.Range(-400, 300);
        transform.position = now;
        Rigidbody r = (Rigidbody)Instantiate(g, t.position, t.rotation);
        r.velocity = transform.TransformDirection(Vector3.back * 40);
        Destroy(r.gameObject, 15);

        if (ci < 25)
            return;
        ci = 0;
        now.z = 200;
        Rigidbody bossr = (Rigidbody)Instantiate(boss, now, t.rotation);
        bossr.velocity = transform.TransformDirection(Vector3.right * 50);
        
    }
}
