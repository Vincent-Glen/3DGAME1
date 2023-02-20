using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timertext;
    private float starttime;
    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
     float t = Time.time - starttime;

     string minutes = ((int) t / 60). ToString("f1");
     string seconds = (t % 60).ToString("f2");
     timertext.text = minutes +":" + seconds;   
    }
}
