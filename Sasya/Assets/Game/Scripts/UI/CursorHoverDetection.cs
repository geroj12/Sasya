using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{

    public class CursorHoverDetection : MonoBehaviour
    {
        RaycastHit hit;
        Ray ray;
        [SerializeField]
        private Texture2D[] cursorTexture;
        [SerializeField]
        CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = new Vector2(0,0);

        Player player;

        private void Start()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            //Detect();
        }

        private void FixedUpdate()
        {
            Detect();
        }


        void Detect()
        {
            ray = Camera.main.ScreenPointToRay(player.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                
                    DetectBoss();
                    DetectFlower();

            }
        }

        bool bossDetected;
        void DetectBoss()
        {
            
            if (hit.collider.gameObject.name == "BossEnemy" && !flowerDetected)
            {
                bossDetected = true;
                //Debug.Log("Mouse Cursor Boss");
                Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
            }
            else if(!flowerDetected)
            {
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                bossDetected = false;
            }
        }

        bool flowerDetected;
        void DetectFlower()
        {
            
            if (hit.collider.gameObject.CompareTag("FlowerBudsDetection") )
            {
                flowerDetected = true;
                //Debug.Log("Mouse Cursor Flower");
                Cursor.SetCursor(cursorTexture[1], hotSpot, cursorMode);
            }
            else if(!bossDetected)
            {
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                flowerDetected = false;
            }

        }
    }
}
