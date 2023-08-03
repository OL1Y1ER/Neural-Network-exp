/****************************************************************
NEURAL NETWORK
This code is ment to be a library... it is clearly not done.

@author Olivier
@version 1.0
****************************************************************/

using System;
using System.IO;

class NeuralNetwork
{
    // Initializing variables
    int layers;
    double[][] neurons;    // Two-dimensional matrix
    double[][][] weights; // Three-dimensional matrix
    double[] bias;         // Array for all biases 

    // Constructor initializes the Neural Network
    public NeuralNetwork(int layers, int[] layerSize)
    {
        this.layers = layers;
        neurons = new double[this.layers][];       // Adding all the Layers
        weights = new double[this.layers - 1][][]; // Structuring the weights matrix (Input Layer doesn't have incoming weights)
        int biasLength = 0;

        for (int i = 0; i < this.layers; i++)
        {
            neurons[i] = new double[layerSize[i]]; // Adding all the Neurons in each layer
            biasLength += layerSize[i];

            if (i != 0)
            {
                weights[i - 1] = new double[layerSize[i]][];
                for (int j = 0; j < layerSize[i]; j++)
                {
                    weights[i - 1][j] = new double[layerSize[i - 1]]; // Adding all the weights to all the neurons
                }
            }
        }

        bias = new double[biasLength - layerSize[0]]; // Initializing the biases
    }

    // Predicts an Output by calculating all neurons together
    public double[] Prediction(double[] inputs)
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
    private float ActivationFunction(float prediction, string name)
    {
        float activation = 0;
        switch (name)
        {
            case ("Tariff"):
                activation = (1 / (1 + (float)Math.Exp(-prediction)));
                break;

            case ("Binary step"):
                if (prediction < 0)
                {
                    activation = 0;
                }
                else if (prediction >= 0)
                {
                    activation = 1;
                }
                break;

            case ("Identity"):
                activation = prediction;
                break;

        }
        return (activation);




    }

    private double RandomDouble(double min, double max)
    {
        Random R = new Random();
        double d = R.NextDouble();
        return d * (max - min) + min;
    }

    /*
    private double RandomDouble(double min, double max)// Make Random doubles work
    {
        Random R = new Random();
        double d = R.NextDouble();

        double randomDouble = Math.Round((d * (max - min) + min) * 10) / 10;
        return randomDouble;
    }
    */


    // Random has to be changed if used in Unity
    public void GiveRandomNumbers()
    {

        for (int i = 0; i < bias.Length; i++)
        {
            bias[i] = RandomDouble(-0.1, 0.1);
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
        //Todo: I will try to implement a BackPropagation algorithm
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
    public double Evaluation(double[][] testingDataSet) // testingDataSet is a two-dimensional matrix, where one row is for the input and the other row is the correct prediction
    {
        double[] predictions = new double[testingDataSet[0].Length]; // Initialize predictions array
        double evaluation = 0;
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
    public void SaveNeuralNetwork(float[][][] weights, float[] bais, string filePath)
    {
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

        File.WriteAllText(filePath, weightsFile + "§" + baisFile);
    }

    public void LoadNeuralNetwork(double[][][] weights, double[] bais, double[][] neurons) // Sets defined values for weights and bais, should be used instead of "GiveRandomNumbers"
    {
        this.weights = weights;
        this.bias = bais;
        this.neurons = neurons;
    }
}
