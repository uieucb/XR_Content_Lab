using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

public class OnnxInference : MonoBehaviour
{
    Tensor<float> t1, t2;
    float[] sourceData;  // assume your data is loaded into a flat float array
    int[] dimensions;    // and the dimensions of the input is stored here
    // Start is called before the first frame update
    void Start()
    {
        
        //Tensor<float> t1 = new DenseTensor<float>(sourceData, dimensions);
        string path = "Assets/Karen/Models/knn_test.onnx";
        var session = new InferenceSession(path);
        var inputs = new List<NamedOnnxValue>()
                {
                    NamedOnnxValue.CreateFromTensor<float>("name1", t1),
                    NamedOnnxValue.CreateFromTensor<float>("name2", t2)
                };
        using (var results = session.Run(inputs))
        {
            print(results);
            // manipulate the results
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
