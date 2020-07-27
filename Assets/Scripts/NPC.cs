using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public static NPC ActiveNPC { get; private set; }

#pragma warning disable 0649
    [SerializeField] GameObject chatBubble;
#pragma warning restore 0649

    private void Start()
    {
        chatBubble.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SetActiveNPC(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SetActiveNPC(false);
        }
    }

    void SetActiveNPC(bool set)
    {
        chatBubble.SetActive(set);
        ActiveNPC = set ? this : null;
    }


}
