using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bar : MonoBehaviour
{
    public Transform mt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 th = mt.position;
        th.z += 20;
        if (mt.localScale.z == 50)
            th.z += 30;
        Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, th);
        RectTransform re = GetComponent<RectTransform>();
        re.position = th;
    }
}
