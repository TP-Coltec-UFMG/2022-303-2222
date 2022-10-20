using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float speed = 1f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask wallCollisionLayer;
    float xAxisInput, yAxisInput;
    void Start()
    {
        movePoint.parent = null;
    }

    void DelayAfterMovement()
    {
        const float delayTime = 3000;
        float time_marker = delayTime;

        while (time_marker > 0)
        {
            time_marker -= Time.deltaTime;
        }
        
        Debug.Log("acabou");
    }

    void Update()
    {
        movePoint.transform.position = gameObject.transform.position;

        if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            xAxisInput = 1;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            xAxisInput = -1;
        }
        else xAxisInput = 0;

        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            yAxisInput = 1;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            yAxisInput = -1;
        } 
        else yAxisInput = 0;


        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(xAxisInput, 0f, 0f), .2f, wallCollisionLayer))
            {
                if((Mathf.Abs(xAxisInput) == 1f))
                {
                    movePoint.position += new Vector3(xAxisInput, 0f, 0f);
                    do
                    {
                        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
                    }
                    while(Vector3.Distance(transform.position, movePoint.position) > 0);
                }
            }
            
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, yAxisInput, 0f), .2f, wallCollisionLayer))
            {
                if(Mathf.Abs(yAxisInput) == 1f)
                {
                    movePoint.position += new Vector3(0f, yAxisInput, 0f); 
                    do
                    {
                        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
                    }
                    while(Vector3.Distance(transform.position, movePoint.position) > 0);             
                }
            }
        }
        DelayAfterMovement();
    }


}
