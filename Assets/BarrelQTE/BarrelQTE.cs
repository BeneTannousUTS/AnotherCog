using System.Collections;
using Unity.Cinemachine;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BarrelQTE : MonoBehaviour
{
    public Animator animator;
    private bool Jumping;
    private bool IsJumping = false;
    private float score;
    public Text scoreHud;
    public ParticleSystem par;
    public CinemachineCamera cam1;
    public CinemachineCamera cam2;
    AudioSource source;
    AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        clip1 = source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping){
            animator.SetTrigger("jump");
            IsJumping = true;
            StartCoroutine(jump());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Jumping)
        {
            source.clip = clip3;
            source.loop = false;
            source.Play();
            StartCoroutine(roll());
            animator.SetTrigger("fall");
        }
        if (Jumping)
        {
            score += 0.5f;
            scoreHud.text = "Barrels Jumped: " + score.ToString() + "/3";
        }

        if (score >= 3)
        {
            GameObject.FindAnyObjectByType<GroundAndBarrel>().spawn = false;
            GameObject.FindAnyObjectByType<GroundAndBarrel>().SpawnPipe();
        }
    }


    IEnumerator roll()
    {
        CinemachineBasicMultiChannelPerlin a = cam1.GetComponent<CinemachineBasicMultiChannelPerlin>();
        CinemachineBasicMultiChannelPerlin b = cam2.GetComponent<CinemachineBasicMultiChannelPerlin>();
        a.AmplitudeGain = 3;
        b.AmplitudeGain = 3;
        yield return new WaitForSeconds(1);
        source.clip = clip1;
        source.loop = true;
        source.Play();
        a.AmplitudeGain = 0;
        b.AmplitudeGain = 0;
    }
    IEnumerator jump()
    {
        source.clip = clip2;
        source.loop = false;
        source.Play();
        cam1.Priority = 2;
        yield return new WaitForSeconds(0.200f);
        Jumping = true;
        yield return new WaitForSeconds(0.300f);
        Jumping =false;
        source.clip = clip1;
        source.loop = true;
        source.Play();
        yield return new WaitForSeconds(0.367f);
        IsJumping = false;
        cam1.Priority = 0;
    }
}
