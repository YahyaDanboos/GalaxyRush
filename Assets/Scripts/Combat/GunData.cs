using UnityEngine;

[CreateAssetMenu(fileName = "NewGunData", menuName = "Gun Data", order = 51)]
public class GunData : ScriptableObject
{
    [Tooltip("Prefab of the bullet that this gun fires.")]
    public Bullet bulletPrefab;

    [Tooltip("The attack power for the gun.")]
    public int attackPower;

    [Tooltip("The rate of fire for the gun.")]
    public float fireRate;

    [Tooltip("The number of bullets spawned per shot.")]
    public int bulletsPerShot;

    [Tooltip("Sound played when the gun is fired.")]
    public AudioClip fireSound;
}
