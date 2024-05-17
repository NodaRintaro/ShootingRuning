using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HeartMinus()
    {
        animator.Play("HeartMinus");
    }

    public void HeartPlus()
    {
        animator.Play("HeartPlus");
    }
}
