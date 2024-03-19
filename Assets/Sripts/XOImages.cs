using UnityEngine;
using UnityEngine.UI;


public class XOImages : MonoBehaviour
{

    public Texture2D[] zeros = new Texture2D[3];   
    public Texture2D[] crosses = new Texture2D[4];
    private Texture2D sprite;

    public void SetImage()
    {
        if (WinCondition.score % 2 == 1) sprite = RanSprite(crosses);
        else sprite = RanSprite(zeros); 

        Image imageSprite = GetComponent<Image>();

        imageSprite.sprite = Sprite.Create(sprite, new Rect(0, 0, sprite.width, sprite.height), Vector2.zero);
    } 

    private Texture2D RanSprite(Texture2D[] arr)
    {
        return arr[Random.Range(0, arr.Length)];
    }
}
