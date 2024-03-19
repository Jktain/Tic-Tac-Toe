using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Theme : MonoBehaviour
{
    public static Theme instance;
    public Camera mainCamera;
    public Button changeThemeBtn;
    public TextMeshProUGUI btnText, turn;
    public Texture2D whiteNet, blackNet;
    public GameObject[] blackWinLines, whiteWinLines;
    private Color mainColor;

    private void Start()
    {
        instance = this;

        mainColor = HexToColor(PlayerPrefs.GetString("mainColor"));

        if (mainColor == Color.black)
            SetColors(Color.black, whiteNet, Color.white);
        else if (mainColor == Color.white)
            SetColors(Color.white, blackNet, Color.black);
    }

    public void ChangeTheme()
    {
        if (mainCamera.backgroundColor == Color.white)
            SetColors(Color.black, whiteNet, Color.white);
        else
            SetColors(Color.white, blackNet, Color.black);
    }

    public void SetWinLineColor()
    {
        if (mainCamera.backgroundColor == Color.white)
            GameOver.winLines = blackWinLines;
        else
            GameOver.winLines = whiteWinLines;

    }

    private void SetColors(Color bgColor, Texture2D net, Color btnTextColor)
    {
        Image Net = GetComponent<Image>();
        mainCamera.backgroundColor = bgColor;
        btnText.color = btnTextColor;
        turn.color = btnTextColor;
        Net.sprite = Sprite.Create(net, new Rect(0, 0, net.width, net.height), Vector2.zero);

        PlayerPrefs.SetString("mainColor", ColorUtility.ToHtmlStringRGB(mainCamera.backgroundColor));
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }
}
