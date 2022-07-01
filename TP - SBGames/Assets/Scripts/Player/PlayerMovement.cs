using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 1000)] [SerializeField] float speed;
    Rigidbody2D rig;
    float xInput, yInput;
    Vector2 moveDir;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(xInput, yInput);
    }

    void FixedUpdate() 
    {
        rig.velocity = moveDir * speed * Time.deltaTime;    
    }
}
