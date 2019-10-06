using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    int RAtual = 0;
    [SerializeField] GameObject[] regras;

    void Start()
    {
        for (int i = 0; i < regras.Length; i++)
        {
            regras[i].SetActive(false);
        }
        regras[RAtual].SetActive(true);
    }

    public void loadScene(int n)
    {
        SceneManager.LoadScene(n);
    }


    public void Next()
    {
        if (RAtual + 1 == regras.Length)
        {
            regras[0].SetActive(true);
            regras[RAtual].SetActive(false);
            RAtual = 0;
            return;
        }
        regras[RAtual + 1].SetActive(true);
        regras[RAtual].SetActive(false);
        RAtual++;
    }

    public void Previous()
    {
        if (RAtual - 1 < 0)
        {
            regras[regras.Length - 1].SetActive(true);
            regras[RAtual].SetActive(false);
            RAtual = regras.Length - 1;
            return;
        }
        regras[RAtual - 1].SetActive(true);
        regras[RAtual].SetActive(false);
        RAtual--;
    }
}
