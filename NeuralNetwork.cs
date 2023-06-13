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
    private float ActivationFunction(int prediction)
    {

    }

    // Random has to be changed if used in Unity
    public void GiveRandomNumbers()
    {
        Random randomNumber = new Random();
        for (int i = 0; i < bias.Length; i++)
        {
            bias[i] = randomNumber.Next(-25, 25);
        }

        for (int i = 0; i < weights.Length; i++)
        {
            for (int j = 0; j < weights[i].Length; j++)
            {
                for (int k = 0; k < weights[i][j].Length; k++)
                {
                    weights[i][j][k] = randomNumber.Next(-25, 25);
                }
            }
        }
    }

    // Calculate the Loss of the predicted Output and correct Output 
    private float Loss()
    {

    }

    // Algorithm to update biases and weights
    private void TrainingAlgorithm()
    {

    }

    // Just to make it cleaner: here comes Training Data in and Neural Network trains...
    private void TrainingLoop()
    {

    }

    // Evaluates how good the neural Network performed based on a new data set
    public float Evaluation()
    {

    }

    // Saves the values of biases and weights
    public void SaveNeuralNetwork()
    {

    }

}
