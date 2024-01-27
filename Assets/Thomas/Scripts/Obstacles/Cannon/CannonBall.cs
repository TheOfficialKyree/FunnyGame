using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] GameObject explosion;
    [SerializeField] float destroyTimer = 2f;

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Instantiate explosion at the cannonball's position
        Instantiate(explosion, transform.position, Quaternion.identity);

        // Handle collisions, e.g., destroy the projectile
        Destroy(gameObject);
    }
}
