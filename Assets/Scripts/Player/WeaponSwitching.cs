using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    [SerializeField] private GameObject weapon;
    int selectedWeapon = 0;

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {

        }
    }
}
