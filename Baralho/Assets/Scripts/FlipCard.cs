using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{

    [SerializeField] Board board;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Flip()
    {
        board.pickCard();
    }

    public void Play()
    {
        anim.SetTrigger("Play");
        //StartCoroutine(F());
    }

    IEnumerator F()
    {
        yield return new WaitForEndOfFrame();
        print("foi?");
        anim.SetTrigger("Play");
    }
}
