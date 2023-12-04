using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIPlayerLives : MonoBehaviour
{
    public GameObject[] playerLiveSprites;

    int playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the Game Manager add Player Life event
        GameManager.addPlayerLife += OnAddPlayerLife;
        GameManager.removePlayerLife += OnRemovePlayerLife;
    }

    void OnDestroy()
    {
        // Unsubscribe from the Game Manager add Player Life event
        GameManager.addPlayerLife -= OnAddPlayerLife;
        GameManager.removePlayerLife -= OnRemovePlayerLife;
    }

    // Add player life
    void OnAddPlayerLife()
    {
        playerLives++;
        playerLiveSprites[playerLives - 1].SetActive(true);
    }

    // Remove player life
    void OnRemovePlayerLife()
    {
        playerLives--;
        playerLiveSprites[playerLives].SetActive(false);
    }
}
