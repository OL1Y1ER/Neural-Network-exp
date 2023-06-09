class NeuralNetwork
{
    //Initilaizing variables
    int layers;

    float[][] neurons;    //two demensional matrix
    float[][][] weigths; //three demesnional matrix
    int[] bais;         // array for all bais 



    //Constructer Initializes the Neural Network
    public NeuralNetwork(int layers, int[] layerSize)
    {
        this.layers = layers;
        neurons = new float[this.layers][];       // Adding all the Layers
        weigths = new float[this.layers - 1][][];//Strucuring the weights matrix (Input Layer doesnt have incomming weights)
        int basisLength = 0;

        for (int i = 0; i < this.layers; i++)
        {
            neurons[i] = new float[layerSize[i]]; //  Adding all the Neurons in each layer
            basisLength += layerSize[i];

            if (i != 0)
            {
                weigths[i - 1] = new float[layerSize[i]][];
                for (int j = 0; j < layerSize[i]; j++)
                {
                    weigths[i - 1][j] = new float[layerSize[i - 1]]; // Adding all the weigths to all the neurons


                }
            }
        }

        bais = new int[basisLength - layerSize[0]];

    }




    public float[] Prediction(float[] inputs)

    {
        int baisIndex = 0;

        neurons[0] = inputs;//adding inputs to InputLayer

        for (int i = 1; i < layers; i++)
        {
            for (int j = 0; j < neurons[i].Length; j++)
            {
                //neurons[i][j] = 0; // Initialize neuron value
                for (int k = 0; k < weigths[i - 1][j].Length; k++)
                {
                    neurons[i][j] += neurons[i - 1][k] * weigths[i - 1][j][k];

                }
                neurons[i][j] += bais[baisIndex];
                baisIndex++;
            }
        }

        return neurons[neurons.Length - 1];
    }


    public void GiveRandomNumbers()
    {
        Random randomNumber = new Random();
        for (int i = 0; i < bais.Length; i++)
        {
            bais[i] = randomNumber.Next(-25, 25);
        }

        for (int i = 0; i < weigths.Length; i++)
        {
            for (int j = 0; j < weigths[i].Length; j++)
            {
                for (int k = 0; k < weigths[i][j].Length; k++)
                {
                    weigths[i][j][k] = randomNumber.Next(-25, 25);

                }
            }
        }

    }


}
