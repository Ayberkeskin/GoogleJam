using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Takip edilecek oyuncu karakteri
    public Vector3 offset; // Kameranın hedefe olan mesafesi
    public float smoothSpeed = 0.125f; // Kameranın hareket hızının yumuşatılması için kullanılan hız

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Hedef pozisyonu belirle
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Yumuşatılmış pozisyonu hesapla
        transform.position = smoothedPosition; // Kamerayı yeni pozisyona taşı
    }
}
