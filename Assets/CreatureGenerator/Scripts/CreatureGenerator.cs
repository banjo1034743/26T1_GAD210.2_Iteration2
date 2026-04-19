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

        #region Package Creature Const Int Values

        private const int Inpup = 0;

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private PlayerMenuManager _playerMenuManager;

        #endregion

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

        //[Header("Package Data Text Fields")]

        //[SerializeField] private TextMeshProUGUI _packageNameTextField;

        //[SerializeField] private TextMeshProUGUI _authorNameTextField;

        //[SerializeField] private TextMeshProUGUI _publishedDateTextField;

        //[SerializeField] private TextMeshProUGUI _categoryTextField;

        #endregion

        #region Methods

        //public void CreateCreature(string packageName)
        //{

        //    //---
        //    _authorName = authorName;

        //    _packageDisplayName = packageName;

        //    _datePublished = datePublished;

        //    //_packageCategory = category;

        //    Debug.Log("Author name = " + _authorName);
        //    //Debug.Log("Category = " + _packageCategory);
        //    Debug.Log("Date = " + _datePublished);
        //    Debug.Log("Name = " + _packageDisplayName);

        //    DisplayCreatureInfo();
        //    DisplayPackageData();
        //}

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