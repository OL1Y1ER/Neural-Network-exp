/****************************************************************
NEURAL NETWORK
This code is ment to be a library... it is clearly not done.

Those are the following functions it will have:
-Creating a neural network
-Training Neural network
-Saving " "
-Loading " "


@author Olivier
@version 0
****************************************************************/

using System;


class NeuralNetwork
{
    // Initializing variables
    int layers;
    float[][] neurons;    // Two-dimensional matrix
    float[][][] weights; // Three-dimensional matrix
    int[] bias;         // Array for all biases 

    // Constructor initializes the Neural Network
    public NeuralNetwork(int layers, int[] layerSize)
    {
        this.layers = layers;
        neurons = new float[this.layers][];       // Adding all the Layers
        weights = new float[this.layers - 1][][]; // Structuring the weights matrix (Input Layer doesn't have incoming weights)
        int biasLength = 0;

        for (int i = 0; i < this.layers; i++)
        {
            neurons[i] = new float[layerSize[i]]; // Adding all the Neurons in each layer
            biasLength += layerSize[i];

            if (i != 0)
            {
                weights[i - 1] = new float[layerSize[i]][];
                for (int j = 0; j < layerSize[i]; j++)
                {
                    weights[i - 1][j] = new float[layerSize[i - 1]]; // Adding all the weights to all the neurons
                }
            }
        }

        bias = new int[biasLength - layerSize[0]]; // Initializing the biases
    }

    // Predicts an Output by calculating all neurons together
    public float[] Prediction(float[] inputs)
    {
        int biasIndex = 0;
        neurons[0] = inputs; // Adding inputs to the input layer

        for (int i = 1; i < layers; i++)
        {
            for (int j = 0; j < neurons[i].Length; j++)
            {
                // neurons[i][j] = 0; // Initialize neuron value
                for (int k = 0; k < weights[i - 1][j].Length; k++)
                {
                    neurons[i][j] += neurons[i - 1][k] * weights[i - 1][j][k];
                }
                neurons[i][j] += bias[biasIndex];
                biasIndex++;
            }
        }

        return neurons[neurons.Length - 1];
    }


    // Activation function to make the neural network not linear and able to do more complex things
    private float ActivationFunction(float prediction)
    {
        return (1 / (1 + (float)Math.Exp(-prediction)));
    }



    // Random has to be changed if used in Unity
    public void GiveRandomNumbers()
    {
        Random randomNumber = new Random();
        for (int i = 0; i < bias.Length; i++)
        {
            bias[i] = randomNumber.Next(-0.1, 0.1);
        }

        for (int i = 0; i < weights.Length; i++)
        {
            for (int j = 0; j < weights[i].Length; j++)
            {
                for (int k = 0; k < weights[i][j].Length; k++)
                {
                    weights[i][j][k] = randomNumber.Next(-0.1, 0.1);
                }
            }
        }
    }

    // Calculate the Loss of the predicted Output and correct Output 
    private float Loss(float[] predictedOutput, float[] correctOutput)
    {
        float diff = 0;
        for (int i = 0; i < predictedOutput.Length; i++)
        {
            diff += (correctOutput[i] - predictedOutput[i]) * (predictedOutput[i] - correctOutput[i]);
        }
        return (diff / predictedOutput.Length);
    }

    // Algorithm to update biases and weights
    private void TrainingAlgorithm(float trainingInput, float correctOutput)
    {
        // I will try to implement a BackPropagation algorithm
    }

    // Just to make it cleaner: here comes Training Data in and Neural Network trains...
    private void TrainingLoop(float[][] trainingData)
    {
        for (int i = 0; i < trainingData[0].Length; i++)
        {
            TrainingAlgorithm(trainingData[0][i], trainingData[1][i]); // Looping through all the trainingData and Training the Neural Network
        }
    }

    // Evaluates how good the neural Network performed based on a new data set
    public float Evaluation(float[][] testingDataSet) // testingDataSet is a two-dimensional matrix, where one row is for the input and the other row is the correct prediction
    {
        float[] predictions = new float[testingDataSet[0].Length]; // Initialize predictions array
        float evaluation = 0;
        predictions = Prediction(testingDataSet[0]); // predicting the testingDataSet

        for (int i = 0; i < predictions.Length; i++)
        {
            if (Math.Abs(predictions[i] - testingDataSet[1][i]) < 0.0001) // checking if the predicted data is close to the correct answer
            {
                evaluation++; // If predictions are correct, add credit
            }
        }
        evaluation = (evaluation / predictions.Length) * 100; // changing evaluation into percentage for better visualization of the performance
        return evaluation;
    }

    // Saves the values of biases and weights
    public void SaveNeuralNetwork(float[][][] weights, float[] bais)
    {
        //Todo: Put code here for saving
        string weightsFile = "";
        string baisFile = "";

        foreach (float f in bais)
        {
            baisFile += f.ToString() + "|";
        }

        //! NOT TESTED
        for (int i = 0; i < weights.Length; i++)
        {
            for (int j = 0; j < weights[i].Length; j++)
            {
                for (int k = 0; k < weights[i][j].Length; k++)
                {
                    weightsFile += weights[i][j][k].ToString() + "|";
                }
            }
        }

        //Todo: save it somwhere
    }

    public void LoadNeuralNetwork(float[][][] weights, float[] bais, float[][] neurons) // Sets defined values for weights and bais
    {
        this.weights = weights;
        this.bias = bais;
        this.neurons = neurons;
    }
}
