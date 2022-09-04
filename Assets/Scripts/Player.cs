using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : FollowTarget
{
    [SerializeField] private Follower florfleShlorpPrefab;

    private List<Follower> followers = new List<Follower>();

    protected override void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FollowTarget followTarget = followers.Count > 0 ? followers[followers.Count - 1] : this;
            Follower follower = Instantiate(florfleShlorpPrefab, followTarget.PrevPos, Quaternion.identity);
            follower.FollowTarget = followTarget;
            followers.Add(follower);
        }
    }
}
