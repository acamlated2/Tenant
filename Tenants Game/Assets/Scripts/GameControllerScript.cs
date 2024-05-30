using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    public void SendTenant(TenantScript.RoomNumber senderNumber)
    {
        var testNumber = TenantControllerScript.Instance.displayedTenant.GetComponent<TenantScript>()
                                               .roomNumber;
        
        Debug.Log("sender: " + senderNumber + " displayed: " + testNumber);
        if (senderNumber == testNumber)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("wrong");
        }
        
        TenantControllerScript.Instance.RemoveTenant();
    }
}
