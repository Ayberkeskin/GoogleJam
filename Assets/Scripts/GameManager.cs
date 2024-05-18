using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy enemy;
    public Bullet bullet;
    public Parkur parkur;

    public int gamemod = 0;

    private void Start()
    {
        bullet.speed = 10f;
    }

    void Update()
    {
        // Oyunu duraklatmak için X tuşuna basıldığında
        if (Input.GetKeyDown(KeyCode.X))
        {
            gamemod = 2;
            Debug.Log(gamemod);
            PauseGame();
        }

        // Zamanı yavaşlatmak için Z tuşuna basıldığında
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gamemod = 1;
            Debug.Log(gamemod);
            SlowDownTime();
        }

        // Normal hızda oynatmak için Q tuşuna basıldığında
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gamemod = 0;
            Debug.Log(gamemod);
            ResetTime();
        }
    }

    // Oyunu duraklatan fonksiyon
    void PauseGame()
    {
        enemy.fireRate = 0f;
        bullet.speed = 0f;
        parkur.speed = 0f;
    }
    
    // Zamanı yavaşlatan fonksiyon
    void SlowDownTime()
    {
        enemy.fireRate = 0.5f;
        bullet.speed = 2f;
        parkur.speed = 3f;
    }

    // Normal hıza döndüren fonksiyon
    void ResetTime()
    {
        parkur.speed = 7f;
        enemy.fireRate = 1f;
        bullet.speed = 10f;
    }
    
}
