using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeCont : MonoBehaviour {
    private Animator anime;

    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    public void SetNod(bool value)
    {
        anime.SetBool("isNod", value);
    }
    public void DoPunch()
    {
        anime.Play("Punch", 0);
    }

    public void DoKick()
    {
        anime.Play("Kick", 0);
    }
}
