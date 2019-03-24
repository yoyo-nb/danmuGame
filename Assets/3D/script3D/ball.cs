using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform t;
    public Rigidbody r;
    public Rigidbody k;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (Input.GetKey(KeyCode.J))
        {
            Vector3 v2 = new Vector3(-130, 0, 750);
            Vector3 v3 = new Vector3(+130, 0, 750);
            if(Input.GetKey(KeyCode.L))
            {
                v2 = new Vector3(0, 0, 750);
                v3 = new Vector3(0, 0, 750);
            }

            Rigidbody rr = (Rigidbody)Instantiate(r, t.position, t.rotation);
            rr.velocity = transform.TransformDirection(Vector3.forward * 750);
            Destroy(rr.gameObject, 4);
            Vector3 p2 = t.position;
            p2.x -= 6;
            Rigidbody r2 = (Rigidbody)Instantiate(r, p2, t.rotation);
            
            v2.Normalize();
            v2 *= 750;
            r2.velocity = transform.TransformDirection(v2);
            Destroy(r2.gameObject, 4);
            p2.x += 12;
            Rigidbody r3 = (Rigidbody)Instantiate(r,p2, t.rotation);
           
            v3.Normalize();
            v3 *= 750;
            r3.velocity = transform.TransformDirection(v3);
            Destroy(r3.gameObject, 4);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            Rigidbody rr = (Rigidbody)Instantiate(k, t.position, t.rotation);
            rr.velocity = transform.TransformDirection(Vector3.forward * 300);
            Destroy(rr.gameObject, 10);
        }
    }
}
