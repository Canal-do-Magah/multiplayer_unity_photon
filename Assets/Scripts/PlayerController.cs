using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    private Vector2 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float eixoX = Input.GetAxisRaw("Horizontal"); 
        float eixoY = Input.GetAxisRaw("Vertical");   

        direcao = new Vector2(eixoX, eixoY).normalized;

        rb.velocity = direcao * velocidade;

        bool isWalking = direcao != Vector2.zero;
        playerAnimator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            playerAnimator.SetFloat("eixoX", direcao.x);
            playerAnimator.SetFloat("eixoY", direcao.y);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            playerAnimator.SetTrigger("Attack");
        }
    }
}
