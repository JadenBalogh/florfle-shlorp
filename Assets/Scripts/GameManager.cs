using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private Tilemap tilemap;
    public static Tilemap Tilemap { get => instance.tilemap; }

    [SerializeField] private List<Follower> florfleShlorpPrefabs;
    public static List<Follower> FlorfleShlorpPrefabs { get => instance.florfleShlorpPrefabs; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
}
