using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //ê⁄êGÇµÇΩèuä‘
        //Debug.Log("Enter");
        animator.SetTrigger("Get");
        audioSource.Play();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
