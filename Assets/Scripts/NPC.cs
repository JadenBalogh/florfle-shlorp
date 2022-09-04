using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : FollowTarget
{
    [SerializeField] private float insultRadius = 2f;
    [SerializeField] private float insultDuration = 3f;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private TextMeshProUGUI insultTextbox;

    private bool canInsult = true;
    private bool hasPlayerBeenInsulted = false;

    protected override void Update()
    {
        float inputH = Mathf.Round(Mathf.PerlinNoise(Time.time, Time.unscaledTime + 100f) * 2f - 1);
        float inputV = Mathf.Round(Mathf.PerlinNoise(Time.unscaledTime - 100f, Time.time) * 2f - 1);

        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();
    }

    protected virtual void FixedUpdate()
    {
        bool isPlayerInRange = Physics2D.OverlapCircle(transform.position, insultRadius, playerMask);

        if (canInsult && hasPlayerBeenInsulted && isPlayerInRange)
        {
            StartCoroutine(InsultTimer());
            isPlayerInRange = true;
        }

        if (!isPlayerInRange)
        {
            hasPlayerBeenInsulted = false;
        }
    }

    private IEnumerator InsultTimer()
    {
        insultTextbox.text = "\"Nerd!\"";
        canInsult = false;

        yield return new WaitForSeconds(insultDuration);

        insultTextbox.text = "";
        canInsult = true;
    }
}
