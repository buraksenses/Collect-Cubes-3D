using UnityEngine;

namespace CollectCubes.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource audioSource;
        
        [SerializeField] private AudioClip winSound;
        [SerializeField] private AudioClip loseSound;
        [SerializeField] private AudioClip drawSound;
        [SerializeField] private AudioClip collectCubeSound;
        [SerializeField] private AudioClip explosionSound;

        private void Start()
        {
            // ===== Event Assignments =====

            EventManager.onGameFail += PlayLoseSound;
            EventManager.onGameDraw += PlayDrawSound;
            EventManager.onGameSuccess += PlayWinSound;
            EventManager.onPlayerCollectCube += PlayCubeCollectSound;
            EventManager.onAI_CollectCube += PlayCubeCollectSound;
            EventManager.onAI_Explodes += PlayExplosionSound;
            EventManager.onPlayerExplodes += PlayExplosionSound;
        }

        private void PlayWinSound()
        {
            audioSource.PlayOneShot(winSound);
        }
        private void PlayLoseSound()
        {
            audioSource.PlayOneShot(loseSound);
        }
        private void PlayDrawSound()
        {
            audioSource.PlayOneShot(drawSound);
        }

        private void PlayCubeCollectSound()
        {
            audioSource.PlayOneShot(collectCubeSound);
        }

        private void PlayExplosionSound()
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}

