using UnityEngine;

public class SoundLocalization : MonoBehaviour
{
    [SerializeField] AudioSource rightAudio;
    [SerializeField] AudioSource leftAudio;
    [SerializeField] AudioSource upAudio;
    [SerializeField] AudioSource downAudio;
    RaycastHit2D rightRay, leftRay, upRay, downRay;
    [SerializeField][Range(0,2)] float rayDistance = 2f;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(2,2);
    } 

    void Update()
    {
        rightRay = Physics2D.Raycast(transform.position, transform.right, rayDistance);
        leftRay = Physics2D.Raycast(transform.position, - transform.right, rayDistance);
        upRay = Physics2D.Raycast(transform.position, transform.up, rayDistance);
        downRay = Physics2D.Raycast(transform.position, - transform.up, rayDistance);

        DebugRay();
        
        if(rightRay.collider != null) if(!rightAudio.isPlaying) rightAudio.Play();
        if(leftRay.collider != null) if(!leftAudio.isPlaying) leftAudio.Play();
        if(upRay.collider != null) if(!upAudio.isPlaying) upAudio.Play();
        if(downRay.collider != null) if(!downAudio.isPlaying) downAudio.Play();
    }

    void DebugRay()
    {
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);
        Debug.DrawRay(transform.position, - transform.right * rayDistance, Color.red);
        Debug.DrawRay(transform.position, transform.up * rayDistance, Color.red);
        Debug.DrawRay(transform.position, - transform.up * rayDistance, Color.red);
    }
}
