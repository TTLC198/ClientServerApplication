using System.ComponentModel;

namespace Client.Forms
{
    partial class PhotographerForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ordersCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.queriesList = new System.Windows.Forms.ListBox();
            this.imagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialogButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.imagesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ordersCountLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.userLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 22);
            this.panel1.TabIndex = 0;
            // 
            // ordersCountLabel
            // 
            this.ordersCountLabel.Location = new System.Drawing.Point(366, 0);
            this.ordersCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ordersCountLabel.Name = "ordersCountLabel";
            this.ordersCountLabel.Size = new System.Drawing.Size(96, 19);
            this.ordersCountLabel.TabIndex = 3;
            this.ordersCountLabel.Text = "label4";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(247, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество заказов:";
            // 
            // userLabel
            // 
            this.userLabel.Location = new System.Drawing.Point(86, 1);
            this.userLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(157, 18);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "label3";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(552, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "Личный кабинет";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.Location = new System.Drawing.Point(561, 7);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 33);
            this.exitButton.TabIndex = 2;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.messageBox);
            this.panel2.Controls.Add(this.ExecuteButton);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.queriesList);
            this.panel2.Location = new System.Drawing.Point(5, 88);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 268);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label5.Location = new System.Drawing.Point(3, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Сообщение";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messageBox
            // 
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageBox.Location = new System.Drawing.Point(3, 145);
            this.messageBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(227, 92);
            this.messageBox.TabIndex = 7;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(3, 237);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(227, 26);
            this.ExecuteButton.TabIndex = 6;
            this.ExecuteButton.Text = "Отправить заказчику";
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
            // queriesList
            // 
            this.queriesList.FormattingEnabled = true;
            this.queriesList.Location = new System.Drawing.Point(3, 26);
            this.queriesList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.queriesList.Name = "queriesList";
            this.queriesList.Size = new System.Drawing.Size(228, 95);
            this.queriesList.TabIndex = 0;
            this.queriesList.SelectedIndexChanged += new System.EventHandler(this.queriesList_SelectedIndexChanged);
            // 
            // imagesPanel
            // 
            this.imagesPanel.AutoScroll = true;
            this.imagesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagesPanel.Controls.Add(this.openFileDialogButton);
            this.imagesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.imagesPanel.Location = new System.Drawing.Point(244, 89);
            this.imagesPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imagesPanel.Name = "imagesPanel";
            this.imagesPanel.Size = new System.Drawing.Size(347, 266);
            this.imagesPanel.TabIndex = 4;
            this.imagesPanel.WrapContents = false;
            // 
            // openFileDialogButton
            // 
            this.openFileDialogButton.Location = new System.Drawing.Point(2, 2);
            this.openFileDialogButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openFileDialogButton.Name = "openFileDialogButton";
            this.openFileDialogButton.Size = new System.Drawing.Size(336, 27);
            this.openFileDialogButton.TabIndex = 0;
            this.openFileDialogButton.Text = "Выбрать фото\r\n";
            this.openFileDialogButton.UseVisualStyleBackColor = true;
            this.openFileDialogButton.Click += new System.EventHandler(this.openFileDialogButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PhotographerForm
            // 
            this.AcceptButton = this.ExecuteButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 365);
            this.Controls.Add(this.imagesPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PhotographerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotographerForm";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PhotographerForm_FormClosed);
            this.Load += new System.EventHandler(this.PhotographerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.imagesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button openFileDialogButton;
        private System.Windows.Forms.TextBox messageBox;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.FlowLayoutPanel imagesPanel;

        private System.Windows.Forms.Button ExecuteButton;

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Windows.Forms.ListBox queriesList;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Label ordersCountLabel;

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button exitButton;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}
