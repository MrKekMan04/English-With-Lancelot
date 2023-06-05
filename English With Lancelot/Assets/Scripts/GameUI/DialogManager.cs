using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject something;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject charPrefab;

        private List<GameObject> _characters;
        private Rigidbody2D _player;
        private SpriteRenderer _spriteRenderer;
        private Queue<string> _dialogue;

        public void StartDialogue(string path, Sprite sprite, List<Character> characters)
        {
            _player.constraints = RigidbodyConstraints2D.FreezePosition;

            _spriteRenderer.sprite = sprite;
            _spriteRenderer.enabled = true;

            animator.SetBool("IsOpen", false);

            _dialogue = new Queue<string>(File.ReadAllText(path).Split('\n'));

            InitCharacters(characters);
            DisplayNextSentence();
        }

        private void InitCharacters(List<Character> characters)
        {
            foreach (var character in characters)
            {
                var x = Instantiate(charPrefab, something.GetComponent<GridLayoutGroup>().transform, true);
                x.GetComponentInChildren<SpriteRenderer>().sprite = character.sprite;
                _characters.Add(x);
            }
        }

        private void DisplayNextSentence()
        {
            if (_dialogue.Count == 0)
            {
                EndDialogue();
                return;
            }

            var sentence = _dialogue.Dequeue().Split(':');
            nameText.text = sentence[0];

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence[1]));
        }

        private IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (var letter in sentence)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.025f);
            }
        }

        private void EndDialogue()
        {
            _player.constraints = RigidbodyConstraints2D.FreezeRotation;
            animator.SetBool("IsOpen", true);
            _spriteRenderer.enabled = false;

            foreach (var character in _characters)
                Destroy(character);
        }

        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            _spriteRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();
            _characters = new List<GameObject>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) DisplayNextSentence();
        }
    }
}