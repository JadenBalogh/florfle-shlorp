using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private float moveTime = 0.3f;

    public Vector2 TargetPos { get; protected set; }
    public Vector2 PrevPos { get; private set; }

    private Vector3Int prevTile;
    private Vector2 currVel;

    protected virtual void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        Vector3Int currTile = tilemap.WorldToCell(transform.position);
        Vector3Int targetTile = tilemap.WorldToCell(TargetPos);
        Vector2 targetPos = tilemap.CellToWorld(targetTile) + Vector3.one * 0.5f;

        if (targetTile == currTile)
        {
            PrevPos = tilemap.CellToWorld(prevTile) + Vector3.one * 0.5f;
        }

        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref currVel, moveTime);

        prevTile = currTile;
    }
}
