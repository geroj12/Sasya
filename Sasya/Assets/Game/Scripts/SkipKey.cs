using System.Collections;
using UnityEngine;


public class SkipKey : MonoBehaviour
{
    
    public void BlinkSkipText()
    {
        gameObject.SetActive(true);
        StartCoroutine(BlinkText());
        gameObject.SetActive(false);
    }

    IEnumerator BlinkText()
    {        
            yield return new WaitForSeconds(.5f);
           
    }

}
