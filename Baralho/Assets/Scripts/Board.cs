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
            /*int card;
            do
            {
                card = Random.Range(1, Cardlist.cardlist.list.Length);
            } while (Player1.cards.Contains(card));
            */
            Player1.GetCard(Draw(Player1.cards));
        }

        Player2.GetCard(0);
        for (int i = 1; i < CardLimit; i++)
        {
            /*int card;
            do
            {
                card = Random.Range(1, Cardlist.cardlist.list.Length);
            } while (Player2.cards.Contains(card));
            */
            Player2.GetCard(Draw(Player2.cards));
        }

        flip();
    }

    int Draw(List<int> b)
    {
        int n;
        do
        {
            n = Random.Range(1, Cardlist.cardlist.list.Length);
        } while (b.Contains(n));
        return n;
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

    public void pickCard()
    {
        GameObject carta = null;
        int index = 0;

        List<int> oh;
        if (Player1.myTurn)
        {
            oh = Player2.cards;
        }
        else
        {
            oh = Player1.cards;
        }

        for (int i = 0; i < OtherHand.transform.childCount; i++)
        {
            if (OtherHand.transform.GetChild(i).GetComponent<Animator>().enabled)
            {
                carta = OtherHand.transform.GetChild(i).gameObject;
                index = i;
                break;
            }
        }
        if(carta != null)
        {
            carta.GetComponent<Image>().sprite = Cardlist.cardlist.list[oh[index]];
        }

        //devolve qualquer modificação
        if (Player1.myTurn)
        {
            if (oh[index] != 0)
            {
                if (Player1.cards.Contains(oh[index]))
                {
                    Player1.points++;
                    if(oh[index] == 1)
                    {
                        Player1.points++;
                    }
                    if (Player1.points >= 10)
                    {
                        print("Vitoria!!!!");
                    }
                    Player1.cards.RemoveAt( Player1.cards.IndexOf(oh[index]) );
                    Player1.cards.Add(Draw(Player1.cards));
                }
                oh.RemoveAt(index);
                oh.Add(Draw(oh));
            }
            else
            {
                print("derrota");
            }
            Player2.cards = oh;
        }
        else
        {
            if (oh[index] != 0)
            {
                if (Player2.cards.Contains(oh[index]))
                {
                    Player2.points++;
                    if (oh[index] == 1)
                    {
                        Player2.points++;
                    }
                    if(Player2.points >= 10)
                    {
                        print("Vitoria!!!!");
                    }
                    Player2.cards.RemoveAt( Player2.cards.IndexOf(oh[index]) );
                    Player2.cards.Add(Draw(Player2.cards));
                }
                oh.RemoveAt(index);
                oh.Add(Draw(oh));
            }
            else
            {
                print("derrota");
            }
            Player1.cards = oh;
        }
    }
}
