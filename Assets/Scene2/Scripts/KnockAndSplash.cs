using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class KnockAndSplash : MonoBehaviour
{
    private Collider canisterCollider;

    public GameObject splashPrefab;
    
    
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
        if (collider.gameObject.CompareTag("Floor"))
        {
            MakeSplashDecal(collider.GetContact(0));
        }
    }
    

    void MakeSplashDecal(ContactPoint contact)
    {
        GameObject splash = Instantiate(splashPrefab, contact.point, Quaternion.Euler(90, 0, 0));
        splash.GetComponent<DecalProjector>().size = Vector3.zero;
        StartCoroutine(ScaleDecalOverTime(splash));
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
