using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    AttackController[] weapons;

    AttackController _currentWeapon;

    int _selectedWeapon;

    public void Start()
    {
        _selectedWeapon = 0;
        SelectedWeapon();
    }

    private void Update()
    {
        HandleScrollWheel();
        HandleAttack();
    }

    private void HandleScrollWheel()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0F)
        {
            _selectedWeapon = scrollWheel > 0.0F
                ? _selectedWeapon + 1
                : _selectedWeapon - 1;

            if (_selectedWeapon >= weapons.Length)
            {
                _selectedWeapon = 0;
            }
            else if (_selectedWeapon < 0)
            {
                _selectedWeapon = weapons.Length - 1;
            }

            SelectedWeapon();
        }
    }

    private void HandleAttack()
    {
        if (_currentWeapon != null && Input.GetButtonDown("Fire1"))
        {
            _currentWeapon.Attack();
        }
    }

    private void SelectedWeapon()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            AttackController controller = weapons[index];
            bool isActive = (_selectedWeapon == index);
            controller.gameObject.SetActive(isActive);

            if (isActive)
            {

                _currentWeapon = controller;
            }
        }
    }


}
