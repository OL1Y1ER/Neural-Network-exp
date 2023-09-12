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
            List<int> neuronsInLayers = new List<int>();

            System.Console.Write("How many Input Neurons? :");
            int inputNeurons = int.Parse(Console.ReadLine());
            
            System.Console.Write("How many Hidden Layers? :");
            int amountOfHidenLayers =int.Parse(Console.ReadLine());

            neuronsInLayers.Add(inputNeurons);
            
            for(int i = 0; i < amountOfHidenLayers; i++){
                System.Console.Write($"How many Neurons in the {i + 1}. Hidden Layyer? :");
                int neuronAmount = int.Parse(Console.ReadLine());
                neuronsInLayers.Add(neuronAmount);
            }

            System.Console.Write("How many Output Neurons? :");
            int outPutNeurons = int.Parse(Console.ReadLine());
            neuronsInLayers.Add(outPutNeurons);

            
            NeuralNetwork N = new NeuralNetwork(neuronsInLayers.Count(), neuronsInLayers.ToArray()); // Create Neural Network
            N.InitializeWeightsAndBiases();
            double[] inputs = new double[neuronsInLayers[0]];
            Console.Clear();
            //Get InputInfo
            for(int i = 0; i < inputs.Length; i++)
            {
                Console.Write($"Give me the {i}. input :");

                inputs[i] = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine("-------------OUTPUT------------------");
            double[] Output = N.Prediction(inputs);
            for(int i = 0; i < Output.Length; i++)
            {
                Console.WriteLine($"{i+1}. Output: {Output[i]}");
            }
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
                    neurons[i][j] = ActivationFunction(neurons[i][j], "F me");
                    neurons[i][j] += bias[biasIndex];
                    biasIndex++;
                }
            }

            return neurons[neurons.Length - 1];//Why do I get same Output?
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
/*should work too cant remember why this is commentes...... fuck
        private double RandomDouble(double min, double max)
        {
            Random R = new Random();
            double d = R.NextDouble();
            return (d * (max - min) + min);
        }

        */

        private double RandomDouble(double min, double max)// Make Random doubles work
        {
            Random R = new Random();
            double d = R.NextDouble();

            double randomDouble = Math.Round((d * (max - min) + min) * 100) / 100;
            return randomDouble;
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
    }



}