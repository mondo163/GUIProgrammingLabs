
namespace AwesomeAnagrams
{
    partial class AwesomeAnagramsMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LetterBankBox = new System.Windows.Forms.TextBox();
            this.StopBut = new System.Windows.Forms.Button();
            this.StartBut = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.UserEntryBox = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.Guesses = new System.Windows.Forms.Label();
            this.GuessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DefintionsLabel = new System.Windows.Forms.Label();
            this.DefinitionsTextBox = new System.Windows.Forms.TextBox();
            this.ShowDefinitionsButton = new System.Windows.Forms.Button();
            this.AnagramListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LetterBankBox
            // 
            this.LetterBankBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LetterBankBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LetterBankBox.Cursor = System.Windows.Forms.Cursors.No;
            this.LetterBankBox.Font = new System.Drawing.Font("Gill Sans MT", 67.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterBankBox.Location = new System.Drawing.Point(343, 48);
            this.LetterBankBox.Multiline = true;
            this.LetterBankBox.Name = "LetterBankBox";
            this.LetterBankBox.ReadOnly = true;
            this.LetterBankBox.ShortcutsEnabled = false;
            this.LetterBankBox.Size = new System.Drawing.Size(626, 202);
            this.LetterBankBox.TabIndex = 3;
            this.LetterBankBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StopBut
            // 
            this.StopBut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StopBut.Font = new System.Drawing.Font("Gill Sans MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBut.Location = new System.Drawing.Point(27, 141);
            this.StopBut.Name = "StopBut";
            this.StopBut.Size = new System.Drawing.Size(295, 89);
            this.StopBut.TabIndex = 5;
            this.StopBut.Text = "Stop";
            this.StopBut.UseVisualStyleBackColor = true;
            this.StopBut.Click += new System.EventHandler(this.StopBut_Click);
            // 
            // StartBut
            // 
            this.StartBut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartBut.Font = new System.Drawing.Font("Gill Sans MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBut.Location = new System.Drawing.Point(27, 48);
            this.StartBut.Name = "StartBut";
            this.StartBut.Size = new System.Drawing.Size(295, 87);
            this.StartBut.TabIndex = 6;
            this.StartBut.Text = "Start";
            this.StartBut.UseVisualStyleBackColor = true;
            this.StartBut.Click += new System.EventHandler(this.StartBut_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InstructionsLabel.AutoSize = true;
            this.InstructionsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLabel.Location = new System.Drawing.Point(339, 253);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(630, 46);
            this.InstructionsLabel.TabIndex = 8;
            this.InstructionsLabel.Text = "Press Start to Begin the Game. Stop to halt the Game. \r\nOnce Start is hit again, " +
    "a new assortment of characters will displayed. ";
            this.InstructionsLabel.Click += new System.EventHandler(this.InstructionsLabel_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Gill Sans MT", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(975, 98);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(225, 111);
            this.TimerLabel.TabIndex = 9;
            this.TimerLabel.Text = "00:00";
            this.TimerLabel.Click += new System.EventHandler(this.TimerLabel_Click);
            // 
            // UserEntryBox
            // 
            this.UserEntryBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEntryBox.Font = new System.Drawing.Font("Gill Sans MT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserEntryBox.Location = new System.Drawing.Point(343, 311);
            this.UserEntryBox.Name = "UserEntryBox";
            this.UserEntryBox.Size = new System.Drawing.Size(626, 34);
            this.UserEntryBox.TabIndex = 10;
            // 
            // EnterButton
            // 
            this.EnterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterButton.BackColor = System.Drawing.Color.Lime;
            this.EnterButton.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterButton.Location = new System.Drawing.Point(989, 310);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(170, 35);
            this.EnterButton.TabIndex = 11;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // Guesses
            // 
            this.Guesses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Guesses.AutoSize = true;
            this.Guesses.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guesses.Location = new System.Drawing.Point(22, 349);
            this.Guesses.Name = "Guesses";
            this.Guesses.Size = new System.Drawing.Size(82, 29);
            this.Guesses.TabIndex = 12;
            this.Guesses.Text = "Guesses";
            // 
            // GuessTextBox
            // 
            this.GuessTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GuessTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.GuessTextBox.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuessTextBox.Location = new System.Drawing.Point(27, 381);
            this.GuessTextBox.Multiline = true;
            this.GuessTextBox.Name = "GuessTextBox";
            this.GuessTextBox.ReadOnly = true;
            this.GuessTextBox.Size = new System.Drawing.Size(241, 384);
            this.GuessTextBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 87);
            this.label1.TabIndex = 14;
            this.label1.Text = "Anagrams\r\n\r\n\r\n";
            // 
            // DefintionsLabel
            // 
            this.DefintionsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DefintionsLabel.AutoSize = true;
            this.DefintionsLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefintionsLabel.Location = new System.Drawing.Point(710, 348);
            this.DefintionsLabel.Name = "DefintionsLabel";
            this.DefintionsLabel.Size = new System.Drawing.Size(101, 29);
            this.DefintionsLabel.TabIndex = 16;
            this.DefintionsLabel.Text = "Definitions";
            // 
            // DefinitionsTextBox
            // 
            this.DefinitionsTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DefinitionsTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DefinitionsTextBox.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefinitionsTextBox.Location = new System.Drawing.Point(715, 380);
            this.DefinitionsTextBox.Multiline = true;
            this.DefinitionsTextBox.Name = "DefinitionsTextBox";
            this.DefinitionsTextBox.ReadOnly = true;
            this.DefinitionsTextBox.Size = new System.Drawing.Size(444, 385);
            this.DefinitionsTextBox.TabIndex = 17;
            // 
            // ShowDefinitionsButton
            // 
            this.ShowDefinitionsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShowDefinitionsButton.Font = new System.Drawing.Font("Gill Sans MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowDefinitionsButton.Location = new System.Drawing.Point(27, 236);
            this.ShowDefinitionsButton.Name = "ShowDefinitionsButton";
            this.ShowDefinitionsButton.Size = new System.Drawing.Size(295, 98);
            this.ShowDefinitionsButton.TabIndex = 18;
            this.ShowDefinitionsButton.Text = "Show Definitions";
            this.ShowDefinitionsButton.UseVisualStyleBackColor = true;
            this.ShowDefinitionsButton.Click += new System.EventHandler(this.ShowDefinitionsButton_Click);
            // 
            // AnagramListBox
            // 
            this.AnagramListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnagramListBox.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnagramListBox.FormattingEnabled = true;
            this.AnagramListBox.ItemHeight = 29;
            this.AnagramListBox.Location = new System.Drawing.Point(329, 384);
            this.AnagramListBox.Name = "AnagramListBox";
            this.AnagramListBox.Size = new System.Drawing.Size(328, 381);
            this.AnagramListBox.TabIndex = 19;
            // 
            // AwesomeAnagramsMain
            // 
            this.AcceptButton = this.EnterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 769);
            this.Controls.Add(this.AnagramListBox);
            this.Controls.Add(this.ShowDefinitionsButton);
            this.Controls.Add(this.DefinitionsTextBox);
            this.Controls.Add(this.DefintionsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GuessTextBox);
            this.Controls.Add(this.Guesses);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.UserEntryBox);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.StartBut);
            this.Controls.Add(this.StopBut);
            this.Controls.Add(this.LetterBankBox);
            this.MinimumSize = new System.Drawing.Size(1400, 739);
            this.Name = "AwesomeAnagramsMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Awesome Anagrams";
            this.Load += new System.EventHandler(this.AwesomeAnagramsMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LetterBankBox;
        private System.Windows.Forms.Button StopBut;
        private System.Windows.Forms.Button StartBut;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.TextBox UserEntryBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label Guesses;
        private System.Windows.Forms.TextBox GuessTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DefintionsLabel;
        private System.Windows.Forms.TextBox DefinitionsTextBox;
        private System.Windows.Forms.Button ShowDefinitionsButton;
        private System.Windows.Forms.ListBox AnagramListBox;
    }
}

