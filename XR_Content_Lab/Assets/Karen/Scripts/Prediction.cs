using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Prediction : MonoBehaviour
{/*
    // Start is called before the first frame update
    void Start()
    {
        const string imagePath = @"C:\Users\asus\Downloads\mnist_test_one_1.png";
            float[][] image = PreprocessTestImage(imagePath);

            const string modelPath = @"C:\Users\asus\Downloads\mnist-model.onnx";
            float[] probabilities = Predict(modelPath, image);
            // The predicted number is the index of the largest value(probability) in the array.
            int prediction = probabilities.ToList().IndexOf(probabilities.Max());

            print($"Predicted number: {prediction}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private static float[][] PreprocessTestImage(string path)
        {
            var img = new Bitmap(path);
            var result = new float[img.Width][];

            for (int i = 0; i < img.Width; i++)
            {
                result[i] = new float[img.Height];
                for (int j = 0; j < img.Height; j++)
                {
                    var pixel = img.GetPixel(i, j);

                    var gray = RgbToGray(pixel);

                    // Normalize the Gray value to 0-1 range
                    var normalized = gray / 255;

                    result[i][j] = normalized;
                }
            }
            return result;
        }
        private static float RgbToGray(Color pixel) => 0.299f * pixel.R + 0.587f * pixel.G + 0.114f * pixel.B;
        
        private static float[] Predict(string modelPath, float[][] image)
        {
            using var session = new InferenceSession(modelPath);
            var modelInputLayerName = session.InputMetadata.Keys.Single();

            var imageFlattened = image.SelectMany(x => x).ToArray();
            int[] dimensions = { 1, 28, 28 };
            var inputTensor = new DenseTensor<float>(imageFlattened, dimensions);
            var modelInput = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor(modelInputLayerName, inputTensor)
            };

            var result = session.Run(modelInput);
            return ((DenseTensor<float>)result.Single().Value).ToArray();
        }*/
}
