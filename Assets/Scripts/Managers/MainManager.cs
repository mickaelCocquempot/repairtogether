using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{
    //public GameObject gameManager;          //GameManager prefab to instantiate.
    public GameObject inputManager;         //InputManager prefab to instantiate.


    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        //if (GameManagerSc.instance == null)

            //Instantiate gameManager prefab
            //gameManager = (GameObject)Instantiate(gameManager);

        //Check if a InputManager has already been assigned to static variable GameManager.instance or if it's still null
        if (InputManager.instance == null)

            //Instantiate SoundManager prefab
            inputManager = (GameObject)Instantiate(inputManager);
    }
}