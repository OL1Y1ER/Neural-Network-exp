using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfLayers = { 2, 3, 1 }; 
            NeuralNetwork N = new NeuralNetwork(3, sizeOfLayers);
            N.InitializeWeightsAndBiases();
            double[] inputs = { .2, -.1 };
            double[] Output = N.Prediction(inputs);
            Console.WriteLine(Output[0]);
        }
    }




    class NeuralNetwork
    {
        private int layers;
        private double[][] neurons;
        private double[][][] weights;
        private double[] bias;

        public NeuralNetwork(int layers, int[] layerSize)
        {
            this.layers = layers;
            neurons = new double[this.layers][];
            weights = new double[this.layers - 1][][];
            int biasLength = 0;

            for (int i = 0; i < this.layers; i++)
            {
                neurons[i] = new double[layerSize[i]];
                biasLength += layerSize[i];

                if (i != 0)
                {
                    weights[i - 1] = new double[layerSize[i]][];
                    for (int j = 0; j < layerSize[i]; j++)
                    {
                        weights[i - 1][j] = new double[layerSize[i - 1]];
                    }
                }
            }

            bias = new double[biasLength - layerSize[0]];
        }

        public double[] Prediction(double[] inputs)
        {
            int biasIndex = 0;
            neurons[0] = inputs;

            for (int i = 1; i < layers; i++)
            {
                for (int j = 0; j < neurons[i].Length; j++)
                {
                    for (int k = 0; k < weights[i - 1][j].Length; k++)
                    {
                        neurons[i][j] += neurons[i - 1][k] * weights[i - 1][j][k];
                    }
                    neurons[i][j] = ActivationFunction(neurons[i][j], "Sigmoid");
                    neurons[i][j] += bias[biasIndex];
                    biasIndex++;
                }
            }

            return neurons[neurons.Length - 1];
        }

        private double ActivationFunction(double value, string name)
        {
            switch (name)
            {
                case "Sigmoid":
                    return 1.0 / (1.0 + Math.Exp(-value));

                default:
                    return value;
            }
        }

        private double RandomDouble(double min, double max)
        {
            Random R = new Random();
            double d = R.NextDouble();
            return (d * (max - min) + min);
        }

        public void InitializeWeightsAndBiases()
        {
            for (int i = 0; i < bias.Length; i++)
            {
                bias[i] = 0.1;
            }

            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    for (int k = 0; k < weights[i][j].Length; k++)
                    {
                        weights[i][j][k] = RandomDouble(-1, 1);
                    }
                }
            }
        }

        public void Train(double[][] trainingData, double learningRate, int epochs)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                Shuffle(trainingData);

                foreach (var data in trainingData)
                {
                    double[] input = new double[] { data[0] }; // Wrap input in an array
                    double[] target = new double[] { data[1] }; // Wrap target in an array

                    double[] prediction = Prediction(input);

                    double[] errors = new double[prediction.Length];

                    for (int i = 0; i < prediction.Length; i++)
                    {
                        errors[i] = target[i] - prediction[i];
                    }

                    Backpropagate(errors, learningRate);
                }
            }
        }

        private void Shuffle(double[][] data)
        {
            Random random = new Random();
            int n = data.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var temp = data[k];
                data[k] = data[n];
                data[n] = temp;
            }
        }

        private void Backpropagate(double[] errors, double learningRate)
        {
            for (int layer = layers - 1; layer > 0; layer--)
            {
                for (int neuronIndex = 0; neuronIndex < neurons[layer].Length; neuronIndex++)
                {
                    double gradient = errors[neuronIndex] * ActivationDerivative(neurons[layer][neuronIndex], "Sigmoid");

                    bias[layer - 1] += learningRate * gradient;

                    for (int prevNeuronIndex = 0; prevNeuronIndex < neurons[layer - 1].Length; prevNeuronIndex++)
                    {
                        weights[layer - 1][neuronIndex][prevNeuronIndex] +=
                            learningRate * gradient * neurons[layer - 1][prevNeuronIndex];
                    }
                }
            }
        }

        private double ActivationDerivative(double value, string name)
        {
            switch (name)
            {
                case "Sigmoid":
                    return value * (1 - value);

                default:
                    return 1;
            }
        }

        // Other methods like SaveNeuralNetwork, LoadNeuralNetwork, Evaluation, etc.
    }



}



