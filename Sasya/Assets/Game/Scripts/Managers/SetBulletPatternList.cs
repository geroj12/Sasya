using UnityEngine;

public class SetBulletPatternList : MonoBehaviour
{
    [SerializeField]
    private GameObject[] BulletPatterns = null;

    private void Start()
    {
        if (BulletPatterns != null)
        {
            for (int i = 0; i < BulletPatterns.Length; i++)
            {
                BulletPatterns[i].SetActive(false);
            }
        }
    }
}