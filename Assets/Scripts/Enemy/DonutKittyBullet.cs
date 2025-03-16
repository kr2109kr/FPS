using UnityEngine;

public class DonutKittyBullet : MonoBehaviour
{
    private Vector3 shootDir;

    [SerializeField] private int damage;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }



    
}
