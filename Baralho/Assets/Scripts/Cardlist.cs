using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardlist : MonoBehaviour
{
    public static Cardlist cardlist;
    public Sprite[] list = new Sprite[10];

    void Awake()
    {
        if(cardlist == null)
        {
            cardlist = this;
        }
    }
}
