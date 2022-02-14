using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PathMark : MonoBehaviour
{
    // Start is called before the first frame update
    private async Task Start()
    {
        transform.localScale = Vector3.zero;
        await Grow();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private async Task Grow()
    {
        await Task.Delay(500);
        
        while (GetComponent<Transform>().localScale.x < .8f)
        {
            gameObject.transform.localScale += new Vector3(.1f, .1f) * Time.deltaTime;
            await Task.Delay(1);
        }

        // await Shrink();
    }

    private async Task Shrink()
    {
        while (GetComponent<Transform>().localScale.x > 0)
        {
            gameObject.transform.localScale -= new Vector3(.1f, .1f) * Time.deltaTime;
            await Task.Delay(1);
        }
        
        Destroy(gameObject);
    }
}