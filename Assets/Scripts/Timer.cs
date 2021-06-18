using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    public static float startTime;
    public static float t;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Circle.timer_enabled)
        {
            t = 35 - (Time.time - startTime);

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
			
			

        }
        else
        {
            Debug.Log("Ganhaste!");
        }
    }

    public static void reset_timer()
    {
        startTime = Time.time;
    }
}
