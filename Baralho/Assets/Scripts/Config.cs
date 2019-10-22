using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config C;

    int PontosVitória = 5;

    public Sprite[] copy;

    [SerializeField] Sprite selected;

    [SerializeField] Sprite[] red;
    [SerializeField] Sprite[] blue;
    [SerializeField] Sprite[] verde;

    void Awake()
    {
        if(C != this)
        {
            if(C == null)
            {
                C = this;
                DontDestroyOnLoad(this);
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

    public Sprite Selected()
    {
        return selected;
    }

    public void Select(Sprite s)
    {
        selected = s;
    }

    public void pickArray(int n)
    {
        switch (n)
        {
            case 0:
                copy = red;
                break;

            case 1:
                copy = blue;
                break;

            case 2:
                copy = verde;
                break;
        }
    }
}
