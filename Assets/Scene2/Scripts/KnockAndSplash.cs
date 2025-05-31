using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class KnockAndSplash : MonoBehaviour
{
    private Collider canisterCollider;

    public GameObject splashPrefab;
    public bool isCaught = false;
    public Transform placeCaughtCanister;
    public bool canBeCaught = true;
    
    [HideInInspector] public Vector3 targetPosition;
    [HideInInspector] public Quaternion targetRotation;
    public float lerpSpeed = 8f;
    
    public AudioClip fallClip;
    public AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canisterCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Floor") && !isCaught)
        {
            MakeSplashDecal(collider.GetContact(0));
            canBeCaught = false;
        }
    }
    

    void MakeSplashDecal(ContactPoint contact)
    {
        GameObject splash = Instantiate(splashPrefab, contact.point, Quaternion.Euler(90, 0, 0));
        splash.GetComponent<DecalProjector>().size = Vector3.zero;
        StartCoroutine(ScaleDecalOverTime(splash));
        PlayFallSound();
    }
    
    public void PlayFallSound()
    {
        if (fallClip == null || audioSource == null) return;
        
        audioSource.PlayOneShot(fallClip);
    }

    System.Collections.IEnumerator ScaleDecalOverTime(GameObject splash)
    {
        float scaleTime = 0.5f;
        float elapsed = 0f;
        DecalProjector projector = splash.GetComponent<DecalProjector>();

        while (elapsed < scaleTime)
        {
            elapsed += Time.deltaTime;
            float scale = elapsed / scaleTime;
            projector.size = new Vector3(scale, scale, scale);
            yield return null;
        }
        
        projector.size = Vector3.one;
    }
}
