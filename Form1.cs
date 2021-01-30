using MultiscaleModelling.Interfaces;
using MultiscaleModelling.Models;
using MultiscaleModelling.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiscaleModelling
{
    public partial class Form1 : Form
    {
        private ISimulation _currentSimullation;
        private bool _isStartedSimulation;
        public Form1()
        {
            InitializeComponent();

            comboBoxBC.SelectedIndex = 0;
            comboBoxNeighbourhood.SelectedIndex = 1;
            comboBoxTypeOfInclusion.SelectedIndex = 0;
            comboBoxStructureType.SelectedIndex = 0;
            comboBoxNucleationType.SelectedIndex = 0;
            _isStartedSimulation = false;

            _currentSimullation = new StandardSimulation();
            ChangeEnableGrowOptions(true);
            ChangeEnableGrowButtons(true);
            ChangeEnableInclusionsOptions(true);
            ChangeEnableSubstructure(false);

            exportToolStripMenuItem.Enabled = false;
            radioButtonAC.Select();
            radioButtonGB.Select();
        }

        private Configuration GetConfiguration()
        {

            return new Configuration()
            {
                Width = (int)numericUpDownWidth.Value,
                Height = (int)numericUpDownHeight.Value,
                BoundaryConditions = (BCEnum)comboBoxBC.SelectedIndex,
                Neighbourhood = (NeighbourhoodEnum)comboBoxNeighbourhood.SelectedIndex,
                NumberOfGrains = (int)numericUpDownNumberOfGrain.Value,
                MooreProbability = (int)numericMooreProbability.Value,
                StructureTypeEnume = (StructureTypeEnume)comboBoxStructureType.SelectedIndex,
                NumberOfSubGrains = (int)numericUpDownSubGrainsNum.Value,
                SizeOfGB = (int)numericUpDownGBSize.Value,
                IsMC = radioButtonMC.Checked,
                J = (double)numericUpDownJ.Value,
                MCIterations = (int)numericUpDownMCIterations.Value,
                ConfigurationRecrystallization = new ConfigurationRecrystallization()
                {
                    Iterations = (int)numericUpDownRecIterations.Value,
                    J = (double)numericUpDownJ.Value,
                    NucleonsType=(NucleonsType)comboBoxNucleationType.SelectedIndex,
                    NumberOfStates=(int)numericUpDownRecrStates.Value,
                    OnlyGBGeneration = radioButtonGB.Checked,
                    TotalNucleons = (int)numericUpDownTotalNucleons.Value
                },
                BorderEnergy = 7,
                GrainEnergy = 2
            };
        }

        private ConfigurationInclusions GetConfigurationInclusions()
        {

            return new ConfigurationInclusions()
            {
                InclusionType = (InclusionType)comboBoxTypeOfInclusion.SelectedIndex,
                NumberOfInclusions = (int)numericAmountOfInclusions.Value,
                SizeOfInclusions = (int)numericSizeOfInclusions.Value
            };
        }

        private void StartStandatdSimulation()
        {
            ChangeEnableGrowOptions(false);
            ChangeEnableInclusionsOptions(false);
            ChangeEnableSubstructure(false);

            var config = GetConfiguration();

            _currentSimullation.Initialize(config);
            _currentSimullation.InitializeStep();


            _isStartedSimulation = true;
        }
        private void Render(Bitmap map)
        {
            if (map != null)
                pictureBox1.Image = ResizeBitmap(map, pictureBox1.Width, pictureBox1.Height);
        }

        private void RenderStep()
        {
            var map = _currentSimullation.GetBitmap();
            Render(map);
        }
        private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            }
            return result;
        }

        private void ChangeEnableGrowOptions(bool enable)
        {
            numericUpDownWidth.Enabled = enable;
            numericUpDownHeight.Enabled = enable;
            numericUpDownNumberOfGrain.Enabled = enable;
            comboBoxNeighbourhood.Enabled = enable;
            comboBoxBC.Enabled = enable;
            numericMooreProbability.Enabled = enable;
            numericUpDownMCIterations.Enabled = enable;
            numericUpDownJ.Enabled = enable;
        }
        private void ChangeEnableInclusionsOptions(bool enable)
        {
            numericAmountOfInclusions.Enabled = enable;
            numericSizeOfInclusions.Enabled = enable;
            comboBoxTypeOfInclusion.Enabled = enable;
            buttonAddInclusions.Enabled = enable;
        }
        private void ChangeEnableGrowButtons(bool enable)
        {
            buttonStart.Enabled = enable;
            buttonStop.Enabled = enable;
        }
        private void ChangeEnableSubstructure(bool enable)
        {
            comboBoxStructureType.Enabled = enable;
            numericUpDownSubGrainsNum.Enabled = enable;
            buttonSelectGrains.Enabled = enable;
            buttonGenerate.Enabled = enable;

            _grainsSelection = false;
            timer2.Enabled = false;

            numericUpDownGBSize.Enabled = enable;
            buttonGenerateGB.Enabled = enable;
            buttonRemoveColors.Enabled = enable;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ChangeEnableSubstructure(false);
            if (!_isStartedSimulation)
            {
                StartStandatdSimulation();
            }
            timer1.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            _currentSimullation.Restart();
            RenderStep();
            _isStartedSimulation = false;
            timer1.Enabled = false;
            exportToolStripMenuItem.Enabled = false;

            ChangeEnableInclusionsOptions(true);
            ChangeEnableGrowOptions(true);
            ChangeEnableGrowButtons(true);
            ChangeEnableSubstructure(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _currentSimullation.NextStep();
            RenderStep();
            if (_currentSimullation.IsEndSimulation())
            {
                ChangeEnableGrowButtons(false);
                ChangeEnableInclusionsOptions(true);
                ChangeEnableSubstructure(true);
                exportToolStripMenuItem.Enabled = true;
                timer1.Enabled = false;
            }
        }


        private void comboBoxBC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxNeighbourhood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void importToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Structure Files (*.bmp, *.txt)|*.bmp; *.txt";
            openFileDialog1.Title = "Select a structure file";


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var name = openFileDialog1.FileName;

                if (name.Contains(".txt"))
                    _currentSimullation.ImportFromFile(FileTypeEnum.Text, name);
                else if (name.Contains(".bmp"))
                    _currentSimullation.ImportFromFile(FileTypeEnum.Bmp, name);

                _isStartedSimulation = true;
                RenderStep();

                ChangeEnableGrowOptions(false);
                ChangeEnableGrowButtons(false);
                ChangeEnableInclusionsOptions(true);
                ChangeEnableSubstructure(true);
                exportToolStripMenuItem.Enabled = true;

                var config = _currentSimullation.GetConfiguration();
                numericUpDownWidth.Value = config.Width;
                numericUpDownHeight.Value = config.Height;
                numericUpDownNumberOfGrain.Value = config.NumberOfGrains;
            }
        }

        private void toTextToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileGialog = new SaveFileDialog();
            saveFileGialog.Filter = "Structure Files (*.txt)|*.txt";
            saveFileGialog.Title = "Select path for file";


            if (saveFileGialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var name = saveFileGialog.FileName;
                _currentSimullation.ExportToFile(FileTypeEnum.Text, name);

            }
        }

        private void toBitmapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileGialog = new SaveFileDialog();
            saveFileGialog.Filter = "Structure Files (*.bmp)|*.bmp";
            saveFileGialog.Title = "Select path for file";


            if (saveFileGialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var name = saveFileGialog.FileName;
                _currentSimullation.ExportToFile(FileTypeEnum.Bmp, name);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentSimullation.IsMapEmpty())
            {
                var globalConfig = GetConfiguration();
                _currentSimullation.Initialize(globalConfig);
            }
            var config = GetConfigurationInclusions();
            _currentSimullation.AddInclusions(config);
            RenderStep();
        }

        private bool _grainsSelection = false;
        private void buttonSelectGrains_Click(object sender, EventArgs e)
        {
            _currentSimullation.RestartSelectedList();
            _grainsSelection = true;
            timer2.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(_grainsSelection == true)
            {
                var mouseEvent = (MouseEventArgs)e;
                double imageX = mouseEvent.X;
                double imageY = mouseEvent.Y;

                double imageWidth = pictureBox1.Width;
                double imageHeight = pictureBox1.Height;

                var map = _currentSimullation.GetBitmap();

                double mapWidth = map.Width;
                double mapHeight = map.Height;


                int x = (int)(imageX / imageWidth * mapWidth);
                int y = (int)(imageY / imageHeight * mapHeight);

                _currentSimullation.AddOrRemoveGrainsToSelectLis(x,y);


            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var config = GetConfiguration();
            _isStartedSimulation = true;
            _grainsSelection = false;
            timer2.Enabled = false;

            _currentSimullation.StartGenerateSubstructure(config);
            _currentSimullation.InitializeStep();

            ChangeEnableGrowButtons(true);
            RenderStep();
        }

        private bool _visFlag = false;
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (_grainsSelection)
            {
                var map = _currentSimullation.GetBitmapGrainsSelection(_visFlag);
                Render(map);
                _visFlag = !_visFlag;
            }
        }

        private void buttonGenerateGB_Click(object sender, EventArgs e)
        {
            var config = GetConfiguration();
            _currentSimullation.AddBoundariesForGrains(config);
            RenderStep();

            labelGBPer.Text = _currentSimullation.GetGBPercent().ToString();
        }

        private void buttonRemoveColors_Click(object sender, EventArgs e)
        {
            _currentSimullation.RemoveGrainsColors();
            RenderStep();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxEnergy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnergy.Checked)
            {
                var map = _currentSimullation.GetEnergyBitmap();
                Render(map);
            }
            else
            {
                var map = _currentSimullation.GetBitmap();
                Render(map);
            }
        }

        private void buttonCalculateEnergy_Click(object sender, EventArgs e)
        {
            _currentSimullation.CalculateEnergy();
        }

        private void buttonRecrystallization_Click(object sender, EventArgs e)
        {
            var config = GetConfiguration();
            _isStartedSimulation = true;
            _grainsSelection = false;
            timer2.Enabled = false;

            ChangeEnableGrowButtons(true);
            config.IsRecrystallization = true;

            _currentSimullation.Initialize(config);
            _currentSimullation.InitializeStep();

            RenderStep();
        }

        private void numericUpDownNumberOfGrain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
