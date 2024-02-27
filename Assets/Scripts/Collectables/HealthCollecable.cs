using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollecable : MonoBehaviour, CollectableBehaviour
{
    [SerializeField]
    private float _healthAmount;

   public void onCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(_healthAmount);

    }
}
