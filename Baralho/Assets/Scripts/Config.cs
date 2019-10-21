using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config C;

    public int PontosVitória = 5;



    void Awake()
    {
        if(C != this)
        {
            if(C == null)
            {
                C = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }

    public void SetVitoria(int n)
    {
        PontosVitória = n;
    }

    public int GetVitoria()
    {
        return PontosVitória;
    }
}
