using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private Animator animator;
    private bool isBlocking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleBlock();
        }
    }

    private void ToggleBlock()
    {
        isBlocking = !isBlocking;
        animator.SetBool("IsBlocking", isBlocking);
    }
}
