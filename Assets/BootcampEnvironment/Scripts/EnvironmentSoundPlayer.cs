using GAD210.P2.Iteration1.Player;
using UnityEngine;

namespace GAD210.P2.Iteration1
{
    public class EnvironmentSoundPlayer : SoundPlayer
    {
        #region Static Declaration

        public static EnvironmentSoundPlayer instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #endregion

        public override AudioClip GetSFX(string soundEffect)
        {
            switch (soundEffect)
            {
                case "Money":
                    return _soundEffects[0];
                case "Victory Horn":
                    return _soundEffects[1];
                case "Metal Creak":
                    return _soundEffects[2];
                case "Party Horn":
                    return _soundEffects[3];
                case "Child Cheer":
                    return _soundEffects[4];
                case "Failure":
                    return _soundEffects[5];
                case "Success":
                    return _soundEffects[6];
                default:
                    return null;
            }
        }
    }
}