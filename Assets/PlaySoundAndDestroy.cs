using UnityEngine;

public class PlaySoundAndDestroy : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySFX (AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
        Destroy(gameObject, sfx.length);
    }
}
