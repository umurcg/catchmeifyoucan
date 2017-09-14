using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Level controller is singleton class while there can be only one level controller
/// </summary>
public class LevelController : MonoBehaviour {

    public static LevelController controller;

    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject winPrompt;
    [SerializeField] Text point;
    float pointAmount = 0;

    private void Awake()
    {
        if (controller != null)
            Destroy(this);
        else
            controller = this;
    }

    private void Start()
    {
        player.transform.position = startPoint.transform.position;
        point.text = "Point: "+ pointAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("You escaped!!!!!");
            winPrompt.SetActive(true);
        }
    }

    public void restartGame()
    {
        
        SceneManager.LoadScene(0);
    }

    public void earnPoint(float amount)
    {
        pointAmount += amount;
        point.text = "Point: " + pointAmount;

    }



}
