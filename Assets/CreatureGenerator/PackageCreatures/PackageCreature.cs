using UnityEngine;

[CreateAssetMenu(fileName = "PackageCreature", menuName = "Scriptable Objects/PackageCreature")]
public class PackageCreature : ScriptableObject
{
    #region Variables

    [SerializeField] protected string _packageCreatureName;
    public string PackageCreatureName { get { return _packageCreatureName; }}

    [Space(5)]

    [TextArea]
    [SerializeField] protected string _packageCreatureDescription;
    public string PackageCreatureDescription { get { return _packageCreatureDescription; }}

    [Space(5)]

    [TextArea]
    [SerializeField] protected string _packageCreaturePersonality;
    public string PackageCreaturePersonality { get { return _packageCreaturePersonality; } }

    [Space(5)]

    [SerializeField] protected float _packageCreatureWeight;
    public float PackageCreatureWeight { get { return _packageCreatureWeight; }}

    [Space(5)]

    [SerializeField] protected float _packageCreatureLength;
    public float PackageCreatureLength { get { return _packageCreatureLength; }}

    [Space(5)]

    [SerializeField] protected string _packageCreatureAbilityName;
    public string PackageCreatureAbilityName { get { return _packageCreatureAbilityName; } }

    [Space(5)]

    [TextArea]
    [SerializeField] protected string _packageCreatureAbilityDescription;
    public string PackageCreatureAbilityDescription { get {return _packageCreatureAbilityDescription; }}

    [Space(5)]

    [SerializeField] protected Sprite _packageCreatureDisplayImage;
    public Sprite PackageCreatureDisplayImage { get { return _packageCreatureDisplayImage; }}

    public enum AbilityType
    {
        Adaptability = 0,
    }

    [SerializeField] protected AbilityType _abilityType;

    public AbilityType AbilityTypeGetter { get { return _abilityType; } }

    #endregion
}
