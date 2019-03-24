using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class co : MonoBehaviour
{
    public Rigidbody r;
    public Rigidbody play;
    public Slider s;
    int xi = 20;
    DateTime d;
    private void Start()
    {
        d = DateTime.Now.ToLocalTime();
        play = GameObject.Find("pp1").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (transform.position.z <= 0)
            return;
        DateTime now= DateTime.Now.ToLocalTime();
        if ((now - d).Milliseconds < 900)
            return;
        
        d = DateTime.Now.ToLocalTime();
        Rigidbody tr = Instantiate(r, transform.position, transform.rotation);
        if (play != null)
        {
            Vector3 v = play.position - transform.position;
            v.Normalize();
            tr.velocity = transform.TransformDirection(v * 120);
            Destroy(tr.gameObject, 20);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "r2")
        {
            xi--;
            if (xi <= 0)
            {
                Destroy(this.gameObject);
                fen.score += 10;
            }
            s.value = xi / 20.0f;
        }
        if (collision.gameObject.tag == "r5")
        {
            xi -= 10;
            if (xi <= 0)
            {
                Destroy(this.gameObject);
                fen.score += 10;
            }

            s.value = xi / 20.0f;
        }

    }
}
