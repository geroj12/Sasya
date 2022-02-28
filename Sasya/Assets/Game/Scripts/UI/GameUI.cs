using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using System.Collections;
using UnityEngine.InputSystem;

namespace Purgatory
{
    public class GameUI : MonoBehaviour
    {
        public static GameUI singleton;

        public GameObject pickupText;

        [SerializeField]
        private GameObject mainMenu;

        private PlayerControls playercontrols;

        [SerializeField]
        private GameObject pressAnyKeyToSkip;

        [SerializeField]
        private GameObject blackFade;
    

        [SerializeField]
        private GameObject[] gameUI;

        [SerializeField]
        private PlayableDirector playableDirector;

        [SerializeField]
        private GameObject player;

        [SerializeField]
        private Animator cloudanimator;

        [SerializeField]
        private GameObject startCutscene;

        private bool anykey;
        private bool cutsceneover = false;

        [SerializeField] private PlayerHit playerHitUIFeedback;
        [SerializeField] private PlayerHeal playerHealUIFeedback;
        [SerializeField] private InputActionAsset inputasset;
        private bool cutsceneIsPlaying = false;
        private bool skiptextpromptactive = false;
        private void Awake()
        {
            singleton = this;
        }

        public void Start()
        {
            playercontrols = new PlayerControls();
            playercontrols.Enable(); 
            
        }
        public void AnyKeyPressed()
        {
            if (!cutsceneover)
            {
                if (skiptextpromptactive)
                {
                    SkipCutscene();
                }
                
                skiptextpromptactive = true;
                
            }
        }
      
     
        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        public void StartButtonPressed() {
            pressAnyKeyToSkip.SetActive(true);
            mainMenu.SetActive(false);
            startCutscene.SetActive(true);
        }

        private void SkipCutscene()
        {
            StartCoroutine(waitTime());
        }

        IEnumerator waitTime() { 
            blackFade.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            playableDirector.time = playableDirector.playableAsset.duration; // set the time to the last frame
            playableDirector.Evaluate(); // evaluates the timeline
            playableDirector.Stop(); // deletes the instance of the timeline
            StartGame(); 
            
        }

        public void StartGame()
        {           
            player.GetComponent<Player>().enabled = true;
            player.GetComponent<GameOver>().enabled = true;
            foreach (GameObject gameObject in gameUI)
            {
                gameObject.SetActive(true);
            }
            
            pressAnyKeyToSkip.SetActive(false);
            cutsceneover = true; 
            cloudanimator.SetTrigger("CutsceneFinished");
            
        }

        public void ActivateHitUIFeedback()
        {
            playerHitUIFeedback.ActivateHitUIFeedback();
        }

        internal void DisableHitUIFeedback()
        {
            playerHitUIFeedback.DisableHitUIFeedback();
        }

        public void ActivateHealUIFeedback()
        {
            playerHealUIFeedback.ActivateHealUIFeedback();
        }

        internal void DisableHealUIFeedback()
        {
            playerHealUIFeedback.DisableHealUIFeedback();
        }

        bool GetButtonStatus(UnityEngine.InputSystem.InputActionPhase phase)
        {
            return phase == UnityEngine.InputSystem.InputActionPhase.Started;
        }
    }
}
