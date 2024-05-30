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
        // Ekranýn yarýsýný al
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {
        // Fare pozisyonunu al
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Player'ýn ekran dýþýna çýkmasýný engelle
        float clampedX = Mathf.Clamp(mousePos.x, -screenHalfWidth, screenHalfWidth);

        // Player'ý sýnýrlanmýþ konumda hareket ettir
        rb.MovePosition(new Vector2(clampedX, transform.position.y));

        // Düþen nesnelerden korunmak için dönüþü sýfýrla
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
