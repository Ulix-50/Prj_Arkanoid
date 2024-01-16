using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBloco : MonoBehaviour
{
    SpriteRenderer Renderizador;

    [SerializeField] Sprite[] spriteBlocosColoridos;
    scrGameController scriptGameController;

     int ValorParaBlocos;
    [SerializeField] int QuantidadePontos;

    private void Awake() 
    {
        Renderizador = this.GetComponent<SpriteRenderer>();
        scriptGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<scrGameController>();
        ValorParaBlocos = Random.Range(0,spriteBlocosColoridos.Length);

        switch (ValorParaBlocos)
        {
            case 0: 
                Renderizador.sprite = spriteBlocosColoridos[0];
                QuantidadePontos = 5;                
                break;
            case 1:
                Renderizador.sprite = spriteBlocosColoridos[1];
            QuantidadePontos = 10;         
            break;

            case 2: 
            Renderizador.sprite=spriteBlocosColoridos[2];
            QuantidadePontos = 15;
            break;

            case 3:
            Renderizador.sprite = spriteBlocosColoridos[3];
            QuantidadePontos = 20;
            break;

            case 4:
           Renderizador.sprite = spriteBlocosColoridos[4];
            QuantidadePontos = 25;            
            break;

            case 5:;
          Renderizador.sprite = spriteBlocosColoridos[5];
            QuantidadePontos = 30;

            break;
        }
        scriptGameController.AdicionarBloco(this.gameObject);
    }

    public void Morrer()
    {
        scriptGameController.RemoverBloco(this.gameObject);
        
        Destroy(this.gameObject);
    }

    public int GetQuantidadePontos()
    {
        return QuantidadePontos;
    }
}
