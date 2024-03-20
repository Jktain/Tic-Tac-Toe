using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public static int[,] gameMatrix = new int[3, 3];
    public static int score; 
    
    private void Start()
    {
         score = 0;
         gameMatrix = new int[,]
         {
           {2, 3, 4},
           {5, 6, 7},
           {3, 5, 2}
         };
    }

    public static void CheckWin(int y, int x)
    {
        if (gameMatrix[0, 0] == gameMatrix[1, 1] && gameMatrix[1, 1] == gameMatrix[2, 2]) GameOver.instance.GameWin("diag1", 0, gameMatrix[y, x]);
        else if (gameMatrix[0, 2] == gameMatrix[1, 1] && gameMatrix[1, 1] == gameMatrix[2, 0]) GameOver.instance.GameWin("diag2", 0, gameMatrix[y, x]);
        else if (gameMatrix[y, 0] == gameMatrix[y, 1] && gameMatrix[y, 1] == gameMatrix[y, 2]) GameOver.instance.GameWin("hor", y, gameMatrix[y, x]);
        else if (gameMatrix[0, x] == gameMatrix[1, x] && gameMatrix[1, x] == gameMatrix[2, x]) GameOver.instance.GameWin("ver", x, gameMatrix[y, x]);
        else if (score == 9) GameOver.instance.GameDraw();
    }

 
}
