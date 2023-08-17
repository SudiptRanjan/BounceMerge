using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPowerUp : MonoBehaviour
{
    private float power = 20;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    public void ShootExplosive(Transform firePoint, Vector3 dir)
    {
        GameObject newBomb = Instantiate(gameObject, firePoint.position, firePoint.rotation);
        newBomb.transform.position = firePoint.transform.position;
        rb.velocity = dir * power;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

    }
    //public void ExplosionPowerUp()
    //{
    //    ExplosionPowerUp newExplosionPowerUp = Instantiate(explosionPrefab, firingPoint.position, firingPoint.rotation);
    //    newExplosionPowerUp.rb.velocity = firingPoint.transform.up * power;
    //}

}
