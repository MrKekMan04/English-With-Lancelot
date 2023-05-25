using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class DialogueTrigger : MonoBehaviour 
    {
        [SerializeField] private string path;
        [SerializeField] private List<Character> characters;
        [SerializeField] private Sprite background;

        private bool _isTriggered; 
 
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (_isTriggered || !coll.CompareTag("Player")) return;
            FindObjectOfType<DialogueManager>().StartDialogue(path, background, characters);
            _isTriggered = true;
        }
    }
}