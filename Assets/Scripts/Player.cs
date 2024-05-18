using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket hızı
    public float jumpForce = 10f; // Oyuncunun zıplama kuvveti
    private Rigidbody2D rb; // Oyuncunun Rigidbody2D bileşeni
    private bool isGrounded = false; // Oyuncunun yere temasını kontrol eden bayrak
    public Animator anim;
    private SpriteRenderer spriteRenderer; 


    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.velocity!=Vector2.zero)
        {
            anim.SetBool("IsRunning",true);
        }
        if (rb.velocity==Vector2.zero)
        {
            anim.SetBool("IsRunning",false);
        }

        
        // Klavyeden A ve D tuşlarına basılıp basılmadığını kontrol et
        float move = Input.GetAxis("Horizontal");
        if (move>0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (move<0)
        {
            spriteRenderer.flipX = true; 
        }

        // Rigidbody2D ile oyuncunun hızını güncelle
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Zıplama
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Yerde olmadığını belirt
        }
    }

    // Yere temas kontrolü
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Yere temas ettiğini belirt
        }
    }

}
