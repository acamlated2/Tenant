using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : ClickableObjectScript
{
    public TenantScript.RoomNumber roomNumber;
    
    private void OnMouseDown()
    {
        GameControllerScript.Instance.SendTenant(roomNumber);
    }
}
