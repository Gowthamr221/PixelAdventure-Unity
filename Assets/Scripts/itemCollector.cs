using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectCherry;
    private int cherries = 0;
    // Start is called before the first frame update
    [SerializeField] private Text CherriesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry")) {
            Debug.Log(collision.gameObject.name);
            cherries++;
            collectCherry.Play();
            CherriesText.text = "Cherries: " + cherries;
            Destroy(collision.gameObject);
        }
    }
    
}
