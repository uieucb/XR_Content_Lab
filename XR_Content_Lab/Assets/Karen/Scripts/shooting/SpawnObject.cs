using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public GameObject Foodprefab;
    public GameObject medium;
    public GameObject max;
    public float timeRemaining = 6;
    public int numero=1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {

        if(timeRemaining>0){
            timeRemaining -= Time.deltaTime;
        }else{
            timeRemaining = 6;
            numero=Random.Range(1,4);
            if(numero==1){
                SpawnFood();
            }else if(numero==2){
                SpawnFoodmedium();
            }else if(numero==3){
                SpawnFoodmax();
            }
            
        }
       
       // print(timeRemaining);
        //if(Input.GetKey(KeyCode.Q))
           // SpawnFood();
          //  SpawnFoodmax();
          //  SpawnFood();
        
    }

    public void SpawnFood(){
        Vector3 pos=center+new Vector3(Random.Range(-size.x/2, size.x/2),Random.Range(-size.y/2, size.y/2),Random.Range(-size.z/2, size.z/2));
        Instantiate(Foodprefab,pos, Quaternion.identity );
    }
     public void SpawnFoodmedium(){
        Vector3 pos=center+new Vector3(Random.Range(-size.x/2, size.x/2),Random.Range(-size.y/2, size.y/2),Random.Range(-size.z/2, size.z/2));
        Instantiate(max,pos, Quaternion.identity );
    }
     public void SpawnFoodmax(){
        Vector3 pos=center+new Vector3(Random.Range(-size.x/2, size.x/2),Random.Range(-size.y/2, size.y/2),Random.Range(-size.z/2, size.z/2));
        Instantiate(medium,pos, Quaternion.identity );
    }


    void OnDrawGizmosSelected(){
        Gizmos.color=new Color(27,5,0,0.5f);
        Gizmos.DrawCube(center, size);
    }


}
