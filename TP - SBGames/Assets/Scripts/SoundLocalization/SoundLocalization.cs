using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
    public AudioSource tutorialAudio;

    RaycastHit2D rightRay, leftRay, upRay, downRay;
    [SerializeField] float rayDistance = 2f;
    Vector2 rightPivot, leftPivot, upPivot, downPivot;
    public bool EnableAudioLocalization = true;
    [SerializeField] float maxTime;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(2, 2);
    }

    void Update()
    {
        rightPivot = new Vector2(transform.position.x + 0.25f, transform.position.y);
        leftPivot = new Vector2(transform.position.x - 0.25f, transform.position.y);
        upPivot = new Vector2(transform.position.x, transform.position.y + 0.25f);
        downPivot = new Vector2(transform.position.x, transform.position.y - 0.25f);

        rightRay = Physics2D.Raycast(rightPivot, transform.right, rayDistance);
        leftRay = Physics2D.Raycast(leftPivot, -transform.right, rayDistance);
        upRay = Physics2D.Raycast(upPivot, transform.up, rayDistance);
        downRay = Physics2D.Raycast(downPivot, -transform.up, rayDistance);

        if (EnableAudioLocalization) AudioController();
    }
    public void PlayTutorialAudio()
    {
        rightAudio.Stop();
        leftAudio.Stop();
        upAudio.Stop();
        downAudio.Stop();
        upRightAudio.Stop();
        upLeftAudio.Stop();
        downRightAudio.Stop();
        downLeftAudio.Stop();
        tutorialAudio.Play();
    }

    void AudioController()
    {
        if (AnyAudioIsPlaying()) return;
        if (Input.GetKeyDown("space"))
        {
            // Tocar o som do tutorial e ficar numa "tela diferente"
            return;
        }

        if (rightRay.collider != null && leftRay.collider != null && upRay.collider != null && downRay.collider != null)
        {
            if (rightRay.collider.CompareTag("ExitCollidableAudio") &&
                leftRay.collider.CompareTag("ExitCollidableAudio") &&
                upRay.collider.CompareTag("ExitCollidableAudio") && downRay.collider.CompareTag("ExitCollidableAudio"))
            {
                
                rightAudio.Stop();
                leftAudio.Stop();
                upAudio.Stop();
                downAudio.Stop();
                upRightAudio.Stop();
                upLeftAudio.Stop();
                downRightAudio.Stop();
                downLeftAudio.Stop();
                
                if (SceneManager.GetActiveScene().name == "Tutorial")
                {
                    TutorialExitSound.exitMaze = true;
                }
                else
                {
                    ExitSound.exitMaze = true;
                }
            }
        }

        if (upRay.collider != null && !upRay.collider.CompareTag("ExitCollidableAudio"))
        {
            if (leftRay.collider != null && !upLeftAudio.isPlaying) upLeftAudio.Play();
            else if (rightRay.collider && !upRightAudio.isPlaying) upRightAudio.Play();
            else if (!upAudio.isPlaying) upAudio.Play();
            return;
        }

        if (downRay.collider != null && !downRay.collider.CompareTag("ExitCollidableAudio"))
        {
            if (leftRay.collider != null && !downLeftAudio.isPlaying) downLeftAudio.Play();
            else if (rightRay.collider != null && !downRightAudio.isPlaying) downRightAudio.Play();
            else if (!downAudio.isPlaying) downAudio.Play();
            return;
        }

        if (rightRay.collider != null && !rightRay.collider.CompareTag("ExitCollidableAudio"))
        {
            if (!rightAudio.isPlaying) rightAudio.Play();
            return;
        }

        if (leftRay.collider != null && !leftRay.collider.CompareTag("ExitCollidableAudio"))
        {
            if (!leftAudio.isPlaying) leftAudio.Play();
        }
    }

    bool AnyAudioIsPlaying()
    {
        if (rightAudio.isPlaying || upAudio.isPlaying || leftAudio.isPlaying || downAudio.isPlaying ||
            upLeftAudio.isPlaying || upRightAudio.isPlaying || downRightAudio.isPlaying ||
            downLeftAudio.isPlaying) return true;
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector2(transform.position.x + 0.25f, transform.position.y), transform.right * rayDistance);
        Gizmos.DrawRay(new Vector2(transform.position.x - 0.25f, transform.position.y), -transform.right * rayDistance);
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.25f), transform.up * rayDistance);
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), -transform.up * rayDistance);
    }
}