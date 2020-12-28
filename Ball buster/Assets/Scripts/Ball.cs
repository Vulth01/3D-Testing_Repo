
using UnityEngine;

public class Ball: MonoBehaviour
{

    public Transform centreTransform;

   
    void Update()
    {

        if (Input.GetKey("a"))
        {
            movementfunction(-1);
        }

        if (Input.GetKey("d"))
        {
            movementfunction(1);
        }
    }
    public void Initialize(Transform centreTrans)
    {
        //injecting dependancies from the startup script
        centreTransform = centreTrans;
    }

    [SerializeField]
    float rotationSpeed = 60;

    private void movementfunction(int directioninput)
    {


        transform.RotateAround(centreTransform.position, new Vector3(0f, 0f, 1f), directioninput * rotationSpeed * Time.deltaTime);



    }
}
