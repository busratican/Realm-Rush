using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        HitEnemy();
    }
    void HitEnemy()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
             gameObject.SetActive(false);
             enemy.Reward();
        }
    }

 
}
