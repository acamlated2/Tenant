using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenantControllerScript : MonoBehaviour
{
    public static TenantControllerScript Instance;
    
    public GameObject displayedTenant;

    [SerializeField] private GameObject tenantPrefab;

    private Vector3 _entryPos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;

        if (!displayedTenant)
        {
            DisplayTenant();
        }

        _entryPos = GameObject.FindGameObjectWithTag("Tenant Entry Point").transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            DisplayTenant();
        }

        if (Input.GetKeyDown("x"))
        {
            RemoveTenant();
        }

        if (!displayedTenant)
        {
            DisplayTenant();
        }
    }

    private void DisplayTenant()
    {
        GameObject newTenant = Instantiate(tenantPrefab);
        newTenant.transform.position = _entryPos;
        newTenant.GetComponent<TenantScript>().InitiateTenant();
        newTenant.GetComponent<AnimateTenantScript>().EnterScene();
        displayedTenant = newTenant;
    }

    public void RemoveTenant()
    {
        displayedTenant.GetComponent<AnimateTenantScript>().ExitScene();
    }
}
