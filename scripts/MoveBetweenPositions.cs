using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    [SerializeField]
    private float travelDurationDown = 1f,
                  travelDurationUp = 2f;

    [SerializeField]
    private float wait = 1f,
                  wait2 = 4f;

    private Vector3 pointA,
                    pointB;

    // start 
    private void Start()
    {
        // Points where the object is moving between
        // - Don't forget to change the positions to the positions you need -
        pointA = new Vector3(187.51f, 36.16f, 244.3f);
        pointB = new Vector3(187.51f, 31.03f, 244.3f);

        StartCoroutine(Timer());
    }

    // Move between points, with timer
    private IEnumerator Timer()
    {
        // Loop 
        while (Application.isPlaying)
        {
            //Travel from A to B
            float speed = 0f;
            while (speed < travelDurationDown)
            {
                transform.position = Vector3.Lerp(pointA, pointB, speed / travelDurationDown);
                speed += Time.deltaTime;
                yield return null;
            }

            // In case the counter isn't equal to the travelDuration
            transform.position = pointB;

            // wait
            yield return new WaitForSeconds(wait);

            //Travel back from B to A
            float speed2 = 0f;
            while (speed2 < travelDurationUp)
            {
                transform.position = Vector3.Lerp(pointB, pointA, speed2 / travelDurationUp);
                speed2 += Time.deltaTime;
                yield return null;
            }

            // In case the counter isn't equal to the travelDuration
            transform.position = pointA;

            // Finally, wait
            yield return new WaitForSeconds(wait2);
        }
    }
}
