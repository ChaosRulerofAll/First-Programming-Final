using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float camSpeed;
    [SerializeField] private GameObject cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BallController.isMovingAtAll && BallController.isMovingX && !BallController.isOffGround)
        {
            cam.transform.position += (BallController.movementDirectionX * camSpeed * Time.deltaTime);
        }

        if (BallController.isMovingAtAll && !BallController.isMovingX && !BallController.isOffGround)
        {
            cam.transform.position += (BallController.movementDirectionZ * camSpeed * Time.deltaTime);
        }


    }


}
