using System.Threading.Tasks;
using UnityEngine;

public class IcePatchMelt : MonoBehaviour
{
    public async Task Melt(int delay)
    {
        var col = GetComponent<Collider2D>();
        await Task.Delay(delay);
        Destroy(col);
        
        while (GetComponent<Transform>().localScale.x > 0)
        {
            gameObject.transform.localScale -= new Vector3(.03f, .03f) * Time.deltaTime;
            await Task.Delay(1);
        }
        
        Destroy(gameObject);
    }

}
