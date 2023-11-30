using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{

    [SerializeField] private GameObject platform;

    private Vector3 fallDir;

    private float time = 2;
    private float fallSpeed = 2;


    private void Start()
    {
        fallDir = new Vector3(0, -1, 0);
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Fall");
            Destroy(platform, 2f);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        while (time > 0)
        {
            platform.transform.position += fallDir * fallSpeed * Time.deltaTime;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        time = 2;

        yield return null;
    }

}
