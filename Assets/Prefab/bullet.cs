using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
    public void OnTriggerEnter(Collider other)
    {      
        if (other.CompareTag("Bullet") || other.CompareTag("Player") || other.CompareTag("Damaged+"))
        return;
        Destroy(gameObject);       
    }
}
