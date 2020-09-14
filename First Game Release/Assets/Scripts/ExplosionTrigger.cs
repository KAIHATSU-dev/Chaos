using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject Particle;
    
    // Start is called before the first frame update
    void Start()
    {
        Particle.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Explode();
        }
    }
    void Explode()
    {
        
    }
}

