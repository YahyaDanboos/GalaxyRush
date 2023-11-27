using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
