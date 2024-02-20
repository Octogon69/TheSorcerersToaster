using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float _damageAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.GetComponent<EnemyMovement>())
        {
            var HealthController = collision.gameObject.GetComponent<HealthController>();

            HealthController.TakeDamage(_damageAmount);


        }

        Destroy(gameObject);

    }
    
   
    
    
        
    
}
