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
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite topSprite;
    [SerializeField] private Sprite bottomSprite;

    protected List<Follower> followers = new List<Follower>();
    protected Vector2 targetDir;

    private bool canInsult = true;
    private bool hasPlayerBeenInsulted = false;
    protected SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        base.Awake();
    }

    protected override void Update()
    {
        UpdateSprite();

        base.Update();
    }

    protected virtual void FixedUpdate()
    {
        Collider2D insultTarget = Physics2D.OverlapCircle(transform.position, insultRadius, insultTargetMask);
        bool hasInsultTarget = insultTarget;

        if (canInsult && !hasPlayerBeenInsulted && hasInsultTarget)
        {
            StartCoroutine(InsultTimer(insultTarget));
        }

        if (!hasInsultTarget)
        {
            hasPlayerBeenInsulted = false;
        }
    }

    protected virtual void UpdateSprite()
    {
        if (targetDir.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (targetDir.x < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else if (targetDir.y > 0)
        {
            spriteRenderer.sprite = topSprite;
        }
        else if (targetDir.y <= 0)
        {
            spriteRenderer.sprite = bottomSprite;
        }
    }

    protected void AddFollower(Follower followerPrefab)
    {
        FollowTarget followTarget = followers.Count > 0 ? followers[followers.Count - 1] : this;
        Follower follower = Instantiate(followerPrefab, followTarget.PrevPos, Quaternion.identity);
        follower.FollowTarget = followTarget;
        followers.Add(follower);
    }

    private IEnumerator InsultTimer(Collider2D insultTarget)
    {
        Leader targetLeader = insultTarget.GetComponent<Leader>();
        bool isInsulter = followers.Count >= targetLeader.followers.Count;
        Insult insult = GetRandomInsult(isInsulter);

        insultTextbox.text = "\"" + insult.insultText + "\"";
        canInsult = false;

        yield return new WaitForSeconds(insultDuration);

        insultTextbox.text = "";
        canInsult = true;
    }

    private Insult GetRandomInsult(bool isInsulter)
    {
        List<Insult> insultOptions = isInsulter ? GameManager.Insults : GameManager.Replies;
        return insultOptions[Random.Range(0, insultOptions.Count)];
    }
}
