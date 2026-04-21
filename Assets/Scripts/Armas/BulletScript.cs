using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    private int hits = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponentInChildren<AudioSource>();

        Destroy(gameObject, 120f);
    }

    // Update is called once per frame
    void Update()
    {

        float speed = rb.linearVelocity.magnitude;

        float volume = speed / 100;
        
        if (volume < 0.1)
        {
            audioSource.Stop();
        }
        audioSource.pitch = volume;
    }

    private void OnCollisionEnter(Collision other) {
        hits += 1;

        if (hits >= 1)
        {
            Destroy(gameObject);
        }
    }
}
