using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullerPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float bulletVelocity = 30f;
    [SerializeField] private float bulletPrefabLifeTime = 3f;



    [SerializeField] private float reloadTime;
    [SerializeField] private int magazineSize, bulletLeft;
    [SerializeField] private bool isReloading;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magazineSize && isReloading == false)
        {
            Reload();
        }
    }

    private void FireWeapon()
    {
        bulletLeft--;



        GameObject bullet = Instantiate(bullerPrefab, bulletSpawn.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
    }




    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
    }

    private void ReloadCompleted()
    {
        bulletLeft = magazineSize;
        isReloading = false;
    }


    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
