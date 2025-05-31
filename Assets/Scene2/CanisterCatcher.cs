using System;
using UnityEngine;

public class CanisterCatcher : MonoBehaviour
{
    int caught = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Canister"))
        {
            CatchCanister(other.gameObject);
        }
    }
    
    void CatchCanister(GameObject canister)
    {
        if (canister.GetComponent<KnockAndSplash>().canBeCaught)
        {
            Transform spot = canister.GetComponent<KnockAndSplash>().placeCaughtCanister;
            canister.transform.position = spot.position;
            canister.transform.rotation = spot.rotation;
            canister.GetComponent<Rigidbody>().isKinematic = true;
            canister.GetComponent<Rigidbody>().useGravity = false;
            canister.GetComponent<KnockAndSplash>().isCaught = true;
            caught++;
            PlayCatchSound();
        }
    }

    public int GetCaught()
    {
        return caught;
    }
    
    public AudioClip catchClip;
    public AudioSource audioSource;

    void Awake()
    {
        if (!audioSource)
            audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayCatchSound()
    {
        if (catchClip == null || audioSource == null) return;
        
        audioSource.PlayOneShot(catchClip);
    }
}