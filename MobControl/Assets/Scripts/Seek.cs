using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;
    public float maxSpeed = 5, maxForce = 4;
    public Vector3 acceleration;
    public Vector3 velocity, position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
    }
    Vector3 desiredVelocity;
    Vector3 steering;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Compute steering force and set acceleration
        desiredVelocity = (target.position - transform.position).normalized * maxSpeed;
        steering = Vector3.ClampMagnitude(desiredVelocity - velocity, maxForce);
        acceleration = steering;

        // Derive position from acceleration
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        transform.position = position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.aliceBlue;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.mediumVioletRed;
        Gizmos.DrawRay(transform.position, desiredVelocity);
        Gizmos.color = Color.mintCream;
        Gizmos.DrawRay(transform.position + velocity, steering);
    }
}
