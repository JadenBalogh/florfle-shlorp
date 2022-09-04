using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGrass : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent<Player>(out Player player) && Random.value <= 0.01f)
        {
            Follower florfleShlorpPrefab = GameManager.FlorfleShlorpPrefabs[Random.Range(0, GameManager.FlorfleShlorpPrefabs.Count)];
            player.AddFollower(florfleShlorpPrefab);
        }
    }
}
