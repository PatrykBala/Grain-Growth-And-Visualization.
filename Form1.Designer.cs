namespace MultiscaleModelling
{
    partial class Form1
    // It allows you to divide a class, method or structure into several parts and save them in separate files.
    // Umożliwia podzielenie klasy, metody lub struktury na kilka części i zapis ich w osobnych plikach.
    {

        private System.ComponentModel.IContainer components = null;
        // Required designer variable.
        // Wymagana zmienna projektanta.

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        // Clean up any resources being used. True if managed resources should be disposed; otherwise, false.
        // Wyczyść wszystkie używane zasoby. Prawda, jeśli zarządzane zasoby powinny zostać usunięte; w przeciwnym razie fałsz.

        #region Windows Form Designer generated code
        // Lets you specify a code block, boat, or collapse when using the outline feature in the code editor.
        // Umożliwia określenie bloku kodu, łodzią lub zwijać podczas korzystania z funkcji konspektu w edytorze kodu.

        private void InitializeComponent()
        // Boot method.
        // Metoda rozruchowa.
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNeighbourhood = new System.Windows.Forms.ComboBox();
            this.comboBoxBC = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownNumberOfGrain = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericSizeOfInclusions = new System.Windows.Forms.NumericUpDown();
            this.numericAmountOfInclusions = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxTypeOfInclusion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonAddInclusions = new System.Windows.Forms.Button();
            this.comboBoxStructureType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSelectGrains = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.numericUpDownSubGrainsNum = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonGenerateGB = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownGBSize = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonRemoveColors = new System.Windows.Forms.Button();
            this.radioButtonAC = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microstructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfGrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSizeOfInclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmountOfInclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubGrainsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGBSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(248, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 575);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Field width [pixels]:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Field height [pixels]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type of neighbourhood:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxNeighbourhood
            // 
            this.comboBoxNeighbourhood.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxNeighbourhood.FormattingEnabled = true;
            this.comboBoxNeighbourhood.Items.AddRange(new object[] {
            "Von Neumann",
            "Moore",
            "Further More"});
            this.comboBoxNeighbourhood.Location = new System.Drawing.Point(144, 134);
            this.comboBoxNeighbourhood.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNeighbourhood.Name = "comboBoxNeighbourhood";
            this.comboBoxNeighbourhood.Size = new System.Drawing.Size(96, 21);
            this.comboBoxNeighbourhood.TabIndex = 6;
            this.comboBoxNeighbourhood.SelectedIndexChanged += new System.EventHandler(this.comboBoxNeighbourhood_SelectedIndexChanged);
            // 
            // comboBoxBC
            // 
            this.comboBoxBC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxBC.FormattingEnabled = true;
            this.comboBoxBC.Items.AddRange(new object[] {
            "Non-periodical",
            "Periodical"});
            this.comboBoxBC.Location = new System.Drawing.Point(126, 163);
            this.comboBoxBC.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBC.Name = "comboBoxBC";
            this.comboBoxBC.Size = new System.Drawing.Size(114, 21);
            this.comboBoxBC.TabIndex = 8;
            this.comboBoxBC.SelectedIndexChanged += new System.EventHandler(this.comboBoxBC_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Boundary Condition:";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(879, 480);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(133, 47);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start simulate";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonStop.Location = new System.Drawing.Point(879, 535);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(133, 30);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "Stop simulate";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonRestart.Location = new System.Drawing.Point(879, 573);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(133, 30);
            this.buttonRestart.TabIndex = 11;
            this.buttonRestart.Text = "Reset all";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownWidth.Location = new System.Drawing.Point(120, 48);
            this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWidth.TabIndex = 12;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownHeight.Location = new System.Drawing.Point(124, 78);
            this.numericUpDownHeight.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(116, 20);
            this.numericUpDownHeight.TabIndex = 13;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDownNumberOfGrain
            // 
            this.numericUpDownNumberOfGrain.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownNumberOfGrain.Location = new System.Drawing.Point(112, 106);
            this.numericUpDownNumberOfGrain.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownNumberOfGrain.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownNumberOfGrain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfGrain.Name = "numericUpDownNumberOfGrain";
            this.numericUpDownNumberOfGrain.Size = new System.Drawing.Size(128, 20);
            this.numericUpDownNumberOfGrain.TabIndex = 15;
            this.numericUpDownNumberOfGrain.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownNumberOfGrain.ValueChanged += new System.EventHandler(this.numericUpDownNumberOfGrain_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Amount of grains:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(5, 247);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Inclusions options:";
            // 
            // numericSizeOfInclusions
            // 
            this.numericSizeOfInclusions.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericSizeOfInclusions.Location = new System.Drawing.Point(106, 299);
            this.numericSizeOfInclusions.Margin = new System.Windows.Forms.Padding(4);
            this.numericSizeOfInclusions.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericSizeOfInclusions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSizeOfInclusions.Name = "numericSizeOfInclusions";
            this.numericSizeOfInclusions.Size = new System.Drawing.Size(134, 20);
            this.numericSizeOfInclusions.TabIndex = 22;
            this.numericSizeOfInclusions.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numericAmountOfInclusions
            // 
            this.numericAmountOfInclusions.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericAmountOfInclusions.Location = new System.Drawing.Point(122, 268);
            this.numericAmountOfInclusions.Margin = new System.Windows.Forms.Padding(4);
            this.numericAmountOfInclusions.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericAmountOfInclusions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAmountOfInclusions.Name = "numericAmountOfInclusions";
            this.numericAmountOfInclusions.Size = new System.Drawing.Size(118, 20);
            this.numericAmountOfInclusions.TabIndex = 21;
            this.numericAmountOfInclusions.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 301);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Size of inclusions:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 270);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Amount of inclusions:";
            // 
            // comboBoxTypeOfInclusion
            // 
            this.comboBoxTypeOfInclusion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxTypeOfInclusion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxTypeOfInclusion.FormattingEnabled = true;
            this.comboBoxTypeOfInclusion.Items.AddRange(new object[] {
            "Circle",
            "Square"});
            this.comboBoxTypeOfInclusion.Location = new System.Drawing.Point(105, 330);
            this.comboBoxTypeOfInclusion.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTypeOfInclusion.Name = "comboBoxTypeOfInclusion";
            this.comboBoxTypeOfInclusion.Size = new System.Drawing.Size(135, 21);
            this.comboBoxTypeOfInclusion.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 333);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Type of inclusion:";
            // 
            // buttonAddInclusions
            // 
            this.buttonAddInclusions.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonAddInclusions.Location = new System.Drawing.Point(55, 359);
            this.buttonAddInclusions.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddInclusions.Name = "buttonAddInclusions";
            this.buttonAddInclusions.Size = new System.Drawing.Size(136, 30);
            this.buttonAddInclusions.TabIndex = 25;
            this.buttonAddInclusions.Text = "Add inclusions to the field";
            this.buttonAddInclusions.UseVisualStyleBackColor = false;
            this.buttonAddInclusions.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxStructureType
            // 
            this.comboBoxStructureType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxStructureType.FormattingEnabled = true;
            this.comboBoxStructureType.Items.AddRange(new object[] {
            "Substructure",
            "Dual phase"});
            this.comboBoxStructureType.Location = new System.Drawing.Point(115, 528);
            this.comboBoxStructureType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStructureType.Name = "comboBoxStructureType";
            this.comboBoxStructureType.Size = new System.Drawing.Size(125, 21);
            this.comboBoxStructureType.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 531);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Type of substructure:";
            // 
            // buttonSelectGrains
            // 
            this.buttonSelectGrains.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonSelectGrains.Location = new System.Drawing.Point(5, 398);
            this.buttonSelectGrains.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSelectGrains.Name = "buttonSelectGrains";
            this.buttonSelectGrains.Size = new System.Drawing.Size(235, 30);
            this.buttonSelectGrains.TabIndex = 30;
            this.buttonSelectGrains.Text = "Choose grains";
            this.buttonSelectGrains.UseVisualStyleBackColor = false;
            this.buttonSelectGrains.Click += new System.EventHandler(this.buttonSelectGrains_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonGenerate.Location = new System.Drawing.Point(55, 585);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(136, 30);
            this.buttonGenerate.TabIndex = 31;
            this.buttonGenerate.Text = "Generate substructure";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // numericUpDownSubGrainsNum
            // 
            this.numericUpDownSubGrainsNum.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownSubGrainsNum.Location = new System.Drawing.Point(115, 557);
            this.numericUpDownSubGrainsNum.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownSubGrainsNum.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownSubGrainsNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSubGrainsNum.Name = "numericUpDownSubGrainsNum";
            this.numericUpDownSubGrainsNum.Size = new System.Drawing.Size(125, 20);
            this.numericUpDownSubGrainsNum.TabIndex = 32;
            this.numericUpDownSubGrainsNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 560);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Amount of subgrains:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(2, 505);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Substructure options:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // buttonGenerateGB
            // 
            this.buttonGenerateGB.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonGenerateGB.Location = new System.Drawing.Point(3, 472);
            this.buttonGenerateGB.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenerateGB.Name = "buttonGenerateGB";
            this.buttonGenerateGB.Size = new System.Drawing.Size(115, 30);
            this.buttonGenerateGB.TabIndex = 36;
            this.buttonGenerateGB.Text = "Generate bounaries";
            this.buttonGenerateGB.UseVisualStyleBackColor = false;
            this.buttonGenerateGB.Click += new System.EventHandler(this.buttonGenerateGB_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 452);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Size of border:";
            // 
            // numericUpDownGBSize
            // 
            this.numericUpDownGBSize.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownGBSize.Location = new System.Drawing.Point(90, 449);
            this.numericUpDownGBSize.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownGBSize.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownGBSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGBSize.Name = "numericUpDownGBSize";
            this.numericUpDownGBSize.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownGBSize.TabIndex = 37;
            this.numericUpDownGBSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label17.Location = new System.Drawing.Point(7, 432);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(145, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Grain bounaries options:";
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonRemoveColors
            // 
            this.buttonRemoveColors.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonRemoveColors.Location = new System.Drawing.Point(122, 472);
            this.buttonRemoveColors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveColors.Name = "buttonRemoveColors";
            this.buttonRemoveColors.Size = new System.Drawing.Size(122, 30);
            this.buttonRemoveColors.TabIndex = 40;
            this.buttonRemoveColors.Text = "Remove grains colors";
            this.buttonRemoveColors.UseVisualStyleBackColor = false;
            this.buttonRemoveColors.Click += new System.EventHandler(this.buttonRemoveColors_Click);
            // 
            // radioButtonAC
            // 
            this.radioButtonAC.AutoSize = true;
            this.radioButtonAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonAC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.radioButtonAC.Location = new System.Drawing.Point(8, 24);
            this.radioButtonAC.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonAC.Name = "radioButtonAC";
            this.radioButtonAC.Size = new System.Drawing.Size(107, 17);
            this.radioButtonAC.TabIndex = 45;
            this.radioButtonAC.TabStop = true;
            this.radioButtonAC.Text = "Cellular Automata";
            this.radioButtonAC.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonAC);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(11, 192);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(123, 51);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Type:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(16, 28);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "General options:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1025, 24);
            this.menuStrip1.TabIndex = 65;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.microstructureToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // microstructureToolStripMenuItem
            // 
            this.microstructureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.importToolStripMenuItem.Text = "Import from";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toTextToolStripMenuItem,
            this.toBitmapToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exportToolStripMenuItem.Text = "Export to";
            // 
            // toTextToolStripMenuItem
            // 
            this.toTextToolStripMenuItem.Name = "toTextToolStripMenuItem";
            this.toTextToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.toTextToolStripMenuItem.Text = "Text";
            // 
            // toBitmapToolStripMenuItem
            // 
            this.toBitmapToolStripMenuItem.Name = "toBitmapToolStripMenuItem";
            this.toBitmapToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.toBitmapToolStripMenuItem.Text = "Bitmap";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1025, 616);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRemoveColors);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numericUpDownGBSize);
            this.Controls.Add(this.buttonGenerateGB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDownSubGrainsNum);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonSelectGrains);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxStructureType);
            this.Controls.Add(this.buttonAddInclusions);
            this.Controls.Add(this.comboBoxTypeOfInclusion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericSizeOfInclusions);
            this.Controls.Add(this.numericAmountOfInclusions);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownNumberOfGrain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxBC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxNeighbourhood);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1041, 655);
            this.MinimumSize = new System.Drawing.Size(1041, 655);
            this.Name = "Form1";
            this.Text = "Grain Growth";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfGrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSizeOfInclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmountOfInclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubGrainsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGBSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNeighbourhood;
        private System.Windows.Forms.ComboBox comboBoxBC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfGrain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericSizeOfInclusions;
        private System.Windows.Forms.NumericUpDown numericAmountOfInclusions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxTypeOfInclusion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonAddInclusions;
        private System.Windows.Forms.ComboBox comboBoxStructureType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSelectGrains;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.NumericUpDown numericUpDownSubGrainsNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonGenerateGB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownGBSize;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonRemoveColors;
        private System.Windows.Forms.RadioButton radioButtonAC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microstructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toBitmapToolStripMenuItem;
    }
}

