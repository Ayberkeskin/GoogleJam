using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkur : MonoBehaviour
{
    public Transform pointA; // A noktası
    public Transform pointB; // B noktası
    public float speed = 2f; // Hareket hızı

    private Vector3 targetPosition;

    void Start()
    {
        // Başlangıçta hedef pozisyonu A noktası olarak belirle
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Mevcut pozisyon ile hedef pozisyon arasındaki mesafeyi hesapla
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Hedef pozisyona ulaşıldığında hedefi değiştir
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}
