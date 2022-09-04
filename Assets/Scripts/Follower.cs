using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : FollowTarget
{
    public FollowTarget FollowTarget { get; set; }

    protected override void Update()
    {
        TargetPos = FollowTarget.PrevPos;

        base.Update();
    }
}
