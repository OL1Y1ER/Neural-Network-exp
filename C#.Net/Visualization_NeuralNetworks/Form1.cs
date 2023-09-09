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
    public partial class Form1 : Form
    {
        List<PictureBox> inputs = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            //This code runs before the window initializes

            PictureBox[] inputConverter = { I1, I2, I3, I4, I5 };
            inputs = inputConverter.ToList();
           
            
            



        }

        private void createNeuralNetwork_Click(object sender, EventArgs e)
        {
            ResetAllLayers();
            InitilizeInputLayer(int.Parse(Input_inputNeurons.Text));
        }

        void ResetAllLayers()
        {
            foreach (PictureBox p in inputs) { 
                p.Location = new Point( 2000, 2000);
            }
        }

        void InitilizeInputLayer(int amountOfNeurons)
        {
            const int xPosition = 50;
            int yPosition = 50;

            for(int i = 0; i < amountOfNeurons; i++)
            {
                inputs[i].Location = new Point(xPosition, yPosition);
                yPosition += 50;
            }
        }
    }
}
