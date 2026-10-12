
using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public Transform platformA;
    public Transform platformB;
    public float speed = 2f;
    public float waitTime = 1f;

    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            yield return StartCoroutine(MoveTo(platformB.position));

            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(MoveTo(platformA.position));

            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = target;
    }
}