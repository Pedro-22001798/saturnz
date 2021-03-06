using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform followTarget;
    [SerializeField] float followSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        if (followTarget != null)
        {
            Vector3 targetPos = followTarget.position;
            Vector3 error = targetPos - currentPos;

            targetPos = currentPos + error * followSpeed;

            currentPos = new Vector3(targetPos.x, targetPos.y, currentPos.z);
        }


        transform.position = currentPos;

    }
}
