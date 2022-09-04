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

    [SerializeField] private List<Insult> insults;
    public static List<Insult> Insults { get => instance.insults; }

    [SerializeField] private List<Insult> replies;
    public static List<Insult> Replies { get => instance.replies; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
}
