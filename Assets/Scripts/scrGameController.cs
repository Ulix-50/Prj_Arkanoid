using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrGameController : MonoBehaviour
{
    [SerializeField] GameObject Bola;
    [SerializeField] TMP_Text TextoVida;
    [SerializeField] TMP_Text TextoPontuacao;
    [SerializeField] GameObject Mensagem_FimDeJogo;
    [SerializeField] GameObject Mensagem_Vitoria;
    [SerializeField] List<GameObject> Blocos;
    [SerializeField] int Vida;

    scrPlayer scriptPlayer;
    Rigidbody2D rigidbodyBolinha;
    scrLevelManager scriptLevelManager;
    static GameObject instacia;

    float Pontuacao;
    float PontuacaoMaxima;

    void Awake()
    {
        DontDestroyOnLoad(this);
        VerificarExistencia_Instancia();
        Mensagem_FimDeJogo.SetActive(false);
        Mensagem_Vitoria.SetActive(false);        
        scriptLevelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<scrLevelManager>();
        scriptPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<scrPlayer>();
        rigidbodyBolinha = Bola.GetComponent<Rigidbody2D>();
    }
    public void AdicionarPontos(float PontosAdicionados)
    {
        Pontuacao += PontosAdicionados;
        TextoPontuacao.text = "Pontuação: " + Pontuacao.ToString();
        DefinirPontuacaoMaxima();
    }


    private void Instanciar_Bola()
    {
        Instantiate(Bola, new Vector3(4.5f,1f,1f), Quaternion.identity);
    }
    private void FinalizarJogo()
    {
        Mensagem_FimDeJogo.SetActive(true);
        Pontuacao = 0;
        scriptLevelManager.ZerarFases();
    }

    public void DescerBolinha()
    {
        rigidbodyBolinha.velocity = Vector2.down * 2;
    }

    private void DefinirPontuacaoMaxima()
    {
        if (Pontuacao < PontuacaoMaxima) return;

        PontuacaoMaxima = Pontuacao;
    }

    private void VerificarExistencia_Instancia()
    {
        if (instacia != null && instacia != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instacia = this.gameObject;
        }
    }

    public void VerificarExistencia_Blocos()
    {
        if (Blocos.Count > 0) return;
        
            Vitoria();
        
    }

    private void Vitoria()
    {

        scriptLevelManager.AdicionarFaseDisponivel();
        Mensagem_Vitoria.SetActive(true);
    }
    public void PerderVida()
    {
        Vida--;
        if (Vida > 0)
        {
            Instanciar_Bola();
            Invoke("DescerBolinha", 0.2f);
        }
        else FinalizarJogo();
        TextoVida.text = "Vida: " + Vida.ToString();
    }

    public void AdicionarBloco(GameObject novoBloco)
    {
        Blocos.Add(novoBloco);
    }
    public void RemoverBloco(GameObject Bloco)
    {
        Blocos.Remove(Bloco);
    }

}
