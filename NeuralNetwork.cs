class NeuralNetwork
{
    // Initializing variables
    int layers;

    public float[][] neurons;    // two-dimensional matrix
    public float[][][] weights;  // three-dimensional matrix
    public int[] biases;

    // Constructor 
    public NeuralNetwork(int layers, int[] layerSize)
    {
        this.layers = layers;
        neurons = new float[this.layers][];       // Adding all the Layers
        weights = new float[this.layers - 1][][]; // Structuring the weights matrix (Input Layer doesn't have incoming weights)
        int basisLength = 0;

        for (int i = 0; i < this.layers; i++)
        {
            neurons[i] = new float[layerSize[i]]; // Adding all the Neurons in each layer
            basisLength += layerSize[i];

            if (i != 0)
            {
                weights[i - 1] = new float[layerSize[i]][];
                for (int j = 0; j < layerSize[i]; j++)
                {
                    weights[i - 1][j] = new float[layerSize[i - 1]]; // Adding all the weights to all the neurons
                }
            }
        }

        biases = new int[basisLength - layerSize[0]];
    }
}
