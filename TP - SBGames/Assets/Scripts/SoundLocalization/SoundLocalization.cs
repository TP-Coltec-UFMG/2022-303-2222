using System.Collections.Generic;
using UnityEngine;

public class SoundLocalization : MonoBehaviour
{
    [SerializeField] AudioSource rightAudio;
    [SerializeField] AudioSource leftAudio;
    [SerializeField] AudioSource upAudio;
    [SerializeField] AudioSource downAudio;
    [SerializeField] AudioSource downRightAudio;
    [SerializeField] AudioSource downLeftAudio;
    [SerializeField] AudioSource upRightAudio;
    [SerializeField] AudioSource upLeftAudio;
    RaycastHit2D rightRay, leftRay, upRay, downRay;
    [SerializeField] float rayDistance = 2f;
    Vector2 rightPivot, leftPivot, upPivot, downPivot;
    public bool EnableAudioLocalization = true;
    public bool anyAudioPlaying = false;
    [SerializeField] float maxTime;
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(2,2);
    } 

    void Update()
    {        
        rightPivot = new Vector2(transform.position.x + 0.25f, transform.position.y); 
        leftPivot = new Vector2(transform.position.x - 0.25f, transform.position.y);
        upPivot = new Vector2(transform.position.x, transform.position.y + 0.25f);
        downPivot = new Vector2(transform.position.x, transform.position.y - 0.25f);
        
        rightRay = Physics2D.Raycast(rightPivot, transform.right, rayDistance);
        leftRay = Physics2D.Raycast(leftPivot, - transform.right, rayDistance);
        upRay = Physics2D.Raycast(upPivot, transform.up, rayDistance);
        downRay = Physics2D.Raycast(downPivot, - transform.up, rayDistance);

        if(EnableAudioLocalization) AudioController();
    }

    void AudioController()
    {
        if(rightRay.collider != null && leftRay.collider != null && upRay.collider != null && downRay.collider != null)
        {
            if(rightRay.collider.CompareTag("CollidableAudio") && leftRay.collider.CompareTag("CollidableAudio") && upRay.collider.CompareTag("CollidableAudio") && downRay.collider.CompareTag("CollidableAudio"))
            {
                rightAudio.Stop();
                leftAudio.Stop();
                upAudio.Stop();
                downAudio.Stop();
                upRightAudio.Stop();
                upLeftAudio.Stop();
                downRightAudio.Stop();
                downLeftAudio.Stop();

                ExitSound.exitMaze = true;
            }
        }



        if(upRay.collider != null && rightRay.collider != null)
        {
            if(!upRightAudio.isPlaying)
            {
                upRightAudio.Play();
                Debug.Log("Up Right");
            }
            return;
        }

        if(upRay.collider != null && leftRay.collider != null)
        {
            if(!upLeftAudio.isPlaying)
            {
                upLeftAudio.Play();
                Debug.Log("Up Left");
            }
            return;
        }

        if(downRay.collider != null && rightRay.collider != null)
        {
            if(!downRightAudio.isPlaying)
            {
                downRightAudio.Play();
                Debug.Log("Down Right");
            }
            return;
        }

        if(downRay.collider != null && leftRay.collider != null)
        {
            if(!downLeftAudio.isPlaying)
            {
                downLeftAudio.Play();
                Debug.Log("Down Left");
            }
            return;
        }

        if(rightRay.collider != null)
        {
            if(!rightAudio.isPlaying)
            {
                rightAudio.Play();
                Debug.Log("Right");
            } 
        }

        if(leftRay.collider != null) 
        {
            if(!leftAudio.isPlaying)
            {
                leftAudio.Play();
                Debug.Log("Left");
            }
        }

        if(upRay.collider != null) 
        {            
            if(!upAudio.isPlaying)
            {
                upAudio.Play();
                Debug.Log("Up");
            }
        }

        if(downRay.collider != null) 
        {
            if(!downAudio.isPlaying)
            {
                downAudio.Play();
                Debug.Log("Down");
            }
        }

    } 
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector2(transform.position.x + 0.25f, transform.position.y), transform.right * rayDistance);
        Gizmos.DrawRay(new Vector2(transform.position.x - 0.25f, transform.position.y), - transform.right * rayDistance);
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.25f), transform.up * rayDistance);
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), - transform.up * rayDistance);
    }

}