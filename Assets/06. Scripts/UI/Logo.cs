using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {
    public UnityEngine.UI.Image fade;
    float fades = 0.0f;
    float time = 0;
    Vector3 UPmax;
    Vector3 UPmin;
    private Transform tr;
	// Use this for initialization
	void Start () {
        UPmax.x = 0;
        UPmax.y = 3;
        UPmax.z = 0;
        UPmin.x = 0;
        UPmin.y = 1;
        UPmin.z = 0;

        tr = GetComponent<Transform>();
	}
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (fades >= 0.0f&& time >= 0.1f)
        {
            fades += 0.1f;
            fade.color = new Color(0, 55, 55, fades);
            time = 0;
        }
        else if (fades >= 1.0f)
        {
            time = 0;
         
           if (UPmin.y <= UPmax.y)
            {
                UPmin.y += 0.1f;
              tr.Translate(UPmin, Space.Self);
            
            }
        }
	}

}
