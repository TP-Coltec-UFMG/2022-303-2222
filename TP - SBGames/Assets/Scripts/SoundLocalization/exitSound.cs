using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitSound : MonoBehaviour
{
    private AudioSource exitAudio;
    private void Start() {
        exitAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) exitAudio.Play();
    }
}
