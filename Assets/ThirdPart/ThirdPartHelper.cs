using System.Collections;
using UnityEngine;

public class ThirdPartHelper : MonoBehaviour
{

    public Animator workerAnim, cogAnim, bossAnim;
    private float t = 0.0f;
    public Avatar fallAvatar;
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
    }

    public IEnumerator AnimationHelp() {
        yield return new WaitForSeconds(10);
        workerAnim.SetTrigger("tired");
        yield return new WaitForSeconds(7);
        //workerAnim.avatar = fallAvatar;
        workerAnim.SetTrigger("fall");
    }
}
