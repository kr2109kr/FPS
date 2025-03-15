using System;
using UnityEngine;
using UnityEngine.UI;

public class LaserGun : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] int damage;
    [SerializeField] Camera fpsCam;


    [SerializeField] private float reloadTime;
    [SerializeField] private int magazineSize, bulletLeft;
    [SerializeField] private bool isReloading;

    [SerializeField] private Text ammoDisplay;


    private void Start()
    {
        ammoDisplay.text = bulletLeft.ToString();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletLeft > 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magazineSize && isReloading == false)
        {
            Reload();
        }

        if (ammoDisplay != null)
        {
            ammoDisplay.text = $"{bulletLeft} / {magazineSize}";
        }

    }

    private void Shoot()
    {

        bulletLeft--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        }

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

}
