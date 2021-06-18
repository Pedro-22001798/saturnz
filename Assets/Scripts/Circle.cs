using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public static bool timer_enabled = true;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Win")
        {
            Destroy(other.gameObject);
            timer_enabled = false;
        }
    }
}
