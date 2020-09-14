using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private Animator _animator = null;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            Dooropen();
            return;
        }
        else
        {
            Doorclose();
            return;
        }
    }
    void Dooropen()
    {
         _animator.SetBool("open", true);
    }


    void Doorclose()
    {
        _animator.SetBool("open", false);
    }
}
