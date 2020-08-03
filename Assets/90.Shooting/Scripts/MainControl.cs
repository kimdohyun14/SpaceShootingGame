using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    static public int Score = 0;
    static public int Life = 3;
    public GUISkin mySkin = null;

    private void OnGUI()
    {
        // skin 변경
        GUI.skin = mySkin;
        Rect labelRect1 = new Rect(10.0f, 10.0f, 400.0f, 100.0f); // 위치x, y, 폭, 높이
        GUI.Label(labelRect1, "SCORE :" + MainControl.Score);
        Rect labelRect2 = new Rect(10.0f, 110.0f, 400.0f, 100.0f);
        GUI.Label(labelRect2, "LIFE :" + MainControl.Life);
    }

    // Update is called once per frame
    void Update()
    {
        if(MainControl.Score > 500)
        {
            MainControl.Life = 3;
            MainControl.Score = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("victory");
        }

        if(MainControl.Life <= 0)
        {
            MainControl.Life = 3;
            MainControl.Score = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("victory");
        }
    }
}
