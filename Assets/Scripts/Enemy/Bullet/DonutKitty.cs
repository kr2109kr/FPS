using System.Collections;

using UnityEngine;

public class DonutKitty : Enemy
{

    //[SerializeField] private Vector3 position;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float shootDelay;
    [SerializeField] private ParticleSystem chargeEffect;

    bool isPlayerInRange;

    [SerializeField] private Vector3 firePoint;
    [SerializeField] private GameObject bullerPrefab;

    private bool isCharging;
    Coroutine shootCoroutine;

    private void Start()
    {
        base.currentHealth = base.maxHealth;
    }


    private void Update()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (hitColliders.Length != 0)
        {
            RaycastHit hit;
            isPlayerInRange = true;

            

            transform.LookAt(hitColliders[0].transform);

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (!isCharging)
                {
                    chargeEffect.Play();
                    isCharging = true;
                }

                else
                {
                    if (chargeEffect.isStopped)
                    {
                        Shoot(bullerPrefab.transform);
                        isCharging = false;
                    }
                }

            }
        }


    }




    private void Shoot(Transform bullet)
    {
        Transform bulletTransform = Instantiate(bullet, transform.localPosition + firePoint, transform.rotation);
        


    }



}
