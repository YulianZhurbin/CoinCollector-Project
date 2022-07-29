using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] TMP_Text countText;
    [SerializeField] GameObject victoryText;

    private static GameManager instance;

    private int coinCount;
    private int totalCoinAmount;
    private bool isGameOver;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalCoinAmount = GameObject.FindObjectsOfType<CoinController>().Length;
        Debug.Log("totalCoinAmount: " + totalCoinAmount);
    }
    
    public void AddCoin()
    {
        coinCount++;
        countText.text = "Coins: " + coinCount;

        if(coinCount == totalCoinAmount)
        {
            Congratulate();
        }
        else
        {
            AudioManager.Instance.PlayPick();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void Congratulate()
    {
        StopGame();
        victoryText.SetActive(true);
        VFXManager.Instance.PlayOffFireworks();
        AudioManager.Instance.PlayVictory();
    }
    public void StopGame()
    {
        isGameOver = true;
        StartCoroutine(ShowMenu());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(1.0f);
        menu.SetActive(true);
    }
}
