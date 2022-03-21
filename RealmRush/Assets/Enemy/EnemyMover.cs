using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    List<Node> path = new List<Node>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathFinder;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

     void Awake() 
     {
         enemy = GetComponent<Enemy>();
         pathFinder = FindObjectOfType<Pathfinder>();
         gridManager = FindObjectOfType<GridManager>();
     }

    void FindPath()
    {
        path.Clear();
        path = pathFinder.GetNewPath();
        
    }

    void FinishPath()
    {
        enemy.Penalty();
        gameObject.SetActive(false);
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for(int i=0; i<path.Count; i++)
        {
            Vector3 startPoint = transform.position;
            Vector3 endPoint = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPoint);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPoint, endPoint, travelPercent);
                 yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
