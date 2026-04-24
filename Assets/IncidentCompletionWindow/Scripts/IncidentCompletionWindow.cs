using GAD210.P2.Iteration1;
using GAD210.P2.Iteration1.DialogueSystem;
using GAD210.P2.Iteration1.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration2.IncidentCompletionWindow
{
    public class IncidentCompletionWindow : MonoBehaviour
    {
        #region Variables

        [Header("Stat Increase Window")]

        [SerializeField] private GameObject _completionWindowParent;

        [SerializeField] private Button _completionWindow;

        [SerializeField] private TextMeshProUGUI _moneyEarnedText;

        [SerializeField] private TextMeshProUGUI _levelsGainedText;

        [Header("Variables")]

        [SerializeField] private bool _playingCutsceneAfter;

        public bool PlayingCutsceneAfter { set {  _playingCutsceneAfter = value; } }

        private int _cutsceneToPlay;

        [Header("Scripts")]

        [SerializeField] private CutsceneManager _cutsceneManager;

        #endregion

        #region

        public void EnableCompletionWindow()
        {
            PackageCreature currentPackageCreature = PlayerPackageCreatureManager.instance.CurrentPackageCreature;

            _moneyEarnedText.text = "Money Gained: $" + PlayerMoneyManager.instance.PlayerMoney.ToString();

            _levelsGainedText.text = currentPackageCreature.PackageCreatureName + " is now <b>Level " + currentPackageCreature.PackageCreatureLevel.ToString() + "</b>";

            _completionWindowParent.SetActive(true);

            _completionWindow.Select();
        }

        public void InitialisePlayingCutscene(int cutscene)
        {
            _cutsceneToPlay = cutscene;
            _playingCutsceneAfter = true;
        }

        // Called in OnClick method on button
        public void CheckForCutscenePlaying()
        {
            if (_playingCutsceneAfter == true)
            {
                _cutsceneManager.EnableCutscene(_cutsceneToPlay);
            }
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}