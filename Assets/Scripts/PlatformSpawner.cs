using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject Platform;

    private bool goingLeft;
    private bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LevelSpawner");
    }

    private IEnumerator LevelSpawner()
    {
        for (int i = 0; i < 20; i++)
        {
            int r = Random.Range(0, 2);
            if (r == 0) goingLeft = false;
            else goingLeft = true;

            if (!goingLeft)
            {
                Spawner.transform.position += new Vector3(0, 0, 2);
            }
            if (goingLeft)
            {
                Spawner.transform.position += new Vector3(2, 0, 0);
            }

            Instantiate(Platform, Spawner.transform, true);
        }



        yield return null;
    }

    public IEnumerator LevelGenerator()
    {
        while (BallController.isMovingAtAll)
        {
            yield return new WaitForSecondsRealtime(0.2f);

            int r = Random.Range(0, 2);
            if (r == 0) goingLeft = false;
            else goingLeft = true;

            if (!goingLeft)
            {
                Spawner.transform.position += new Vector3(0, 0, 2);
            }
            if (goingLeft)
            {
                Spawner.transform.position += new Vector3(2, 0, 0);
            }

            Instantiate(Platform, Spawner.transform, true);
        }


        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        if (BallController.generationStarted && !hasStarted)
        {
            StartCoroutine("LevelGenerator");
            hasStarted = true;
        }
    }
}
