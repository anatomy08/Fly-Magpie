using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodes : MonoBehaviour
{

    CollisionHandler collisionHandler;


    void Start()
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
    }

    void Update()
    {
        CheatLoadNextScene();
        DisabledCollision();
    }
    
    void CheatLoadNextScene()
    {
        if(Input.GetKey(KeyCode.L)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Cheat Activated, Load Next Scene.");
        }
    }

    void DisabledCollision()
    {
        if(Input.GetKey(KeyCode.P))
        {
            collisionHandler.isCheatOn = true;
            Debug.Log("Cheat Activated, Collision Disabled.");
        }
    }

}
