using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : FollowTarget
{
    protected override void Update()
    {
        float inputH = Mathf.Round(Mathf.PerlinNoise(Time.time, Time.unscaledTime + 100f) * 2f - 1);
        float inputV = Mathf.Round(Mathf.PerlinNoise(Time.unscaledTime - 100f, Time.time) * 2f - 1);

        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();
    }
}
