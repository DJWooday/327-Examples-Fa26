using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public TextMeshProUGUI beanCounterText;
    public AudioSource aSource;
    public int beanCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainBaen()
    {
        beanCounter++;
        beanCounterText.text = beanCounter.ToString();
        aSource.Play();
    }
}
