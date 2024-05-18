
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Merminin hızı
    public float lifeTime = 30f; // Merminin yaşam süresi
    public float deneme = 2;
    public bool yon;


    public Transform enemyTransform;
    private Rigidbody2D rb;
    private Transform playerTransform; // Oyuncunun Transform'u
    public GameManager gm;
    private Vector2 PlayerDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun Transform'u
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform; // Oyuncunun Transform'u
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>(); // Oyuncunun Transform'u
        
  
        PlayerDirection = playerTransform.position - transform.position; // Mermiyi oyuncuya doğru hedefleme vektörü
        rb.velocity = PlayerDirection.normalized * speed; // Mermiyi hedefe doğru hareket ettirme
 
        
        if (playerTransform.position.x < enemyTransform.position.x)
        {
            yon = true;
        }
        else if (playerTransform.position.x >= enemyTransform.position.x)
        {
            yon = false;
        }
        
       Destroy(gameObject, lifeTime);
       
    }

    private void Update()
    {
        if (gm.gamemod == 0)
        {
            speed = 10f;
            rb.velocity=Vector2.zero;
            rb.velocity = PlayerDirection.normalized * speed; 
            
           /* if (yon==true)
            {
                Vector2 direction = Vector2.left;
                rb.velocity = direction.normalized * speed;
            }
            else if (yon==false)
            {
                Vector2 direction = Vector2.right;
                rb.velocity = direction.normalized * speed; 
            }*/
        }
        else if (gm.gamemod==1)
        {
            rb.velocity=Vector2.zero;
            rb.velocity = PlayerDirection.normalized * speed; 
            
           /* if (yon==true)
            {
                Vector2 direction = Vector2.left;
                rb.velocity = direction.normalized * deneme;
            }
            else if (yon==false)
            {
                Vector2 direction = Vector2.right;
                rb.velocity = direction.normalized * deneme; 
            }*/
        }
        else if (gm.gamemod==2)
        {
            speed = 0f;
            rb.velocity=Vector2.zero;
            rb.velocity = PlayerDirection.normalized * speed; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Oyuncuya zarar ver (bu kısmı ihtiyacınıza göre özelleştirin)
            Debug.Log("Player'a çarptı"); // Çarpma mesajı
            Destroy(gameObject); // Mermiyi yok et
        }
        else if (!collision.collider.CompareTag("Enemy")) // Eğer mermi başka bir nesneye çarparsa
        {
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
