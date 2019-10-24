using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    localData dados;

    [SerializeField] TMP_Dropdown pontosVitoria;
    [SerializeField] TMP_Dropdown corBack;
    [Space]
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

        dados = LocalSave.Load();
        if (dados != null)
        {
            Config.C.SetVitoria(dados.PPV);

            cor = dados.Cor;
            tipo = dados.Tipo;
        }

        changeCardColor(cor);
        Picked.transform.position = BackCards.transform.GetChild(tipo).position;
        CurrentColor = cor;
        Config.C.Select(BackCards.transform.GetChild(tipo).GetComponent<Image>().sprite);

        corBack.value = CurrentColor;
        pontosVitoria.value = Config.C.GetVitoria() - 1;
    }

    public void Play()
    {
        SceneM.manager.LoadGame();
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

        dados = new localData(Config.C.GetVitoria(), cor, tipo);
        LocalSave.Save(dados);
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

        dados = new localData(Config.C.GetVitoria(), cor, tipo);
        LocalSave.Save(dados);
    }
}
