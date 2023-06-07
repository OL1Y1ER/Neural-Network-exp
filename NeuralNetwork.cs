
// Should be helpful
class Neuron
{
    // Liste of Weights (one for each Neuron in the next Layer) 
    
    // Methods
    // 1. Constructor
    // 2. Receiving input
    // 3. Computing output to one Neuron
    // 4. Sending output to all the Neurons in the following Layer
}

// Helpful?
class Layer 
{
    // List of Neurons
}

class NeuralNetwork
    {
        //Initializing variables
        int numberOfLayers;

        float[][] neurons;    //two dimensional matrix
        float[][][] weigths; //three dimensional matrix
        


        //Constructer 
        public NeuralNetwork(int numberOfLayers, int[] layerSize) 
        {
            this.numberOfLayers = numberOfLayers;
            neurons = new float[this.numberOfLayers][];       // Adding all the Layers
            weigths = new float[this.numberOfLayers - 1][][];//Strucuring the weights matrix (Input Layer doesnt have incomming weights)

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
