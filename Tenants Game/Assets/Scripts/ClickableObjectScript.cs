using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectScript : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite hoverSprite;
    
    List<Vector2> physicsShape = new List<Vector2>();

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite.GetPhysicsShape(0, physicsShape);
        GetComponent<PolygonCollider2D>().SetPath(0, physicsShape);
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = hoverSprite;
        
        GetComponent<SpriteRenderer>().sprite.GetPhysicsShape(0, physicsShape);
        GetComponent<PolygonCollider2D>().SetPath(0, physicsShape);
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        
        GetComponent<SpriteRenderer>().sprite.GetPhysicsShape(0, physicsShape);
        GetComponent<PolygonCollider2D>().SetPath(0, physicsShape);
    }
}
