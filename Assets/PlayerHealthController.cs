using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : DestroyableObject
{
    [SerializeField] PointBarScript playerHealth;
    [SerializeField] LevelController levelController;
    protected override void Start()
    {
        health = initialHealth;
        pointBar = playerHealth;
        pointBar.setPoint(health);
    }


    protected override void Die()
    {
        base.Die();
        levelController.restartGame();


    }

}
