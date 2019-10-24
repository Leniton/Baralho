using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class localData
{
    public int PPV;

    public int Cor;
    public int Tipo;

    public localData(int ppvit, int Acor, int Otipo)
    {
        PPV = ppvit;
        Cor = Acor;
        Tipo = Otipo;
    }
}
