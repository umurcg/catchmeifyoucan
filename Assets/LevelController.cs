using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) 
            Debug.Log("You escaped!!!!!");
    }

    public void restartGame()
    {
        
        SceneManager.LoadScene(0);
    }


}
