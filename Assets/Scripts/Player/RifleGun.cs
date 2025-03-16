using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RifleGun : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] int damage;
    [SerializeField] Camera fpsCam;

    [SerializeField] private GameObject hitImpactEffect;
    [SerializeField] private Vector3 hitImpactEffectOffset;

    [SerializeField] private ParticleSystem muzzleFlashEffect;


    [SerializeField] private float reloadTime;
    [SerializeField] private int magazineSize, bulletLeft;
    [SerializeField] private bool isReloading;

    [SerializeField] private Text ammoDisplay;

    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(audioClip);

        muzzleFlashEffect.Play();

        bulletLeft--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            //Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject hitImpactGameObject =  Instantiate(hitImpactEffect, hit.point + hitImpactEffectOffset, Quaternion.LookRotation(hit.normal));

            Destroy(hitImpactGameObject, 2f);
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
