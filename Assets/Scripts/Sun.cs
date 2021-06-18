using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public static bool inSun = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Jetpack")
        {
            inSun = true;
            Shadow.inShadow = false;
        }
    }





}
