using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Leader
{
    protected override void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Follower florfleShlorpPrefab = GameManager.FlorfleShlorpPrefabs[Random.Range(0, GameManager.FlorfleShlorpPrefabs.Count)];
            AddFollower(florfleShlorpPrefab);
        }
    }
}
