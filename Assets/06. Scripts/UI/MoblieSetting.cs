using UnityEngine;
using System.Collections;

public class MoblieSetting : MonoBehaviour {
    private bool exit = false;
    private float time = 0.0f;

    void Awake () {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.SetResolution(Screen.width, Screen.width * 16 / 10, true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update () {
        ExitApplication();
    }

    void ExitApplication () {
        if (exit) {
            time = +Time.deltaTime;
            if(time >= 1f) {
                exit = false;
                time = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!exit) {
                exit = true;
            }
            else {
                Application.Quit();
            }
        }
    }
}
