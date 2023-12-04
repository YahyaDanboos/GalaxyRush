using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Component References")]
    public Gun gun;

    // Infrom the gun that it can shoot
    public void Shoot(bool isShoot)
    {
        gun.TopggleShooting(isShoot);
    }

    public void ChangeGun(GunData gunData)
    {
        gun.gunData = gunData;
    }
}
