using System.Collections;
using UnityEngine;

public class Dorayaki : Enemy
{
    [SerializeField] private float radius_1;
    [SerializeField] private float radius_2;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int damage;
    [SerializeField] private float detonationTimer;

    [SerializeField] private bool isDetonated;


    [SerializeField] private ParticleSystem detonationEffect;

    private void Start()
    {
        base.currentHealth = base.maxHealth;
    }

    private void Update()
    {

        Collider[] hitColliders_2 = Physics.OverlapSphere(transform.position, radius_2, layerMask);

        if (hitColliders_2.Length != 0)
        {
            if (!isDetonated)
            {
                Detonation();
            }
            
        }

        if (!isDetonated)
        {
            
        }

        else
        {
            if (detonationEffect.isStopped)
            {
                Die();
                Destroy(gameObject);
            }
        }
    }

    private void Detonation()
    {
        detonationEffect.Play();

        GetComponent<MeshRenderer>().enabled = false;

        isDetonated = true;
        Collider[] hitColliders_2 = Physics.OverlapSphere(transform.position, radius_2, layerMask);
        
        if (hitColliders_2.Length != 0)
        {
            hitColliders_2[0].GetComponent<Player>().TakeDamage(damage);
        }

    }

}
