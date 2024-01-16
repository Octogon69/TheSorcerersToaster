using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firepoint;
    public float fireforce = 20f;

    public void Fire()
    {
        GameObject fireball = Instantiate(fireballPrefab, firepoint.position, firepoint.rotation);
    }
}
