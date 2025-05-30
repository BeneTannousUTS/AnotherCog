using System.Collections;
using UnityEngine;

public class ThirdPartHelper : MonoBehaviour
{

    public Animator workerAnim, cogAnim, bossAnim;
    public GameObject bossHead;
    private float t = 0.0f, bossT = 0.0f, fadeT = 0.0f;
    public Avatar fallAvatar;
    private bool isLookingAtBoss, isFadeOut;
    public GameObject fireworks, cat1, cat2;
    public AudioSource catsource;
    public AudioSource catsource2;
    public AudioClip catclip;
    public GameObject mask;
    private float maskSize = 2000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("AnimationHelp");
    }

    // Update is called once per frame
    void Update()
    {
        cogAnim.speed = Mathf.Lerp(1, 0, t / 17);
        t += Time.deltaTime;
        if (isLookingAtBoss) {
            workerAnim.transform.GetComponent<IKLookAt>().weight = Mathf.Lerp(0,1, bossT/4);
            bossT += Time.deltaTime;
        }
        if (isFadeOut) {
            mask.GetComponent<RectTransform>().sizeDelta = new Vector2(maskSize, maskSize);
            maskSize = Mathf.Lerp(2000,0, fadeT/3);
            fadeT += Time.deltaTime;
        }
    }

    public IEnumerator AnimationHelp() {
        yield return new WaitForSeconds(4);
        StartCoroutine("Fireworks");
        yield return new WaitForSeconds(4);
        cat1.GetComponent<ParticleSystem>().Play();
        cat2.GetComponent<ParticleSystem>().Play();
        StartCoroutine("CatSounds");
        yield return new WaitForSeconds(3);
        cat1.GetComponent<ParticleSystem>().Stop();
        cat2.GetComponent<ParticleSystem>().Stop();
        workerAnim.SetTrigger("tired");
        yield return new WaitForSeconds(5);
        workerAnim.transform.GetComponent<IKLookAt>().weight = 0;
        workerAnim.transform.GetComponent<IKLookAt>().target = bossHead;
        isLookingAtBoss = true;
        workerAnim.SetTrigger("fall");
        yield return new WaitForSeconds(8);
        isFadeOut = true;
    }

    public IEnumerator Fireworks() {
        foreach (Transform firework in fireworks.transform) {
            firework.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.15f);
        }
    }

    public IEnumerator CatSounds() {
        catsource.PlayOneShot(catclip);
        yield return new WaitForSeconds(0.5f);
        catsource2.pitch = 0.8f;
        catsource2.PlayOneShot(catclip);
        yield return new WaitForSeconds(0.5f);
        catsource.pitch = 1.1f;
        catsource.PlayOneShot(catclip);
        yield return new WaitForSeconds(0.5f);
        catsource2.pitch = 1.25f;
        catsource2.PlayOneShot(catclip);
        yield return new WaitForSeconds(0.5f);
        catsource.pitch = 0.9f;
        catsource.PlayOneShot(catclip);
        yield return new WaitForSeconds(0.5f);
    }
}
