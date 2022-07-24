using UnityEngine;

public class SoundLocalization : MonoBehaviour
{
    [SerializeField] AudioSource rightAudio;
    [SerializeField] AudioSource leftAudio;
    [SerializeField] AudioSource upAudio;
    [SerializeField] AudioSource downAudio;
    RaycastHit2D rightRay, leftRay, upRay, downRay;
    [SerializeField] float rayDistance = 2f;
    Vector2 rightPivot, leftPivot, upPivot, downPivot;
    public bool EnableAudioLocalization = true;
    
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
        if(rightRay.collider != null) 
        {
            if(rightRay.distance < rayDistance) rightAudio.volume = 1 - rightRay.distance/rayDistance;
            else rightAudio.Stop();

            if(!rightAudio.isPlaying) rightAudio.Play();
        }

        if(leftRay.collider != null) 
        {
            if(leftRay.distance < rayDistance) leftAudio.volume = 1 - leftRay.distance/rayDistance;
            else leftAudio.Stop();
            
            if(!leftAudio.isPlaying) leftAudio.Play();
        }

        if(upRay.collider != null) 
        {
            if(upRay.distance < rayDistance) upAudio.volume = 1 - upRay.distance/rayDistance;
            else upAudio.Stop();
            
            if(!upAudio.isPlaying) upAudio.Play();
        }

        if(downRay.collider != null) 
        {
            if(downRay.distance < rayDistance) downAudio.volume = 1 - downRay.distance/rayDistance;
            else downAudio.Stop();
            
            if(!downAudio.isPlaying) downAudio.Play();
        }

        if(rightRay.collider.CompareTag("CollidableAudio") && leftRay.collider.CompareTag("CollidableAudio") && upRay.collider.CompareTag("CollidableAudio") && downRay.collider.CompareTag("CollidableAudio"))
        {
            rightAudio.Stop();
            leftAudio.Stop();
            upAudio.Stop();
            downAudio.Stop();
            ExitSound.exitMaze = true;
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