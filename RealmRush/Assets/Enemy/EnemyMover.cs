using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waitTime = 1f;
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
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
