using UnityEngine.UI;
using UnityEngine;

public class BtnClick : MonoBehaviour 
{
    public Texture2D[] turnImgs; // Масив з картинками хрестика і нулика 
    public GameObject moveImg; // Об'єкт на сцені, що показує хто ходить наступний


    public void Move()
    {
        WinCondition.score++;
        // Ім'я кнопок - індекси елемента масива, якому буде призначене значення 0, або 1 в залежності від того, хто ходить
        int y = int.Parse(gameObject.name.Substring(0, 1));
        int x = int.Parse(gameObject.name.Substring(1, 1));
        WinCondition.gameMatrix[y, x] = WinCondition.score % 2;
        if(WinCondition.score >= 5) // До п'ятого ходу неможливо виграти, оскільки на полі повинно бути як мінімум 3 хрестика і 2 нулика
            WinCondition.CheckWin(y, x);
        TurnToMove();
    }

    private void TurnToMove() // Функція, що визначає хто ходить наступний і присвоює картинку об'єкту сцени moveImg
    {
        int nextTurn = (WinCondition.score + 1) % 2;
        moveImg.GetComponent<Image>().sprite = Sprite.Create(turnImgs[nextTurn], new Rect(0, 0, turnImgs[nextTurn].width, turnImgs[nextTurn].height), Vector2.zero);
    }
}
