using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        PrintWayPointNames();
        StartCoroutine(PrintWayPointNames());
    }

    IEnumerator PrintWayPointNames()
    {
        foreach (WayPoint wayPoint in path)
        {
            Vector3 startPoint = transform.position;
            Vector3 endPoint = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPoint);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPoint, endPoint, travelPercent);
                 yield return new WaitForEndOfFrame();
            }
        }
    }
}
