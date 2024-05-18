using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform'u
    public float stoppingDistanceX = 50f; // Ateş etmek için gereken x ekseni mesafesi
    public float stoppingDistanceY = 10f; // Ateş etmek için gereken y ekseni mesafesi
    public GameObject bulletPrefab; // Mermi prefabı
    public Transform firePoint; // Merminin çıkış noktası
    public float fireRate = 2f; // Ateş etme sıklığı
    public float nextFireTime = 0f; // Bir sonraki ateş zamanı
    public GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>(); // Oyuncunun Transform'u
    }

    void Update()
    {
        if (nextFireTime>=1000)
        {
            nextFireTime = 0;
        }
        // Oyuncunun ve düşmanın x ve y eksenlerindeki farkları
        float distanceX = Mathf.Abs(player.position.x - transform.position.x);
        float distanceY = Mathf.Abs(player.position.y - transform.position.y);
        
        // Mesafe kontrolü
        if (distanceX <= stoppingDistanceX && distanceY <= stoppingDistanceY)
        {
            // Ateş etme işlemi
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        if (gm.gamemod!=2)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Mermiyi oluştur
        }
    }
}
