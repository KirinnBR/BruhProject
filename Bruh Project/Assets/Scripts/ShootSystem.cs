using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShootSystem : MonoBehaviour
{
    [SerializeField]
    private Transform weapon;
    [SerializeField]
    private LayerMask wallLayer;
    [SerializeField]
    private LayerMask entitiesLayer;
    [SerializeField]
    private GameObject holePrefab;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(weapon.position, weapon.forward, Color.red, 0f, false);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(weapon.position, weapon.forward, out RaycastHit hit, 100f, wallLayer, QueryTriggerInteraction.Ignore))
            {
                if (hit.transform.CompareTag("Destructable"))
                {
                    HoleBehaviour hole = Instantiate(holePrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)).GetComponent<HoleBehaviour>();
                    hole.ConfigureHole(hit.collider, transform, entitiesLayer);
                    Debug.Log("Destroyed.");
                }
                else
                {
                    Debug.Log("Non-destroyable obstacle.");
                }
            }
        }
    }
}
