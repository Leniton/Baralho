using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] int CardLimit;
    [Space]
    [SerializeField] GameObject TurnHand, OtherHand;
    [Space]
    [SerializeField] Hand Player1, Player2;
    Sprite backImage;

    void Start()
    {
        backImage = OtherHand.transform.GetComponentInChildren<Image>().sprite;

        Player1.GetCard(0);
        for (int i = 1; i < CardLimit; i++)
        {
            int card;
            do
            {
                card = Random.Range(1, Cardlist.cardlist.list.Length);
            } while (Player1.cards.Contains(card));

            Player1.GetCard(card);
        }

        Player2.GetCard(0);
        for (int i = 1; i < CardLimit; i++)
        {
            int card;
            do
            {
                card = Random.Range(1, Cardlist.cardlist.list.Length);
            } while (Player2.cards.Contains(card));

            Player2.GetCard(card);
        }

        flip();
    }

    private void flip()
    {
        if(TurnHand.transform.childCount < CardLimit)
        {
            Debug.LogError("o limite de cartas é maior que a quantidade de cartas!!");
            return;
        }

        Image[] s = TurnHand.GetComponentsInChildren<Image>();
        List<int> l;
        if (Player1.myTurn)
        {
            l = Player1.cards;
        }
        else
        {
            l = Player2.cards;
        }

        for (int i = 0; i < s.Length; i++)
        {
            s[i].sprite = Cardlist.cardlist.list[l[i]];
        }
    }
}
