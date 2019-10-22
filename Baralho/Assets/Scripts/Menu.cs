using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    int RAtual = 0;
    [SerializeField] GameObject[] regras;

    [Space]

    [SerializeField] GameObject BackCards;
    [SerializeField] GameObject Picked;

    [Space]

    [SerializeField] int cor;
    [SerializeField] int tipo;
    [SerializeField] int CurrentColor;

    void Start()
    {
        for (int i = 0; i < regras.Length; i++)
        {
            regras[i].SetActive(false);
        }
        regras[RAtual].SetActive(true);

        changeCardColor(cor);
        Picked.transform.position = BackCards.transform.GetChild(tipo).position;
        CurrentColor = cor;
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

    public void MudarPonto(int n)
    {
        Config.C.SetVitoria(n + 1);
    }

    public void changeCardColor(int n)
    {
        Config.C.pickArray(n);
        CurrentColor = n;
        for (int i = 0; i < BackCards.transform.childCount; i++)
        {
            BackCards.transform.GetChild(i).GetComponent<Image>().sprite = Config.C.copy[i];
        }

        if(CurrentColor != cor)
        {
            Picked.SetActive(false);
        }
        else
        {
            Picked.SetActive(true);
        }
    }

    public void PickTypeCard(int t)
    {
        tipo = t;
        cor = CurrentColor;
        Picked.transform.position = BackCards.transform.GetChild(t).position;
        Picked.SetActive(true);

        Config.C.pickArray(cor);
        Config.C.Select(Config.C.copy[tipo]);
    }
}
