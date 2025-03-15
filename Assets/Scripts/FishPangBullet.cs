using UnityEngine;

public class FishPangBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifetime;


    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
