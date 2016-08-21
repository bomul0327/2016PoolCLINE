using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Logo : MonoBehaviour {
    public Image fade;
    float fades = 0.0f;
    float time = 0;
    Vector3 upMax;
    Vector3 upMin;  //벡터값 미니멈이 맥스에 닿을 때 까지 만들기위한 변수
    private Transform tr;

	void Start () {
        upMax.x = 0;
        upMax.y = 3;
        upMax.z = 0;
        upMin.x = 0;
        upMin.y = 1;
        upMin.z = 0;

        tr = GetComponent<Transform>();
	}

	void Update () {
        time += Time.deltaTime;
        if (fades >= 0.0f&& time >= 0.1f)
        {
            fades += 0.1f;
            fade.color = new Color(255, 0,0, fades);
            time = 0;
        }
        else if (fades >= 1.0f)
        {
            time = 0;
         
           if (upMin.y <= upMax.y)
            {
                upMin.y += 0.1f;
              tr.Translate(upMin, Space.Self);
            
            }
        }
	}

}
