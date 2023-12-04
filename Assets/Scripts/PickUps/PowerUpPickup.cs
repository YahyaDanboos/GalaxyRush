using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public enum PowerUpTypes
    {
        ExtraLife,
        Shield,
        DoubleShot
    }

    public PowerUpTypes powerUp;

    [Header("Component References")]
    public Rigidbody2D powerUpRigidbody;

    [Header("Prefab References")]
    public AudioClip pickUpSFX;
    public PlaySoundAndDestroy oneShotSFXPlayer;

    [Header("Prefab References - Shield")]
    public PowerUpShield powerUpShield;

    [Header("Prefab References - Double Shot")]
    public GunData doubleShotGunData;

    float speed = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        powerUpRigidbody.position = powerUpRigidbody.position + Vector2.down * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (powerUp)
            {
                case PowerUpTypes.ExtraLife:
                    collision.gameObject.GetComponent<Health>().AddLife();
                    break;
                case PowerUpTypes.DoubleShot:
                    collision.gameObject.GetComponent<PlayerCombat>().ChangeGun(doubleShotGunData);
                    break;
                case PowerUpTypes.Shield:
                    Instantiate(powerUpShield, collision.transform.position, collision.transform.rotation, collision.transform);
                    break;
                default:
                    break;
            }

            // Play sound effect
            PlaySoundAndDestroy sfxPlayer = Instantiate(oneShotSFXPlayer);
            sfxPlayer.PlaySFX(pickUpSFX);

            Destroy(gameObject);                
        }
    }
}
