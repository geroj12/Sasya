using UnityEngine;

namespace Purgatory
{

    public class ImagePatternTrigger180 : MonoBehaviour
    {
        public Shooter shooter;

        public Texture2D pattern;

        float gameTime = 0;
        public float timeScale = 10.0f;

        private void Update()
        {
            float oldTime = gameTime;
            gameTime += Time.deltaTime * timeScale;

            int prevIndex = (int)oldTime;
            int nextIndex = (int)gameTime;

            for (int y = prevIndex; y < nextIndex; y++)
            {
                for (int x = 0; x < 220; x++)
                {
                    var pixelColor = pattern.GetPixel(x, y);
                    if (pixelColor.r < 0.5f)
                    {
                        shooter.Shoot(x);
                    }
                }
            }
        }
    }
}
