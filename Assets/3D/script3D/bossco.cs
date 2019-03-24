using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class bossco : MonoBehaviour
{
    public Rigidbody r;
    public Slider s;
    public Rigidbody player;
    Vector3 lastw;
    Vector3 lastp;
    int xi = 900;
    DateTime d;
    int ci = 0;
    int count = -200;
    private void Start()
    {
        d = DateTime.Now.ToLocalTime();
        player = GameObject.Find("pp1").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        count++;
        if(count == -30)
        {
            lastw = transform.position;
            lastp = player.position;
        }
        if(count >= -30 )
        {
            //Rigidbody tr1 = Instantiate(r, transform.position, transform.rotation);
            //tr1.position = new Vector3((float)(tr1.position.x+ 100 *Math.Sin((count-100)*6 * Math.PI / 180)), 15.9f, (float)(tr1.transform.position.z+100 * Math.Cos( (count-100)*6 * Math.PI / 180)));

            Rigidbody tr2 = Instantiate(r, lastw, transform.rotation);
            tr2.position = new Vector3((float)(tr2.position.x +50+ 100 * Math.Sin((count - 100) * 6 * Math.PI / 180)), 15.9f, (float)(tr2.transform.position.z + 100 * Math.Cos((count - 100) * 6 * Math.PI / 180)));

            Rigidbody tr3 = Instantiate(r, lastw, transform.rotation);
            tr3.position = new Vector3((float)(tr3.position.x -50- 100 * Math.Sin((count - 100) * 6 * Math.PI / 180)), 15.9f, (float)(tr3.transform.position.z + 100 * Math.Cos((count - 100) * 6 * Math.PI / 180)));

            Rigidbody tr22 = Instantiate(r, lastw, transform.rotation);
            tr22.position = new Vector3((float)(tr22.position.x + 50 + 100 * Math.Sin((count - 100) * 6 * Math.PI / 180)), 15.9f, (float)(tr22.transform.position.z - 100 * Math.Cos((count - 100) * 6 * Math.PI / 180)));

            Rigidbody tr33 = Instantiate(r, lastw, transform.rotation);
            tr33.position = new Vector3((float)(tr33.position.x - 50 - 100 * Math.Sin((count - 100) * 6 * Math.PI / 180)), 15.9f, (float)(tr33.transform.position.z - 100 * Math.Cos((count - 100) * 6 * Math.PI / 180)));

            if (player != null)
            {
                //Vector3 v = player.position - tr1.position;
                //v.Normalize();
                //tr1.velocity = tr1.transform.TransformDirection(v * 200);
                //Destroy(tr1.gameObject, 20);
                Vector3 v;
                v = lastp - tr2.position;
                v.Normalize();
                tr2.velocity = tr2.transform.TransformDirection(v * 100);
                Destroy(tr2.gameObject, 20);

                v = lastp - tr3.position;
                v.Normalize();
                tr3.velocity = tr3.transform.TransformDirection(v * 100);
                Destroy(tr3.gameObject, 20);

                v = lastp - tr22.position;
                v.Normalize();
                tr22.velocity = tr22.transform.TransformDirection(v * 100);
                Destroy(tr22.gameObject, 20);

                v = player.position - tr33.position;
                v.Normalize();
                tr33.velocity = tr33.transform.TransformDirection(v * 100);
                Destroy(tr33.gameObject, 20);
            }
            if (count == 30)
                count = -200;
        }
        if (Time.timeScale == 0)
            return;
        if (transform.position.x <= -400)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(40,0,0));
        }
        if (transform.position.x >= 300)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(-40, 0, 0));
        }

        DateTime now = DateTime.Now.ToLocalTime();
        if ((now - d).Milliseconds < 400)
            return;
        d = DateTime.Now.ToLocalTime();
        Rigidbody tr = Instantiate(r, transform.position, transform.rotation);
        Vector3 vv2 = player.position - transform.position;
        vv2.y = 0;
        vv2.Normalize();
        tr.transform.localScale = new Vector3(20, 20, 20);
        tr.velocity = transform.TransformDirection(vv2 * 170);
        Destroy(tr.gameObject, 20);
        ci++;
        int ge;
        if (ci %2 == 1)
            ge = 20;    
        else
            ge = 30;
           
        for (int i = 0; i < ge; i++)
        {
            Rigidbody tr6 = Instantiate(r, transform.position, transform.rotation);
            Vector3 vv = new Vector3((float)Math.Sin(360 / ge * i * Math.PI / 180), 0, (float)Math.Cos(360 / ge * i * Math.PI / 180));
            tr6.GetComponent<Rigidbody>().velocity = vv * 100;
            Destroy(tr6.gameObject, 20);
        }

        if (ci % 4 != 1)
            return;

        for (int i = 0; i < ge; i++)
        {
            Rigidbody tr6 = Instantiate(r, transform.position, transform.rotation);
            Vector3 vv = new Vector3((float)(tr6.position.x + 70 * Math.Sin(360 / ge * i * Math.PI / 180)), 15.9f, (float)(tr6.transform.position.z + 70 * Math.Cos(360 / ge * i * Math.PI / 180)));
            tr6.position = vv;
            


            vv = player.position - tr6.position;
            vv.Normalize();
            tr6.velocity = tr6.transform.TransformDirection(vv * 200);
            Destroy(tr6.gameObject, 20);
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
                fen.score += 45;
                camera1.zhendong();
            }

            s.value = xi / 900.0f;
        }

    }
}
