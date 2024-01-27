using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawningPos;  // Assuming you use a Transform instead of GameObject for spawning position
    public float projectileSpeed = 10f;

    void Update()
    {
        // Check for user input to fire the cannon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Find the player's position
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the direction from the cannon to the player
            Vector3 direction = (player.transform.position - spawningPos.position).normalized;

            // Instantiate the projectile at the specified position and rotation
            GameObject projectile = Instantiate(projectilePrefab, spawningPos.position, Quaternion.LookRotation(direction));

            // Apply speed to the projectile (assuming you have a Rigidbody component)
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            if (projectileRb != null)
            {
                projectileRb.velocity = direction * projectileSpeed;
            }
        }
    }
}
