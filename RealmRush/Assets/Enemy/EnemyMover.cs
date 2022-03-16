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
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();
        
        GameObject[] points = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject wayPoint in points)
        {
            path.Add(wayPoint.GetComponent<WayPoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
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

        Destroy(gameObject);
    }
}
