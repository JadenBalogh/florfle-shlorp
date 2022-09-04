using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : Leader
{
    [SerializeField] private int minStartFollowers = 1;
    [SerializeField] private int maxStartFollowers = 10;

    protected virtual void Start()
    {
        int numFollowers = Random.Range(minStartFollowers, maxStartFollowers);
        for (int i = 0; i < numFollowers; i++)
        {
            Follower florfleShlorpPrefab = GameManager.FlorfleShlorpPrefabs[Random.Range(0, GameManager.FlorfleShlorpPrefabs.Count)];
            AddFollower(florfleShlorpPrefab);
        }
    }

    protected override void Update()
    {
        float inputH = Mathf.Round(Mathf.PerlinNoise(Time.time, Time.unscaledTime + 100f) * 2f - 1);
        float inputV = Mathf.Round(Mathf.PerlinNoise(Time.unscaledTime - 100f, Time.time) * 2f - 1);

        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();
    }
}
