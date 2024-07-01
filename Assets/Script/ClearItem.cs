using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearItem : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public GameObject clearText;

    //ÉNÉäÉA
    public static bool IsCleared = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

        clearText.SetActive(false);
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
        Debug.Log("clear");
        clearText.SetActive(true);

        IsCleared = true;
    }
}
