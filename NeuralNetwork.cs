class NeuralNetwork
{
    //Initilaizing variables
    int layers;

    public float[][] neurons;    //two demensional matrix
    public float[][][] weigths; //three demesnional matrix
                                //public float[] bais;


    //Constructer 
    public NeuralNetwork(int layers, int[] layerSize)
    {
        this.layers = layers;
        neurons = new float[this.layers][];       // Adding all the Layers
        weigths = new float[this.layers - 1][][];//Strucuring the weights matrix (Input Layer doesnt have incomming weights)


        for (int i = 0; i < this.layers; i++)
        {
            neurons[i] = new float[layerSize[i]]; //  Adding all the Neurons in each layer


            if (i != 0)
            {
                for (int j = 0; j < layerSize[i]; j++)
                {
                    weigths[j][layerSize[i]] = new float[layerSize[i - 1]]; // Adding all the weigths to all the neurons
                }
            }

            /*
            if (i != 0)
            {
                weigths[i-1][layerSize[i]] = new float[layerSize[i - 1]];
                
            }
            */

        }


    }
}