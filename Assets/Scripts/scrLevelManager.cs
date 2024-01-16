using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class scrLevelManager : MonoBehaviour
{
    int Contagem_Fase_Desbloqueada = 1;


    void Awake()
    {
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public bool EstaFaseEstaDisponivel(int faseRequisitada)
    {
        if (faseRequisitada <= Contagem_Fase_Desbloqueada)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AdicionarFaseDisponivel()
    {
        Contagem_Fase_Desbloqueada++;
    }

    public void ZerarFases()
    {
        Contagem_Fase_Desbloqueada = 1;
    }



}
