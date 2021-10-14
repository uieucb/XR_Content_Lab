using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmode : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetButtonDown("Fire1")){
            GameObject bulletObject=Instantiate(bulletPrefab);
            bulletObject.transform.position=playerCamera.transform.position+playerCamera.transform.forward;
            bulletObject.transform.forward=playerCamera.transform.forward;
  
        }
      /*  if(Input.GetMouseButtonDown(0)){
        }*/
        
    }
}
