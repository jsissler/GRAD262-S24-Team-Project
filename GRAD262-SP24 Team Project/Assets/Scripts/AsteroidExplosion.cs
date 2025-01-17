using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    public ParticleSystem destructionParticles; // Reference to the Particle System prefab
    private bool _isQuitting = false;

    void OnApplicationQuit()
    {
        _isQuitting = true;
    }
    private void OnDestroy()
    {
        if (!_isQuitting && destructionParticles != null)
        {
            // Instantiate the Particle System at the position of the destroyed object
            ParticleSystem newParticles = Instantiate(destructionParticles, transform.position, Quaternion.identity);

            // Play the Particle System
            newParticles.Play();

            // Destroy the Particle System after its duration
            Destroy(newParticles.gameObject, newParticles.main.duration);
        }
    }

}
