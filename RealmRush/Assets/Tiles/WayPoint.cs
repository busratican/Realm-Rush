using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    //Property
    public bool IsPlaceable { 
        get { 
            return isPlaceable; 
            } 
    }
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
