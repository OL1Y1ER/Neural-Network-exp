using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualization_NeuralNetworks
{

    class NeuronNetwork
    {
        private int iNeurons;
        private int[] hLayer;
        private int oNeurons;
        List<PictureBox> inputs;
        List<PictureBox> hidden;
        List<PictureBox> output;
        public NeuronNetwork(int inputNeurons,int[] neuronsInHL, int outputNeurons, List<PictureBox> inputs, List<PictureBox> hidden, List<PictureBox> output) {
            this.iNeurons = inputNeurons;
            this.hLayer = neuronsInHL;
            this.oNeurons = outputNeurons;

            this.inputs = inputs;
            this.hidden = hidden;
            this.output = output;
        
        }

        public void SetInputLayer()
        {
            

            int y =  200;
            int x = 50;

            for(int i = 0; i < iNeurons; i++)
            {
                if(i % 2 == 0)
                {
                    inputs[i].Location = new Point(x, y);
                    y = y - 50;
                }
                else
                {
                    inputs[i].Location = new Point(x, y);
                    y = y + 50;
                }
                
            }

        }


    }
    public partial class Form1 : Form
    {
        List<PictureBox> inputs = new List<PictureBox>();
        List<PictureBox> hidden = new List<PictureBox>();
        List<PictureBox> output = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            //This code runs before the window initializes

            PictureBox[] inputConverter = { I1, I2, I3, I4, I5 };
            inputs = inputConverter.ToList();//Seting up Input Layer in a List

            PictureBox[] hiddenConverter = { h1, h2, h3, h4, h5, h6, h7, h8, h9, h10 };
            hidden = hiddenConverter.ToList(); //Seting up Hidden Layer in a List




        }

        private void createNeuralNetwork_Click(object sender, EventArgs e)
        {   /*
            ResetAllLayers();
            InitilizeInputLayer(int.Parse(Input_inputNeurons.Text));//Ceate viual Neural Network
            //int[] hiddenLayersAmount = { 2, 2};
            InitializeHiddenLayyer(int.Parse(Input_hiddenLayer.Text));
            */
            int[] hiddenas = { 2,1};
            NeuronNetwork n = new NeuronNetwork(3, hiddenas, 3,inputs, hidden, output);
            n.SetInputLayer();
        }


        /*
        void ResetAllLayers()
        {
            foreach (PictureBox p in inputs) { 
                p.Location = new Point( 2000, 2000); // Input

            }
            foreach (PictureBox p in hidden)
            {
                p.Location = new Point(2000, 2000); // Hidden

            }
        }


        void InitilizeInputLayer(int amountOfNeurons)
        {
            const int xPosition = 50;
            int yPosition =  50 * (inputs.Count / amountOfNeurons);

            for(int i = 0; i < amountOfNeurons; i++)
            {
                inputs[i].Location = new Point(xPosition, yPosition);
                yPosition += 50;
            }
        }
        void InitializeHiddenLayyer(int amountOfNeurons)
        {
            

            int xPosition = 50 +  200;
            int yPosition = 50 * (inputs.Count / amountOfNeurons);

            for (int j = 0; j < amountOfNeurons; j++)
            {
                hidden[j].Location = new Point(xPosition, yPosition);
                yPosition += 50;
            }


        }
        */
            
    }
}
