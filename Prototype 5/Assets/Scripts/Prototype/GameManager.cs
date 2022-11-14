using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager i;

        public List<GameObject> targets;
        public TextMeshProUGUI gameOverText;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI scoreText;

        private int difficulty;
        private int score;
        private float spawnRate = 1.0f;

        public bool isGameActive;

        private void Start()
        {
            i = this;
            UpdateScore(-score);
        }

        private IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }

        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = $"Score: {score}";
        }

        public void GameOver()
        {
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            StopCoroutine(SpawnTarget());
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void SetDifficulty(int scale)
        {
            difficulty = scale;
            spawnRate /= difficulty;

            titleText.gameObject.SetActive(false);
            isGameActive = true;
            StartCoroutine(SpawnTarget());
        }
    }
}