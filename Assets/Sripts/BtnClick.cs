using UnityEngine.UI;
using UnityEngine;

public class BtnClick : MonoBehaviour
{
    public Texture2D[] turnImgs; //
    public GameObject moveImg;


    public void Move()
    {
        WinCondition.score++;
        int y = int.Parse(gameObject.name.Substring(0, 1));
        int x = int.Parse(gameObject.name.Substring(1, 1));
        WinCondition.gameMatrix[y, x] = WinCondition.score % 2;
        WinCondition.CheckWin(y, x);
        TurnToMove();
    }

    private void TurnToMove()
    {
        int nextTurn = (WinCondition.score + 1) % 2;
        moveImg.GetComponent<Image>().sprite = Sprite.Create(turnImgs[nextTurn], new Rect(0, 0, turnImgs[nextTurn].width, turnImgs[nextTurn].height), Vector2.zero);
    }
}
