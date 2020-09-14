using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoped : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject crosshair;
    public GameObject weaponcamera;
    public float scopeFOV = 60f;
    private float normalFOV;
    public Camera maincam;
    private bool isScoped = false;
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnscoped();
        }
    }
   
    void OnUnscoped()
    {
         scopeOverlay.SetActive(false);
         weaponcamera.SetActive(true);
         crosshair.SetActive(true);

         maincam.fieldOfView = normalFOV;
    }
     IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponcamera.SetActive(false);
        crosshair.SetActive(false);

        normalFOV = maincam.fieldOfView;
        maincam.fieldOfView = scopeFOV;
    }
}
