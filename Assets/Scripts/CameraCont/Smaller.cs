using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaller : MonoBehaviour
{
    public GameObject player;

    private float size_small = 0.2f;
    private float size_big = 10f;
    public float speed;
    private float time;

    public AudioClip[] sounds;
    AudioSource audioSource;

    private Vector3 originScale;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        originScale = player.transform.localScale;
    }

    public void GetSmaller()
    {
        StartCoroutine(SmallStart());
    }

    public void GetBigger()
    {
        StartCoroutine(BigStart());
        audioSource.PlayOneShot(sounds[0]);
    }

    IEnumerator SmallStart()
    {
        while (player.transform.localScale.x > size_small)
        {
            player.transform.localScale = originScale * (1f - time * speed);
            time += Time.deltaTime;

            if (player.transform.localScale.x <= size_small)
            {
                time = 0;
                break;
            }
            yield return null;
        }

        StartCoroutine(SetOrigin());
    }

    IEnumerator BigStart()
    {
        while (player.transform.localScale.x < size_big)
        {
            player.transform.localScale = originScale * (1f + time * speed);
            time += Time.deltaTime;

            if (player.transform.localScale.x >= size_big)
            {
                time = 0;
                break;
            }
            yield return null;
        }

        StartCoroutine(SetOrigin());
    }

    IEnumerator SetOrigin()
    {
        yield return new WaitForSeconds(5.0f);
        Vector3 playerpos = player.transform.position;
        playerpos.y = 3;
        player.transform.position = playerpos;
        player.transform.localScale = originScale;

    }


}
