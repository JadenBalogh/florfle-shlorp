using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Leader
{
    [SerializeField] private Sprite leftFlipSprite;
    [SerializeField] private Sprite rightFlipSprite;
    [SerializeField] private Sprite topFlipSprite;
    [SerializeField] private Sprite bottomFlipSprite;

    private bool isFlippingOff = false;

    protected override void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        targetDir = new Vector2(inputH, inputV);
        TargetPos = transform.position + Vector3.right * inputH + Vector3.up * inputV;

        base.Update();

        isFlippingOff = Input.GetKey(KeyCode.Space);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Follower florfleShlorpPrefab = GameManager.FlorfleShlorpPrefabs[Random.Range(0, GameManager.FlorfleShlorpPrefabs.Count)];
            AddFollower(florfleShlorpPrefab);
        }
    }

    protected override void UpdateSprite()
    {
        if (isFlippingOff)
        {
            if (targetDir.x > 0)
            {
                spriteRenderer.sprite = rightFlipSprite;
            }
            else if (targetDir.x < 0)
            {
                spriteRenderer.sprite = leftFlipSprite;
            }
            else if (targetDir.y > 0)
            {
                spriteRenderer.sprite = topFlipSprite;
            }
            else if (targetDir.y <= 0)
            {
                spriteRenderer.sprite = bottomFlipSprite;
            }
        }
        else
        {
            base.UpdateSprite();
        }
    }
}
