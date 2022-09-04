using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : FollowTarget
{
    protected override void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();
    }
}
