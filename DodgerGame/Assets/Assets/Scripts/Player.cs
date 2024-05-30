using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    float screenHalfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ekran�n yar�s�n� al
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {
        // Fare pozisyonunu al
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Player'�n ekran d���na ��kmas�n� engelle
        float clampedX = Mathf.Clamp(mousePos.x, -screenHalfWidth, screenHalfWidth);

        // Player'� s�n�rlanm�� konumda hareket ettir
        rb.MovePosition(new Vector2(clampedX, transform.position.y));

        // D��en nesnelerden korunmak i�in d�n��� s�f�rla
        rb.angularVelocity = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Game");
        }
        
    }
}
