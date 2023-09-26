using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyScript : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip slurp;

    bool ifTransitioning; 
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)     
    {
       if(ifTransitioning) {return;}

        if(other.tag == "Player")
        {
                audioSource.PlayOneShot(slurp);
                GetComponent<MeshRenderer>().enabled = false;
                ifTransitioning = true;

              
        }
    }
}
