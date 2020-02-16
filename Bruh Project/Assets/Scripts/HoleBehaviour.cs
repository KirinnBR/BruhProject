using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehaviour : MonoBehaviour
{
    private Collider parent;
    private Transform playerTransform;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private float holeRadius = 3f;
    // Start is called before the first frame update
    private Vector3 playerPosition { get { return playerTransform.position; } }
    void Start()
    {
        transform.localScale = new Vector3(holeRadius, 0.01f, holeRadius);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(playerPosition, transform.position) > 40f)
            return;
        var colliders = Physics.OverlapSphere(transform.position, holeRadius/2, playerLayer, QueryTriggerInteraction.Ignore);
        foreach (var col in colliders)
        {
            if (col.transform.Equals(playerTransform))
            {
                parent.enabled = false;
                return;
            }
        }
        parent.enabled = true;
    }

    public void ConfigureHole(Collider parent, Transform player, LayerMask layer)
    {
        this.parent = parent;
        playerTransform = player;
        playerLayer = layer;
    }

}
