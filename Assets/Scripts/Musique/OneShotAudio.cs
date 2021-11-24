using UnityEngine;
using UnityEngine.SceneManagement;

public class OneShotAudio : MonoBehaviour {
	[SerializeField] private bool playOnEnable = default;
	[SerializeField] private AudioSource source = default;
	[SerializeField] private AudioClip[] audioClips = default;
    [SerializeField] private Vector2 pitchBounds = Vector2.one;
    
	private void OnEnable() {
		if (playOnEnable) {
			PlayTheSound();
        }
    }

    public void PlayTheSound() {
		if (audioClips.Length > 0) {
            source.pitch = UnityEngine.Random.Range(pitchBounds.x, pitchBounds.y);
            AudioClip clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            source?.PlayOneShot(clip);
		}
	}

    public void PlayTheSound(float delay)
    {
        Invoke("PlayTheSound", delay);
    }
}
