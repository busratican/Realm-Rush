using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable = false;
    [SerializeField] GameObject Tower;


    void OnMouseDown() 
    {
        if(isPlaceable)
        {
            Instantiate(Tower, transform.position, Quaternion.identity);
            isPlaceable = false; // Not instantiate in same place
        }
    }
}
