using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Movement movement;
    Animator animator;
    AudioSource audioSource;
    bool canMove = true;
    bool isDisabled = true;
    public bool isCheatOn = false;

    [Header ("Particle System")]
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;


    [Header ("Sound Clips")]
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip slurp;

    [Header ("Delays")]
    [SerializeField] float crashDelay = 3f;
    [SerializeField] float loadScene = 5f;

    void Start()
    {
        movement = FindObjectOfType<Movement>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
      
    }

    void Update()
    {
        if(canMove)
        {
            movement.Thrusting();
            movement.Rotation();
        }
    }


    void  OnCollisionEnter(Collision other) 
    {
        if(isDisabled)
        {
                           switch(other.gameObject.tag)
                       {
                        case "Friendly":
                                  Debug.Log("Friendly.");
                                  break;                         
                        case "Finish": 
                                  FinishScene();
                                  break; 
                        default: 
                                  Die();
                                  break;
                        }    
        }

    }

    void FinishScene()
    {
            successParticles.Play();
            audioSource.PlayOneShot(finishSound);
            Invoke("NextScene", loadScene);
            isDisabled = false;
            canMove = false;
    }
    

    void NextScene()
    {    
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Die()
    {
        if(!isCheatOn) 
        {
        deathParticles.Play();
        audioSource.PlayOneShot(deathSound);
        canMove = false;
        animator.SetTrigger("Dying");
        Invoke("ReloadScene", crashDelay);
        isDisabled = false;
        }
        else 
        {
            Debug.Log("WOWW NO PATAY AH");
        }
    }
}
