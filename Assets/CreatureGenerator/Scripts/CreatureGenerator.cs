using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.PackageCreatures
{
    public class CreatureGenerator : MonoBehaviour
    {
        #region Variables

        [Header("Creatures")]

        [Space(5)]

        // Scriptable objs here
        [SerializeField] private List<PackageCreature> _packageCreatureList = new List<PackageCreature>();

        [Header("Creature Data Text Fields")]

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _creatureNameTextField;

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _creatureDescriptionTextField;

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _creaturePersonalityTextField;

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _creatureWeightTextField;

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _creatureLengthTextField;

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _creatureAbilityDescriptionTextField;

        [Space(5)]

        [SerializeField] private Image _creatureDisplayImage;

        #endregion

        #region Methods

        public void CreateCreature(int creature)
        {
            // Set text fields

            _creatureNameTextField.text = _packageCreatureList[creature].PackageCreatureName;

            _creatureDescriptionTextField.text = "<b>Description: </b>" + _packageCreatureList[creature].PackageCreatureDescription;

            _creaturePersonalityTextField.text = "<b>Personality: </b>" + _packageCreatureList[creature].PackageCreaturePersonality;

            _creatureWeightTextField.text = "<b>Weight: </b>" + _packageCreatureList[creature].PackageCreatureWeight.ToString() + " kg";

            _creatureLengthTextField.text = "<b>Length: </b>" + _packageCreatureList[creature].PackageCreatureLength.ToString() + " cm";

            _creatureAbilityDescriptionTextField.text = "<b>Ability: </b>" + _packageCreatureList[creature].PackageCreatureAbilityDescription;

            _creatureDisplayImage.sprite = _packageCreatureList[creature].PackageCreatureDisplayImage;

            // Set as player's package manager

            PlayerPackageCreatureManager.instance.SetPackageCreatureAsPlayers(_packageCreatureList[creature]);
        }

        public void ResetVariables()
        {
            _creatureDescriptionTextField.text = "<b>Description: </b>";

            _creaturePersonalityTextField.text = "<b>Personality: </b>";

            _creatureWeightTextField.text = "<b>Weight: </b>";

            _creatureLengthTextField.text = "<b>Length: </b>";

            _creatureAbilityDescriptionTextField.text = "<b>Ability: </b>";
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //ResetVariables();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}