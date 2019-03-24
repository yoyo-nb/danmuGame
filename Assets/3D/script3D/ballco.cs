using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballco : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "rr")
        //{
        //   Destroy(collision.gameObject);
        //}
        if (this.gameObject.tag == "r5")
            return;
        Destroy(this.gameObject);
    }
}
