using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour
{
    Camera cameraJogador;
    Rigidbody2D rigidbodyPlayer;
    float LimiteDireita;
    float LimiteEsquerda;


    private void Awake()
    {
        LimiteEsquerda = -0.509f;
        LimiteDireita = 8.041f;
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        cameraJogador = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector2 posicaoNaTela = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 posicaoNoJogo = new Vector2(cameraJogador.ScreenToWorldPoint(posicaoNaTela).x, -3.45f);

        posicaoNoJogo.x = Mathf.Clamp(posicaoNoJogo.x, LimiteEsquerda, LimiteDireita);
        rigidbodyPlayer.MovePosition(posicaoNoJogo);

    }

    private void OnCollisionEnter2D(Collision2D ObjetoColidido)
    {

        switch (ObjetoColidido.gameObject.tag)
        {
            case "Parede": Debug.Log("Para ein!");
                break;

        }
    }
}
