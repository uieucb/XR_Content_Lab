using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Linq;
using System;

public class OnnxInference : MonoBehaviour
{
    Tensor<float> t1, t2;
    //float[] sourceData;  // assume your data is loaded into a flat float array
    //int[] dimensions;    // and the dimensions of the input is stored here
    // Start is called before the first frame update
    static float width = 8.0f;
    static float height = 8.0f;

    float[] sourceData = { width, height };
    int[] dimensions = { 1, 2 };

    private float[,] matriz;
    //var denseTensor = new DenseTensor<int>(new[] { 3, 5 });
    void Start()
    {
       // t1= new DenseTensor<float>(new[] { 4, 8 });
        
    
       /* t1= new DenseTensor<float>(new[] {2,8});
        //matriz=new float[1,8];
        for (int i = 1; i<= 1; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    t1[i, j] = 2.3f;
                }
            }
        print(t1);

        for (int i = 1; i<= 1; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    print(t1[i, j]);
                }
            }
        

        //t1 = new DenseTensor<float>(sourceData, dimensions);
        t2 = new DenseTensor<float>(sourceData, dimensions);
        //Tensor<float> t1 = new DenseTensor<float>(sourceData, dimensions);
        string path = "Assets/Karen/Models/knn_test.onnx";
        var session = new InferenceSession(path);
        var inputs = new List<NamedOnnxValue>()
                {
                    NamedOnnxValue.CreateFromTensor<float>("float_input", t1)
                };
        using (var results = session.Run(inputs))
        {
            foreach (var r in results) {
            if(r.Name == "output_label") {
                print($"{r.Name}");
                print(r);
                print(r.AsTensor<float>().ToDenseTensor().Buffer.ToArray());
                print($"{r.AsTensor<float>().GetValue(0)}");
                
            }
            print("entre aqui");
        }
        }*/
        string path = "Assets/Karen/Models/knn_test.onnx";
        InferenceSession session = new InferenceSession(path);
        DenseTensor<float> T1;

        float[,] Predict_input = new float[2, 8];
        Predict_input[0, 0] = 6.0f;
        Predict_input[0, 1] = 148.0f;
        Predict_input[0, 2] = 72.0f;
        Predict_input[0, 3] = 35.0f;
        Predict_input[0, 4] = 0.0f;
        Predict_input[0, 5] = 33.6f;
        Predict_input[0, 6] = 0.627f;
        Predict_input[0, 7] = 50.0f;

        Predict_input[1, 0] = 0.0f;
        Predict_input[1, 1] = 0.0f;
        Predict_input[1, 2] = 0.0f;
        Predict_input[1, 3] = 0.0f;
        Predict_input[1, 4] = 0.0f;
        Predict_input[1, 5] = 0.6f;
        Predict_input[1, 6] = 0.627f;
        Predict_input[1, 7] = 0.0f;


        T1 = Predict_input.ToTensor();
        var inputMeta = session.InputMetadata;
        var outputMeta = session.OutputMetadata;

        var inputs1 = new List<NamedOnnxValue>();

        foreach (var name in inputMeta.Keys)
        {
          inputs1.Add(NamedOnnxValue.CreateFromTensor<float>(name, T1));
        }
        try
        {
            //IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<string> desiredOutputNodes);
            var results = session.Run(inputs1); //IDisposableReadOnlyCollection<DisposableNamedOnnxValue> 
            // dump the results
            var inferenceResult = results.ToList()[0];
            var inferenceResult_Value = inferenceResult.Value;
            var Output = session.Run(inputs1).ToList().First().AsEnumerable<NamedOnnxValue>();
            //debo cambiar el segundo para cambiar el valor de salida
            var Test = results.ToList()[0].AsTensor<long>().ToArray<long>()[0].ToString();
            print(Test);
        }catch (Exception e){
            print("error"+e);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
