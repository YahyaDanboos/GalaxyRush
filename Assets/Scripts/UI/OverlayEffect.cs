using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayEffect : MonoBehaviour
{
    public Animation animationPlayer;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.addPlayerLife += OnAddPlayerLife;
        GameManager.removePlayerLife += OnRemovePlayerLife;
    }

    void OnDestroy()
    {
        GameManager.addPlayerLife -= OnAddPlayerLife;
        GameManager.removePlayerLife -= OnRemovePlayerLife;
    }

    // Player Life Added Effect
    void OnAddPlayerLife()
    {
        animationPlayer.Play("Anim_UI_Overlay_GetPowerUp");
    }

    // Player Life Removed Effect
    void OnRemovePlayerLife()
    {
        animationPlayer.Play("Anim_UI_Overlay_Damaged");
    }
}
