using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Board : MonoBehaviour
{
    [SerializeField] int CardLimit;
    [Space]
    [SerializeField] GameObject TurnHand, OtherHand;
    [Space]
    [SerializeField] Hand Player1, Player2;
    [SerializeField] TextMeshProUGUI seusPontos;
    [SerializeField] TextMeshProUGUI outroPontos;
    Sprite backImage;
    [Space]
    [SerializeField] Button continuar;
    [Space]
    [SerializeField] Animator cortina;

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
            seusPontos.text = "Sua pontuação: " + Player1.points;
        }
        else
        {
            l = Player2.cards;
            seusPontos.text = "Sua pontuação: " + Player2.points;
        }

        for (int i = 0; i < s.Length; i++)
        {
            s[i].sprite = Cardlist.cardlist.list[l[i]];
        }

        //se tiver alguma carta da outra mão exposta

        Image[] OM = OtherHand.GetComponentsInChildren<Image>();

        for (int i = 0; i < OM.Length; i++)
        {
            if(OM[i].sprite != backImage)
            {
                OM[i].sprite = backImage;
            }
            if (!OM[i].gameObject.GetComponent<Button>().interactable)
            {
                OM[i].gameObject.GetComponent<Button>().interactable = true;
            }
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
                seusPontos.text = "Sua pontuação: " + Player1.points;
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
                seusPontos.text = "Sua pontuação: " + Player2.points;
            }
            else
            {
                print("derrota");
            }
            Player1.cards = oh;
        }
        continuar.gameObject.SetActive(true);
    }

    public void DescerCortina()
    {
        if (!cortina.enabled)
        {
            cortina.enabled = true;
        }
        else
        {
            cortina.SetTrigger("T");
        }
    }

    public void SwitchTurn()
    {
        Player1.myTurn = !Player1.myTurn;
        Player2.myTurn = !Player2.myTurn;
        flip();
    }
}
