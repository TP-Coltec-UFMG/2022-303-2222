using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float speed = 1f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask wallCollisionLayer;
    private float xAxisInput;
    private float yAxisInput;
    
    private float timer = 0;
    private bool playerCanMove = true;
    private const float MAX_TIME = 1;

    private SoundLocalization soundLocalizationScript;

    void Start()
    {
        soundLocalizationScript = GetComponent<SoundLocalization>();
        movePoint.parent = null;
    }

    void PlayTutorialAudio()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!soundLocalizationScript.tutorialAudio.isPlaying)
            {
                soundLocalizationScript.PlayTutorialAudio();
            }
        }
    }

    void MovePlayer()
    {
        if (!playerCanMove)
        {
            return;
        }
        
        Vector3 previousPosition = gameObject.transform.position;
        movePoint.transform.position = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            xAxisInput = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xAxisInput = -1;
        }
        else xAxisInput = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            yAxisInput = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            yAxisInput = -1;
        }
        else yAxisInput = 0;


        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(xAxisInput, 0f, 0f), .2f, wallCollisionLayer))
            {
                if ((Mathf.Abs(xAxisInput) == 1f))
                {
                    movePoint.position += new Vector3(xAxisInput, 0f, 0f);
                    do
                    {
                        transform.position = Vector3.MoveTowards(transform.position, movePoint.position,
                            speed * Time.deltaTime);
                    } while (Vector3.Distance(transform.position, movePoint.position) > 0);
                }
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, yAxisInput, 0f), .2f, wallCollisionLayer))
            {
                if (Mathf.Abs(yAxisInput) == 1f)
                {
                    movePoint.position += new Vector3(0f, yAxisInput, 0f);
                    do
                    {
                        transform.position = Vector3.MoveTowards(transform.position, movePoint.position,
                            speed * Time.deltaTime);
                    } while (Vector3.Distance(transform.position, movePoint.position) > 0);
                }
            }
        }

        if (previousPosition != gameObject.transform.position)
        {
            playerCanMove = false;
        }
    }

    void Update()
    {
        PlayTutorialAudio();
        
        if (timer == 0 && !soundLocalizationScript.tutorialAudio.isPlaying)
        {
            playerCanMove = true;
        } 
        
        if(!soundLocalizationScript.tutorialAudio.isPlaying) MovePlayer();

        if (!playerCanMove && !soundLocalizationScript.tutorialAudio.isPlaying)
        {
            timer += Time.deltaTime;
        }
        
        if (timer >= MAX_TIME && !soundLocalizationScript.tutorialAudio.isPlaying)
        {
            timer = 0;
            playerCanMove = true;
        }
    }
}