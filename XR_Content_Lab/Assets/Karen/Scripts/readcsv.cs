using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class readcsv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile();
    }

    void ReadCSVFile(){
        StreamReader strReader=new StreamReader("C:\\Users\\asus\\Documents\\Excel\\pruebaa.csv");
        bool endOfFile=false;
        while(!endOfFile)
        {
            string data_String=strReader.ReadLine();
            if(data_String==null){
                endOfFile=true;
                break;
            }
            var data_values=data_String.Split(',');
            for(int o=0;o<data_values.Length;o++){
                Debug.Log("Value:"+o.ToString()+" "+data_values[0].ToString());

            }

        }
      //  strReader.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
