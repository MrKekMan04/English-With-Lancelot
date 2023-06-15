using System.Collections;
using System.Collections.Generic;
using Mini_games;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject grid;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject charPrefab;

        private List<GameObject> _characters;
        private Rigidbody2D _player;
        private Image _background;
        private Queue<string> _dialogue;
        private GameObject _button;
        private bool _isEnd;

        public void StartDialogue(string text, Sprite background, List<Character> characters)
        {
            _player.constraints = RigidbodyConstraints2D.FreezePosition;

            _background.sprite = background;
            _background.enabled = true;
            _button.SetActive(false);
            _isEnd = true;

            animator.SetBool(GameConstants.MenuPopUpIsOpenKey, false);

            _dialogue = new Queue<string>(text.Split('\n'));

            InitCharacters(characters);
            DisplayNextSentence();
        }

        private void InitCharacters(List<Character> characters)
        {
            foreach (var character in characters)
            {
                var charInstant = Instantiate(charPrefab, grid.GetComponent<GridLayoutGroup>().transform, true);
                charInstant.GetComponentInChildren<SpriteRenderer>().sprite = character.sprite;

                _characters.Add(charInstant);
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
            animator.SetBool(GameConstants.MenuPopUpIsOpenKey, true);
            _background.enabled = false;
            _isEnd = false;
            _button.SetActive(true);
            
            foreach (var character in _characters)
                Destroy(character);
        }

        private void Start()
        {
            _button = GameObject.Find("Button");
            _player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            _background = GameObject.Find("UI").GetComponent<Image>();
            _characters = new List<GameObject>();
        }

        private void Update()
        {
            if (_isEnd! && Input.GetMouseButtonDown(0)) DisplayNextSentence();
        }
    }
}