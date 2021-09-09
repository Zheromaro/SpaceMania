using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTigger : MonoBehaviour
{
    public Animator animator;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        animator.Play("Call Start");
        Destroy(gameObject);
    }
}
