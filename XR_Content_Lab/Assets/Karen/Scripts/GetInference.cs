using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Barracuda;



public class GetInference : MonoBehaviour
{
    //Input
    public Texture2D texture;

    //como lo hacemos
    public NNModel modelAsset;
    private Model _runtimeModel;
    private IWorker _engine;

    /*se serializara para lograr verla en el editor*/
    [System.Serializable]
    public struct Prediction
    {
        /*el valor predicho*/
        public int predictedValue;
        public float[] predicted;
        public void SetPrediction(Tensor t){
            predicted=t.AsFloats();
            predictedValue = System.Array.IndexOf(predicted,predicted.Max());
            Debug.Log($"Predicted {predictedValue}");
            print($"Predicted {predictedValue}");
        
        }
    }

    public Prediction prediction;

    // Start is called before the first frame update
    void Start()
    {
        _runtimeModel=ModelLoader.Load(modelAsset);
        _engine=WorkerFactory.CreateWorker(_runtimeModel,WorkerFactory.Device.GPU);
        prediction=new Prediction();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            //making a tensor out of a grayscale texture
            var channelCount= 1;
            var inputX=new Tensor(texture,channelCount);

            Tensor outputY=_engine.Execute(inputX).PeekOutput();
            inputX.Dispose();
            prediction.SetPrediction(outputY);
        }
    }
    private void OnDestroy(){
        _engine?.Dispose();
    }
    
}
