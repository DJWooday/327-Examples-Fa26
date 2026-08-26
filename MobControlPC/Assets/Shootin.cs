using UnityEngine;

public class Shootin : MonoBehaviour
{
    public GameObject bean;
    public float shootForce = 40;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBean", 0, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBean()
    {
        GameObject b = Instantiate(bean, transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().AddForce(Vector3.forward * shootForce, ForceMode.Impulse);
    }
}
