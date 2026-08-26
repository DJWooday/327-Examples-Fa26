using UnityEngine;

public class Multipler : MonoBehaviour
{
    public GameObject bean;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(bean, other.transform.position, other.transform.rotation);
    }
}
