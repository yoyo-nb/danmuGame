using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class camera1 : MonoBehaviour
{
    public Transform play;
    bool flag = false;
    static int count;
    Vector3 plast,plast2;
    int end = 0;
    Vector3 t;
    Vector3 tyuan = new Vector3(-51, 369.7f, 66);
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene("Main2");
        count = -40;
        t = transform.position;
    }
    public static void zhendong()
    {
        count = -5;
    }
    // Update is called once per frame
    void Update()
    {
        if (play != null)
        {
            plast = play.position;
            plast2 = play.right;
        }
        if (count != -40)
        {
            Vector3 p = new Vector3((float)(t.x + 7 * Math.Sin(count * 36 * Math.PI / 180)), t.y, (float)(t.z + 7 * Math.Cos(count * 36 * Math.PI / 180)));
            transform.position = p;
            count++;
            if (count == 5)
                count = -40;
        }
        else
            transform.position = t;

        if (Input.GetMouseButtonDown(0))
            flag = true;
        if (Input.GetMouseButtonUp(0))
            flag = false;
        if (flag)
        {
            transform.RotateAround(play.position, play.right, -Input.GetAxis("Mouse Y") * 10);
            transform.RotateAround(play.position, play.up, -Input.GetAxis("Mouse X") * 10);
            t = transform.position;
        }
        if (Time.timeScale == 1)
            return;
        if (end == 100)
            return;
        end++;
       
        transform.RotateAround(plast, plast2, -end/150.0f);
        tyuan += Vector3.up * 1;
        tyuan += Vector3.back * 6;
        transform.position = tyuan;
        t = tyuan;
    }
}
