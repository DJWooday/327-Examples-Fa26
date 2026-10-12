using UnityEngine;

public class BeanFlight : MonoBehaviour
{
    public Transform[] targets;
    public Transform target;
    public int targetIndex;
    public float speed = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = targets[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToTarget = target.position - transform.position;
        Vector3 movement = dirToTarget.normalized * speed * Time.deltaTime;
        Debug.DrawRay(transform.position, movement);
        transform.position += movement;
        //transform.position = Vector3.Lerp(transform.position, target.position, .05f);

        float distToTarget = dirToTarget.magnitude;
        if (distToTarget < .01f)
        {
            targetIndex = (targetIndex + 1) % targets.Length;
            target = targets[targetIndex];
        }

        transform.forward = dirToTarget.normalized;
    }
}
