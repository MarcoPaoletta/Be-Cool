using UnityEngine;

public class TapParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem tapParticles;

    public void CreateTapParticles(Vector3 particlesPosition)
    {
        tapParticles.transform.position = particlesPosition;
        tapParticles.Play();
    }
}