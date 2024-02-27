using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPos;
    public float fireforce = 20f;
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            shoot();
        }
    
    }

    void shoot()
    {
        Instantiate(Bullet, BulletPos.position, BulletPos.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(BulletPos.up * fireforce, ForceMode2D.Impulse);
    }
}
