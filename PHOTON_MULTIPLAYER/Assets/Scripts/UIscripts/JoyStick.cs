using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoyStick : MonoBehaviourPun, IPunObservable
{
    protected Joystick joystick;
    public PhotonView pv;
    private Vector3 smoothMove;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    /*void Movement()
    {
        
       
            var rigidbody = GetComponent<Rigidbody>();

            rigidbody.velocity = new Vector3(joystick.Horizontal * 10f, rigidbody.velocity.y, joystick.Vertical * 10f);
        
    }*/

    // Update is called once per frame
    void Update()
    {

        
        if (photonView.IsMine) // check kung local player tayo
        {
            ProcessInputs();
        }
        else
        {
            smoothMovement();
        }
    }

    private void smoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
    }

    private void ProcessInputs() // maaapply sa lahat ng player itong method na to so need natin icheck kung local player tayo
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f, rigidbody.velocity.y, joystick.Vertical * 10f);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) // need natin to para mareceive natin yung position ng ibang players through the network and vice versa
    { // magte-take to ng 2 parameters. yung una yung STREAM. yan yung sinesend na data from and to us.
        // yung pangalawa yung info. literally info lang

        if (stream.IsWriting) // kapag gumagalaw tayo, meaning we are writing streams
        {
            stream.SendNext(transform.position); // actually send yung current position natin sa lahat ng players
        }
        else if (stream.IsReading) // kapag gumagalaw yung ibang players, we are reading streams
        {
            smoothMove = (Vector3)stream.ReceiveNext(); // receive lahat ng positions ng lahat ng players. maiistore to sa smoothMove variable
        }
        
    }
}
