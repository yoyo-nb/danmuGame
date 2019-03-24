using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fen : MonoBehaviour
{
    static public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string a = score.ToString();
        GetComponent<Text>().text = "得分： " + a;

    }
}
