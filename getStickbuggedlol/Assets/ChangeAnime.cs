using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnime : MonoBehaviour
{
    public Animator anime;
    public bool IsSmack = false;

    void Update()
    {
        if (Input.GetKey("space"))
        {
            IsSmack= true;
            print("space key was pressed");
            anime.Play("smack");
        }






    }
}
