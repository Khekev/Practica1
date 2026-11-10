using UnityEngine;

namespace Interfaces.SoundSystem
{
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] public SoundManager.SoundList sound;

        public void PlaySound()
        {
            SoundManager.GetInstance().PlayThis(sound);
        }
    }
}
