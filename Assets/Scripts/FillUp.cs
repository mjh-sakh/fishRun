using UnityEngine;

public class FillUp : MonoBehaviour
{
    public GameObject filler;
    
    private void Start()
    {
        var fillerSize = filler.transform.localScale;
        var initialX = -10f;
        var initialY = -5f;
        var curPointer = new Vector3(initialX, initialY, 0);
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 100; i++)
            {
                Instantiate(filler, curPointer, Quaternion.identity);
                curPointer.x += fillerSize.x;
            }

            curPointer.x = initialX; 
            curPointer.y += fillerSize.y;
        }
    }
}
