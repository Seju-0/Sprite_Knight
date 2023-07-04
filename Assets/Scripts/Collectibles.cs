using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public bool speed, health;
    public int speedBoost, healthBoost, duration;
    private int baseMovespeed;
    public PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(speed)
        {
            player.moveSpeed += speedBoost;
            StartCoroutine(BackToBaseSpeed());
        }
        if(health)
        {
            player.healthPoints += healthBoost;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        baseMovespeed = player.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed = baseMovespeed;
    }
}
