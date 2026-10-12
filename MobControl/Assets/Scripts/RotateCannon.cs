using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    public GameObject target;
    public float angleCP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToTarget = target.transform.position - transform.position;
        Vector3 cp = Vector3.Cross(transform.forward, dirToTarget);

        Debug.DrawRay(transform.position, cp, Color.hotPink);
        Debug.DrawRay(transform.position, dirToTarget, Color.moccasin);
        Debug.DrawRay(transform.position, transform.forward * 2, Color.orchid);

        angleCP = Mathf.Rad2Deg * Mathf.Asin(cp.magnitude / (dirToTarget.magnitude * transform.forward.magnitude));

        transform.Rotate(cp, angleCP);
    }
}
