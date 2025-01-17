using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollisions : MonoBehaviour
{
    public LayerMask collisionLayers;
    public AudioClip DamageSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = DamageSound;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collisionLayers == (collisionLayers | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);

            if (collision.gameObject.CompareTag("Asteroid"))
            {
                Debug.Log("Missle hit Asteroid!");
                UIManager.Instance.AsteroidBlast();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Missle hit Enemy!");
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Missle hit Player!");
            }
        }
        
    }

     
}
