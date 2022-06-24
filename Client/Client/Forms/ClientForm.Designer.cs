using System.ComponentModel;

namespace Client.Forms
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ordersCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NewOrderButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.photListBox = new System.Windows.Forms.ListBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.queriesListBox = new System.Windows.Forms.ListBox();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.imagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreTrackBar = new System.Windows.Forms.TrackBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.imagesPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scoreTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(552, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "Личный кабинет";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ordersCountLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.userLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 22);
            this.panel1.TabIndex = 3;
            // 
            // ordersCountLabel
            // 
            this.ordersCountLabel.Location = new System.Drawing.Point(305, 0);
            this.ordersCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ordersCountLabel.Name = "ordersCountLabel";
            this.ordersCountLabel.Size = new System.Drawing.Size(96, 19);
            this.ordersCountLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(247, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Заказы:";
            // 
            // userLabel
            // 
            this.userLabel.Location = new System.Drawing.Point(106, 1);
            this.userLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(137, 18);
            this.userLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя пользователя:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.NewOrderButton);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.photListBox);
            this.panel2.Controls.Add(this.ExecuteButton);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.queriesListBox);
            this.panel2.Location = new System.Drawing.Point(9, 89);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 268);
            this.panel2.TabIndex = 4;
            // 
            // NewOrderButton
            // 
            this.NewOrderButton.Location = new System.Drawing.Point(118, 237);
            this.NewOrderButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewOrderButton.Name = "NewOrderButton";
            this.NewOrderButton.Size = new System.Drawing.Size(112, 26);
            this.NewOrderButton.TabIndex = 9;
            this.NewOrderButton.Text = "Новый заказ";
            this.NewOrderButton.UseVisualStyleBackColor = true;
            this.NewOrderButton.Click += new System.EventHandler(this.NewOrderButton_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label6.Location = new System.Drawing.Point(5, 125);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Исполнители";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photListBox
            // 
            this.photListBox.FormattingEnabled = true;
            this.photListBox.Location = new System.Drawing.Point(3, 151);
            this.photListBox.Margin = new System.Windows.Forms.Padding(2);
            this.photListBox.Name = "photListBox";
            this.photListBox.Size = new System.Drawing.Size(228, 82);
            this.photListBox.TabIndex = 7;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(3, 237);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(112, 26);
            this.ExecuteButton.TabIndex = 6;
            this.ExecuteButton.Text = "Оформить заказ";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Заказы";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // queriesListBox
            // 
            this.queriesListBox.FormattingEnabled = true;
            this.queriesListBox.Location = new System.Drawing.Point(3, 26);
            this.queriesListBox.Margin = new System.Windows.Forms.Padding(2);
            this.queriesListBox.Name = "queriesListBox";
            this.queriesListBox.Size = new System.Drawing.Size(228, 95);
            this.queriesListBox.TabIndex = 0;
            this.queriesListBox.SelectedIndexChanged += new System.EventHandler(this.queriesListBox_SelectedIndexChanged);
            // 
            // messagePanel
            // 
            this.messagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messagePanel.Controls.Add(this.messageTextBox);
            this.messagePanel.Controls.Add(this.label5);
            this.messagePanel.Location = new System.Drawing.Point(250, 89);
            this.messagePanel.Margin = new System.Windows.Forms.Padding(2);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(360, 268);
            this.messagePanel.TabIndex = 5;
            // 
            // messageTextBox
            // 
            this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageTextBox.Location = new System.Drawing.Point(2, 27);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(349, 237);
            this.messageTextBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label5.Location = new System.Drawing.Point(2, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(349, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Сообщение";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imagesPanel
            // 
            this.imagesPanel.AutoScroll = true;
            this.imagesPanel.Controls.Add(this.scorePanel);
            this.imagesPanel.Location = new System.Drawing.Point(250, 89);
            this.imagesPanel.Margin = new System.Windows.Forms.Padding(2);
            this.imagesPanel.Name = "imagesPanel";
            this.imagesPanel.Size = new System.Drawing.Size(359, 267);
            this.imagesPanel.TabIndex = 8;
            this.imagesPanel.Visible = false;
            // 
            // scorePanel
            // 
            this.scorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scorePanel.Controls.Add(this.scoreLabel);
            this.scorePanel.Controls.Add(this.scoreTrackBar);
            this.scorePanel.Location = new System.Drawing.Point(2, 2);
            this.scorePanel.Margin = new System.Windows.Forms.Padding(2);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(350, 85);
            this.scorePanel.TabIndex = 9;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.scoreLabel.Location = new System.Drawing.Point(6, 9);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(290, 24);
            this.scoreLabel.TabIndex = 10;
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreTrackBar
            // 
            this.scoreTrackBar.Location = new System.Drawing.Point(6, 35);
            this.scoreTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.scoreTrackBar.Maximum = 5;
            this.scoreTrackBar.Name = "scoreTrackBar";
            this.scoreTrackBar.Size = new System.Drawing.Size(329, 69);
            this.scoreTrackBar.TabIndex = 0;
            this.scoreTrackBar.Value = 5;
            this.scoreTrackBar.Scroll += new System.EventHandler(this.scoreTrackBar_Scroll);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.Location = new System.Drawing.Point(579, 12);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 33);
            this.exitButton.TabIndex = 9;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(623, 380);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.imagesPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.imagesPanel.ResumeLayout(false);
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scoreTrackBar)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button exitButton;

        private System.Windows.Forms.TrackBar scoreTrackBar;
        private System.Windows.Forms.Label scoreLabel;

        private System.Windows.Forms.Panel scorePanel;

        private System.Windows.Forms.Button NewOrderButton;

        private System.Windows.Forms.ListBox photListBox;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.FlowLayoutPanel imagesPanel;
        private System.Windows.Forms.Panel messagePanel;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox messageTextBox;

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox queriesListBox;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ordersCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        #endregion
    }
}


