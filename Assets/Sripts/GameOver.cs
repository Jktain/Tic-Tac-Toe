using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public static GameObject[] winLines;
    public static GameOver instance;
    public GameObject restartMenu, playMenu, gameOverPicture, topBar;
    public TextMeshProUGUI winText;
    public Texture2D[] winImages;
    private void Start()
    {
        instance = this;
    }

    public static void DisableButtons(bool active)
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        { 
            button.gameObject.SetActive(active);
        }
    }
    
    public void GameWin(string winLine, int LineNumber, int winner)
    {
        DisableButtons(false);
        Theme.instance.SetWinLineColor();
        CreateWinLine(LineNumber, winLine, winLines);
        topBar.SetActive(false);
        StartCoroutine(GameOverCor(winner, 2f));
    }

    public void CreateWinLine(int lineIndex, string lineName, GameObject[] winLines)
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        GameObject winLine = null;

        switch (lineName)
        {
            case "diag1":
                winLine = Instantiate(winLines[0], playMenu.transform);
                break;
            case "diag2":
                winLine = Instantiate(winLines[1], playMenu.transform);
                break;
            case "hor":
                winLine = Instantiate(winLines[2], playMenu.transform);
                if (lineIndex == 0)
                    winLine.transform.position = new Vector2(0, 150f);
                else if (lineIndex == 2)
                    winLine.transform.position = new Vector2(0, -580f);
                break; 
            case "ver":
                winLine = Instantiate(winLines[3], playMenu.transform);
                if (lineIndex == 0)
                    winLine.transform.position = new Vector2(-370f, -250f);
                else if (lineIndex == 2)
                    winLine.transform.position = new Vector2(370f, -250f);
                break;
        }

        //Destroy(winLine, 2f);
    }

    public void GameDraw()
    {
        topBar.SetActive(false);
        StartCoroutine(GameOverCor(2, 0.1f));
        winText.text = "Nobody wins";
    }

    public IEnumerator GameOverCor(int winner, float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverPicture.GetComponent<Image>().sprite = Sprite.Create(winImages[winner], new Rect(0, 0, winImages[winner].width, winImages[winner].height), Vector2.zero);
        gameOverPicture.GetComponent<Image>().SetNativeSize();
        restartMenu.SetActive(true);
        playMenu.SetActive(false);
    }
}
