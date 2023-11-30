using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private float ballSpeed;
    [SerializeField] private GameObject ball;

    public static Vector3 movementDirectionX = new Vector3(1f, 0f, 0f);
    public static Vector3 movementDirectionZ = new Vector3(0f, 0f, 1f);
    public static Vector3 movementDirectionY = new Vector3(0f, -2f, 0f);

    public static bool isMovingX = false;
    public static bool isMovingAtAll = false;
    public static bool isOffGround = false;

    public static bool generationStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isMovingAtAll = true;
            isMovingX = !isMovingX;

            if (!generationStarted)
            {
                generationStarted = true;
            }
        }

        if (isMovingAtAll && isMovingX && !isOffGround)
        {
            ball.transform.position += (movementDirectionX * ballSpeed * Time.deltaTime);
        }
        
        if (isMovingAtAll && !isMovingX && !isOffGround)
        {
            ball.transform.position += (movementDirectionZ * ballSpeed * Time.deltaTime);
        }

        if (isOffGround)
        {
            ball.transform.position += (movementDirectionY * ballSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine("Dead");
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        isOffGround = true;
        isMovingAtAll = false;

        yield return null;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOffGround = false;
            //isMovingAtAll = true;

            StopCoroutine("Dead");
        }
    }

}
