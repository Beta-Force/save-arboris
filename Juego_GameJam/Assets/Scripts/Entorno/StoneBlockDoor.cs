using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class StoneBlockDoor : MonoBehaviour, IDoor
{
    public bool startOpen = false;

    [SerializeField] private SpriteRenderer visualSprite;
    [SerializeField] private Sprite spriteClose, spriteOpen;

    [SerializeField] private Collider2D coll2D;

    private void Start()
    {
        coll2D = GetComponent<Collider2D>();

        if (startOpen) OpenDoor();
    }

    public void CloseDoor()
    {
        visualSprite.sprite = spriteClose;
        coll2D.enabled = true;
    }

    public void OpenDoor()
    {
        visualSprite.sprite = spriteOpen;
        coll2D.enabled = false;
    }
}
