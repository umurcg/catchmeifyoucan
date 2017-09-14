using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : DestroyableObject
{
    [SerializeField] PointBarScript playerHealth;
    //[SerializeField] LevelController levelController;
    protected override void Start()
    {
        health = initialHealth;
        pointBar = playerHealth;
        pointBar.setPoint(health);
    }


    protected override void Die()
    {
        //base.Die();
        LevelController.controller.restartGame();


    }


    //Override visibility functionality because healt bar of player never should be deactivated during game regardless of visibility.
    protected override void OnBecameInvisible()
    {
        
    }

    protected override void OnBecameVisible()
    {
    }

}
