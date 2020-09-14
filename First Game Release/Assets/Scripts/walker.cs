
using UnityEngine;

public class walker : MonoBehaviour
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
        while (Input.GetKey("a"))
        {
            left_strafe();
            return;
        }
        
        
        if (Input.GetKey("d"))
        {
            right_strafe();
            return;
        }
        else
        {
            idle();
        }
        
        

    }

    void left_strafe()
    {
        _animator.SetBool("Left_strafe", true);
    }
    void idle()
    {
        _animator.SetBool("isidle", true);
    }
    ///void left_walk()
    ///{
   ///     _animator.SetBool("Left_walk", true)
    ///}
   /// void right_walk()
    ///    _animator.SetBool("Right_walk", true)
   /// }
    void right_strafe()
    {
        _animator.SetBool("Right_strafe", true);
    }

}
