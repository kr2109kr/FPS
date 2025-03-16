using System;
using UnityEngine;

public class FishPang : Enemy
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletVelocity;

    private bool isCharging;
    [SerializeField] private ParticleSystem chargeEffect;
    [SerializeField] private Vector3 firePoint;



    private void Start()
    {
        base.currentHealth = base.maxHealth;
    }

    void Update()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);


        if (hitColliders.Length != 0)
        {
            transform.LookAt(hitColliders[0].transform);
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if(!isCharging)
                {
                chargeEffect.Play();
                isCharging = true;
            }

                else
            {
                if (chargeEffect.isStopped)
                {
                    FireWeapon();
                    isCharging = false;
                }
            }
        }
    }

    private void FireWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + firePoint, transform.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);

        
    }
}
