using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerconfig : MonoBehaviour
{
   public float maxRotationDegreePerSecond=75f;
    public float mouseRotationSpeed=100f;

    [Range(0,45)]
    public float maxPitchUpAngle=45f;

    [Range(0,45)]
    public float maxPitchDownAngle=30f;

    void Start(){
        Cursor.visible = false;
    }
    void Update(){
        MouseInput ();
    }

    private void MouseInput(){
        Vector3 rotation=new Vector3(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"),0);
        RotateView (rotation * mouseRotationSpeed);
    }

    private void RotateView(Vector3 rotation){
        //Rotate player
        transform.Rotate (rotation * Time.deltaTime);

        //Limit player rotation pitch
        float playerPitch=LimitPitch();

        //aply clamped pitch and clear roll
        transform.rotation=Quaternion.Euler (playerPitch,transform.eulerAngles.y,0);

    }

    private float LimitPitch(){
        float playerPitch=transform.eulerAngles.x;

        float maxPitchUp=360-maxPitchUpAngle;
        float maxPitchDown=maxPitchDownAngle;

        if(playerPitch>100 && playerPitch<maxPitchUp){
            //Limit pitch up
            playerPitch=maxPitchUp;
        }else if(playerPitch<100 && playerPitch>maxPitchDown){
            playerPitch=maxPitchDown;
        }
        return playerPitch;
    }
}
