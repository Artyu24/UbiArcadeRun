using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SMP_LIG
{
    public class ScoreManagerArcade : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> scoreTextList = new List<TextMeshProUGUI>();
        [SerializeField] private List<TextMeshProUGUI> pseudoTextList = new List<TextMeshProUGUI>();
        [SerializeField] private TextMeshProUGUI inputPseudoText;
        [SerializeField] private GameObject enterButton;
        [SerializeField] private GameObject hiScoreObject, scoreBoard, enterPseudoBoard;
        [SerializeField] private string sceneNameReload;

        public delegate void SaveScoreDelegate(int score);
        private static SaveScoreDelegate saveScore = null;
        public static SaveScoreDelegate SaveScore => saveScore;

        private const string pseudoNameSpace = "Pseudo_";
        private const string scoreNameSpace = "Score_";

        private static int actualScore = 0;

        private void Awake()
        {
            saveScore = CanSaveScore;
        }

        private void Start()
        {
            for (int i = 0; i < scoreTextList.Count; i++)
            {
                if (!PlayerPrefs.HasKey(pseudoNameSpace + i))
                {
                    CreateKey(TypeFunction.STRING, i);
                }

                if (!PlayerPrefs.HasKey(scoreNameSpace + i))
                {
                    CreateKey(TypeFunction.INT, i);
                }
            }
        }

        private void CreateKey(TypeFunction type, int id, string pseudo = "AAA", int score = 0)
        {
            switch (type)
            {
                case TypeFunction.STRING:
                    PlayerPrefs.SetString(pseudoNameSpace + id, pseudo);
                    break;
                case TypeFunction.INT:
                    PlayerPrefs.SetInt(scoreNameSpace + id, score);
                    break;
                default:
                    break;
            }
        }

        private void CanSaveScore(int score)
        {
            actualScore = 0;
            
            hiScoreObject.SetActive(true);

            if (IsItBetterScore(score))
            {
                SwitchPlace(TypeFunction.INT, score);
                actualScore = score;

                inputPseudoText.text = "";
                enterPseudoBoard.SetActive(true);
            }
            else
            {
                SetupScoreboard();
                scoreBoard.SetActive(true);
                StartCoroutine(RestartGame());
            }
        }

        private bool IsItBetterScore(int score)
        {
            foreach (int bestScore in GetScoreList())
            {
                if (score > bestScore)
                    return true;
            }

            return false;
        }

        private void SwitchPlace(TypeFunction type, int score, string pseudo = "")
        {
            bool switchTemp = false;
            int actualIDTemp = 0;
            
            for (int i = 0; i < scoreTextList.Count; i++)
            {
                if (score >= GetScoreID(i) && !switchTemp)
                {
                    actualIDTemp = i;
                    switchTemp = true;
                    break;
                }
            }

            for (int i = 4; i > actualIDTemp; i--)
            {
                CreateKey(type, i, GetPseudoID(i - 1), GetScoreID(i - 1));
            }

            CreateKey(type, actualIDTemp, pseudo, score);
        }

        public void AddLetter(string letter)
        {
            if (letter == "!")
            {
                if (inputPseudoText.text.Length != 0)
                {
                    inputPseudoText.text = inputPseudoText.text.Substring(0, inputPseudoText.text.Length - 1);
                }
            }
            else
            {
                if (inputPseudoText.text.Length != 3)
                {
                    inputPseudoText.text += letter;
                }
            }

            if (inputPseudoText.text.Length == 3)
            {
                enterButton.SetActive(true);
            }
            else
            {
                if(enterButton.activeInHierarchy)
                    enterButton.SetActive(false);
            }
        }

        public void EnterPseudo()
        {
            SwitchPlace(TypeFunction.STRING, actualScore, inputPseudoText.text);
            enterPseudoBoard.SetActive(false);
            SetupScoreboard();
            scoreBoard.SetActive(true);
            StartCoroutine(RestartGame());
        }

        private List<int> GetScoreList()
        {
            List<int> scoreListTemp = new List<int>();

            for (int i = 0; i < scoreTextList.Count; i++)
            {
                scoreListTemp.Add(GetScoreID(i));
            }

            return scoreListTemp;
        }

        private int GetScoreID(int id)
        {
            return PlayerPrefs.GetInt(scoreNameSpace + id);
        }

        private string GetPseudoID(int id)
        {
            return PlayerPrefs.GetString(pseudoNameSpace + id);
        }

        private void SetupScoreboard()
        {
            for (int i = 0; i < scoreTextList.Count; i++)
            {
                scoreTextList[i].text = GetScoreID(i).ToString();
                pseudoTextList[i].text = GetPseudoID(i);
            }
        }

        private IEnumerator RestartGame()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(sceneNameReload);
        }
    }

    public enum TypeFunction
    {
        INT,
        STRING
    }
}
