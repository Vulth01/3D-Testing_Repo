using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public _Muscle[] muscles;//array to instantiate the _Muscles class 
    private _Muscle[] muscleResting;
    public LayerMask groundLayer;// used to set what is ground for isgrounded function

    public Rigidbody2D rbLowerRightLeg;
    public Rigidbody2D rbLowerLeftLeg;
    public Rigidbody2D rbUpperback;
    public float towardsForce = 50;

    public Rigidbody2D rbHead;
    public Rigidbody2D rbLowerback;

    public Rigidbody2D rbRightFoot;
    public Rigidbody2D rbLeftFoot;

    //  public Transform rbRightFoot;
    // public Transform rbLeftFoot;

    [SerializeField]
    private float jumpforce = 100;

    public Vector2 moveRightVector;
    public Vector2 moveLeftVector;

    public Camera cam;
    public Transform rbGun;


    private bool isBlocking = false;

    void Start()
    {
      
        muscleResting = muscles;
        

    }
    // Update is called once per frame
    void Update()
    {
        foreach (_Muscle muscle in muscles)
        {
            muscle.ActivateMuscle();
        }




        if (Input.GetKey(KeyCode.D))
        {
            // MoveTowards(towardsForce);
            moveRightStep1();
            Invoke("moveRightStep2", 0.085f);

        }



        if (Input.GetKey(KeyCode.A))
        {
            // MoveTowards(towardsForce*-1);
            moveLeftStep1();
            Invoke("moveLeftStep2", 0.085f);
        }



        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (true)
        {
            //AimPistol();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            

            Block();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            unBlock();
           
            int i = 0;
            foreach (_Muscle muscle in muscleResting)
            {
                Debug.Log(muscleResting[i].force);
                Debug.Log(muscleResting[i].restRotation);
                i++;
            }

        }

    }

    private float circleDitance;

    private bool isGrounded()
    {
        RaycastHit2D Lefthit = Physics2D.CircleCast(rbLeftFoot.position, 0.1f, Vector2.zero, 0f, groundLayer);



        RaycastHit2D Righthit = Physics2D.CircleCast(rbRightFoot.position, 0.1f, Vector2.zero, 0f, groundLayer);



        return Lefthit.collider != null || Righthit.collider != null;
    }
    private void jump()
    {
        rbUpperback.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
    }
    private void moveRightStep1()
    {
        rbLowerRightLeg.AddForce(moveRightVector * Time.deltaTime, ForceMode2D.Impulse);
        rbLowerLeftLeg.AddForce(moveRightVector * -0.5f * Time.deltaTime, ForceMode2D.Impulse);

    }

    private void moveRightStep2()
    {
        rbLowerLeftLeg.AddForce(moveRightVector * Time.deltaTime, ForceMode2D.Impulse);
        rbLowerRightLeg.AddForce(moveRightVector * -0.5f * Time.deltaTime, ForceMode2D.Impulse);

    }

    private void moveLeftStep1()
    {
        rbLowerRightLeg.AddForce(moveLeftVector * Time.deltaTime, ForceMode2D.Impulse);
        rbLowerLeftLeg.AddForce(moveLeftVector * -0.5f * Time.deltaTime, ForceMode2D.Impulse);

    }

    private void moveLeftStep2()
    {
        rbLowerLeftLeg.AddForce(moveLeftVector * Time.deltaTime, ForceMode2D.Impulse);
        rbLowerRightLeg.AddForce(moveLeftVector * -0.5f * Time.deltaTime, ForceMode2D.Impulse);

    }
    private void MoveTowards(float moveForce)
    {
        rbHead.AddForce(new Vector2(moveForce * Time.deltaTime, 0));
        rbLowerback.AddForce(new Vector2(moveForce * Time.deltaTime, 0));
        rbUpperback.AddForce(new Vector2(moveForce * Time.deltaTime, 0));
    }




    private void AimPistol()
    {

        Vector2 direction = (rbGun.position - cam.ScreenToWorldPoint(Input.mousePosition));
        float aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;


        if (aimAngle < 90 && aimAngle > 0 || aimAngle > 270 && aimAngle < 360)
        {

            muscles[7].restRotation = aimAngle + 65;
            muscles[8].restRotation = aimAngle + 150;
            muscles[9].restRotation = aimAngle + 95;
            muscles[10].restRotation = aimAngle + 100;

            muscles[7].force = 500;
            muscles[8].force = 500;
            muscles[9].force = 500;
            muscles[10].force = 500;
        }
        if (aimAngle > 90 && aimAngle < 270)
        {

            muscles[7].restRotation = aimAngle + 116;
            muscles[8].restRotation = aimAngle + 81;
            muscles[9].restRotation = aimAngle + 95;
            muscles[10].restRotation = aimAngle + 100;

            //  muscles[9].restRotation = aimAngle +65;
            // muscles[10].restRotation = aimAngle + 150;
            //muscles[7].restRotation = aimAngle +95;
            //muscles[8].restRotation = aimAngle +100;

            muscles[7].force = 500;
            muscles[8].force = 500;
            muscles[9].force = 500;
            muscles[10].force = 500;

        }

    }
    private void Block()
    {


        Vector2 direction = (rbUpperback.transform.position - cam.ScreenToWorldPoint(Input.mousePosition));
        float aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;


        muscles[7].restRotation = aimAngle;
        muscles[8].restRotation = aimAngle;
        muscles[9].restRotation = aimAngle;
        muscles[10].restRotation = aimAngle;

        muscles[7].force = 500;
        muscles[8].force = 500;
        muscles[9].force = 500;
        muscles[10].force = 500;





    }
    private void unBlock()
    {

        muscles[7].force = muscleResting[7].force;
        muscles[8].force = muscleResting[8].force;
        muscles[9].force = muscleResting[9].force;
        muscles[10].force = muscleResting[10].force;


        muscles[7].restRotation = muscleResting[7].restRotation;
        muscles[8].restRotation = muscleResting[8].restRotation;
        muscles[9].restRotation = muscleResting[9].restRotation;
        muscles[10].restRotation = muscleResting[10].restRotation;
    }
}

[System.Serializable]
public class _Muscle
{
    public Rigidbody2D boneBody;

    public float restRotation;

    public float force = 150;

    public void ActivateMuscle()
    {
        boneBody.MoveRotation(Mathf.LerpAngle(boneBody.rotation, restRotation, force * Time.deltaTime));
    }
}
