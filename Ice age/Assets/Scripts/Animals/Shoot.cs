using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomjyEnternainment.IceAge;

public class Shoot : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootToMouse();
    }

    [SerializeField] private LayerMask layerMask;

    private void ShootToMouse()
    {
        var screenPos = Input.mousePosition;
        var ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.collider);
            hit.collider.GetComponent<HitBox>().Hit(1);
        }
    }

}
