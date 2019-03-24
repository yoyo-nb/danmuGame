using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class move : MonoBehaviour
{
    public Slider s;
    public Image i1, i2;
    float speed = 200;
    int xie = 20;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        xie--;
        s.value = xie / 20.0f;
        if (xie <= 0)
        {
            Destroy(this.gameObject);
            if (fen.score >= 1500)
                i1.transform.localScale = new Vector3(2, 2, 0.5f);
            else
                i2.transform.localScale = new Vector3(2, 2, 0.5f);
            t.text = "GAME OVER\nYour score:\n" + fen.score.ToString()+"\nPress \"R\" to start";
            Time.timeScale = 0;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
            speed = 100;
        else
            speed = 200;
        Transform t = transform;
        t.Translate(Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);
        t.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed);
        
    }
 
}
