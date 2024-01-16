using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBolinha : MonoBehaviour
{
    Rigidbody2D rigidbodyBolinha;
    [SerializeField] float velocidade = 8f;
    scrBloco scriptBloco;
    Vector2 movimento;
    scrGameController script_GameController;
    int Batata;

    private void Awake()
    {
        rigidbodyBolinha = GetComponent<Rigidbody2D>();
        rigidbodyBolinha.velocity = Vector2.down * velocidade;
        script_GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<scrGameController>();

    }

    private void Update()
    {
        rigidbodyBolinha.velocity = rigidbodyBolinha.velocity.normalized * velocidade;
        movimento = rigidbodyBolinha.velocity;


    }

    private void OnCollisionEnter2D(Collision2D Objeto_Colidido)
    {
        rigidbodyBolinha.velocity = Vector2.Reflect(movimento, Objeto_Colidido.contacts[0].normal);

        switch (Objeto_Colidido.gameObject.tag)
        {
            case "Parede":
                rigidbodyBolinha.velocity = Vector2.Reflect(movimento, Objeto_Colidido.contacts[0].normal); ;
                break;
            case "Parede_Inferior":
                Morrer();
                break;
            case "Bloco":
                scriptBloco = Objeto_Colidido.gameObject.GetComponent<scrBloco>();
                script_GameController.AdicionarPontos(scriptBloco.GetQuantidadePontos());
                script_GameController.VerificarExistencia_Blocos();
                scriptBloco.Morrer();
                break;

        }
    }

    private void Morrer()
    {

        script_GameController.PerderVida();
        Destroy(gameObject);
    }

}
