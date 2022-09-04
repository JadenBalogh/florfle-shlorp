using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leader : FollowTarget
{
    [SerializeField] private float insultRadius = 2f;
    [SerializeField] private float insultDuration = 3f;
    [SerializeField] private LayerMask insultTargetMask;
    [SerializeField] private TextMeshProUGUI insultTextbox;

    protected List<Follower> followers = new List<Follower>();

    private bool canInsult = true;
    private bool hasPlayerBeenInsulted = false;

    protected virtual void FixedUpdate()
    {
        bool isPlayerInRange = Physics2D.OverlapCircle(transform.position, insultRadius, insultTargetMask);

        if (canInsult && !hasPlayerBeenInsulted && isPlayerInRange)
        {
            StartCoroutine(InsultTimer());
            isPlayerInRange = true;
        }

        if (!isPlayerInRange)
        {
            hasPlayerBeenInsulted = false;
        }
    }

    protected void AddFollower(Follower followerPrefab)
    {
        FollowTarget followTarget = followers.Count > 0 ? followers[followers.Count - 1] : this;
        Follower follower = Instantiate(followerPrefab, followTarget.PrevPos, Quaternion.identity);
        follower.FollowTarget = followTarget;
        followers.Add(follower);
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
