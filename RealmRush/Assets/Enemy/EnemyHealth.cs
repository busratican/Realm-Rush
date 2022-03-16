using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Add amount to maxHitPoints when enemy dies.")]
    [SerializeField] int diffucultyRamp = 1;
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
             maxHitPoints += diffucultyRamp;
             enemy.Reward();
        }
    }

 
}
