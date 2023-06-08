class NeuralNetwork
{
    //Initilaizing variables
    int layers;

    public float[][] neurons;    //two demensional matrix
    public float[][][] weigths; //three demesnional matrix
    public int[] bais;


    //Constructer 
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




}