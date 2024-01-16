using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrGerenciadorMenu : MonoBehaviour
{
    [SerializeField] GameObject Mensagem_FaseIndisponivel;
    [SerializeField] GameObject LevelManager;
    scrLevelManager scriptLevelManager;

    


    void Awake()
    { 

        scriptLevelManager = LevelManager.GetComponent<scrLevelManager>();
        Mensagem_FaseIndisponivel.SetActive(false);
    }

    public void CarregarFase(int NumeroFase)
    {
        if (NumeroFase > SceneManager.sceneCountInBuildSettings+1 || !scriptLevelManager.EstaFaseEstaDisponivel(NumeroFase))
        {
            ExibirMensangem_FaseIndisponivel();
            return;
        }
        SceneManager.LoadScene(NumeroFase);
    }

    public void ExibirMensangem_FaseIndisponivel()
    {
        Mensagem_FaseIndisponivel.SetActive(true);
        Invoke("DesativarMensagem_FaseIndisponivel", 2f);
    }

    private void DesativarMensagem_FaseIndisponivel()
    {
        Mensagem_FaseIndisponivel.SetActive(false);
    }
}
