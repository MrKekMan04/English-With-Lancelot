using System.Collections.Generic;
using Mini_games;
using UnityEngine;

namespace GameUI
{
    public class DialogueTrigger : MonoBehaviour 
    {
        [TextArea] [SerializeField] private string text;
        [SerializeField] private List<Character> characters;
        [SerializeField] private Sprite background;

        private int _isTriggered;
 
        private void Start()
        {
            _isTriggered = PlayerPrefs.GetInt(GameConstants.IsStartShownKey, 0);
            if (_isTriggered == 1) return;
            FindObjectOfType<DialogueManager>().StartDialogue(text, background, characters);
            _isTriggered = 1;
            PlayerPrefs.SetInt(GameConstants.IsStartShownKey, _isTriggered);
        }
    }
}