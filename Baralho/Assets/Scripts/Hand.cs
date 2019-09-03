using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Board board;

    [Space]

    public List<int> cards = new List<int>();
    [Space]
    public bool myTurn;

    void Start()
    {

    }

    public void GetCard(int card)
    {
        cards.Add(card);
    }
}
