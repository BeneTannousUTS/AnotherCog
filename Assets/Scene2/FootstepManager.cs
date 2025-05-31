using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource audioSource;

    void Awake()
    {
        if (!audioSource)
            audioSource = GetComponent<AudioSource>();
    }

    // This function will be called by animation events
    public void PlayFootstep()
    {
        if (footstepClips.Length == 0 || audioSource == null) return;

        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        audioSource.PlayOneShot(clip);
    }
}