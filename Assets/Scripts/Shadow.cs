using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    public static bool inShadow = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Jetpack")
        {
            inShadow = true;
            Sun.inSun = false;
        }
    }


}