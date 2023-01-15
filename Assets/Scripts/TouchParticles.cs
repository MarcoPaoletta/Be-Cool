using UnityEngine;

public class TouchParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    private void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    private void Update()
    {
        if(!particles.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}