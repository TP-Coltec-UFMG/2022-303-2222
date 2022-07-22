using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float speed;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask wallCollisionLayer;
    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        float xAxisInput = Input.GetAxisRaw("Horizontal");
        float yAxisInput = Input.GetAxisRaw("Vertical");

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(xAxisInput, 0f, 0f), .2f, wallCollisionLayer))
            {
                if((Mathf.Abs(xAxisInput) == 1f))
                {
                    movePoint.position += new Vector3(xAxisInput, 0f, 0f);
                    do{
                        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
                    }while(Vector3.Distance(transform.position, movePoint.position) > .05f);
                }
            }
            
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, yAxisInput, 0f), .2f, wallCollisionLayer))
            {
                if(Mathf.Abs(yAxisInput) == 1f)
                {
                    movePoint.position += new Vector3(0f, yAxisInput, 0f); 
                    do{
                        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
                    }while(Vector3.Distance(transform.position, movePoint.position) > .05f);             
                }
            }
        }
    }


}
