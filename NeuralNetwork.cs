

class NeuralNetwork
    {
        //Initilaizing variables
        int layers;

        float[][] neurons;    //two demensional matrix
        float[][][] weigths; //three demesnional matrix
        


        //Constructer 
        public NeuralNetwork(int layers, int[] layerSize)
        {
            this.layers = layers;
            neurons = new float[this.layers][];       // Adding all the Layers
            weigths = new float[this.layers - 1][][];//Strucuring the weights matrix (Input Layer doesnt have incomming weights)

            for (int i = 0;  i < this.layers; i++)
            {
                neurons[i] = new float[layerSize[i]]; //  Adding all the Neurons in each layer
                /*Curently working on because it is wrong
                if(i != 0)
                {
                    weigths[i] = new float[layerSize[i]][layerSize[i-1]];
                }
                */
            }
        }
        

         

    }