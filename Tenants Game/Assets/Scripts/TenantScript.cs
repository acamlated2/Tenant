using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TenantScript : MonoBehaviour
{
    public enum RoomNumber
    {
        Room1, 
        Room2, 
        Room3, 
        Room4, 
        Room5, 
    }

    public RoomNumber roomNumber = RoomNumber.Room1;

    [SerializeField] private Sprite[] tenantSprites;

    public void InitiateTenant()
    {
        int randInt = GetRandomEnumIndex();

        GetComponent<SpriteRenderer>().sprite = tenantSprites[randInt];
    }
    
    public static int GetRandomEnumIndex()
    {
        var values = Enum.GetValues(typeof(RoomNumber));
        return Random.Range(0, values.Length);
    }
}
