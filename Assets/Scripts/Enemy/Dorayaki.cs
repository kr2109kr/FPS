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

    private CapsuleCollider capsuleCollider;


    [SerializeField] private ParticleSystem detonationEffect;

    private AudioSource audioSource;
    [SerializeField] private AudioClip detonationAudioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

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
                Die();
            }
            
        }

        if (!isDetonated)
        {
            
        }

        else
        {
            if (detonationEffect.isStopped)
            {
                EnemyManager.Instance.EnemyCountDecrease();
                Destroy(gameObject);
            }
        }
    }

    private void Detonation()
    {
        audioSource.PlayOneShot(detonationAudioClip);
        detonationEffect.Play();

        GetComponent<MeshRenderer>().enabled = false;

        isDetonated = true;
        Collider[] hitColliders_2 = Physics.OverlapSphere(transform.position, radius_2, layerMask);
        
        if (hitColliders_2.Length != 0)
        {
            hitColliders_2[0].GetComponent<Player>().TakeDamage(damage);
        }

        base.healthBar.gameObject.SetActive(false);
        capsuleCollider.enabled = false;

    }


    protected override void Die() 
    {
        Detonation();
    }
}
