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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotographerForm));
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
            this.panel1.Location = new System.Drawing.Point(7, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 27);
            this.panel1.TabIndex = 0;
            // 
            // ordersCountLabel
            // 
            this.ordersCountLabel.Location = new System.Drawing.Point(488, 0);
            this.ordersCountLabel.Name = "ordersCountLabel";
            this.ordersCountLabel.Size = new System.Drawing.Size(128, 23);
            this.ordersCountLabel.TabIndex = 3;
            this.ordersCountLabel.Text = "label4";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(329, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество заказов:";
            // 
            // userLabel
            // 
            this.userLabel.Location = new System.Drawing.Point(115, 1);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(209, 22);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "label3";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(736, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "Личный кабинет";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.Location = new System.Drawing.Point(748, 9);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 41);
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
            this.panel2.Location = new System.Drawing.Point(7, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 329);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label5.Location = new System.Drawing.Point(4, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "Сообщение";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messageBox
            // 
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageBox.Location = new System.Drawing.Point(4, 178);
            this.messageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(302, 113);
            this.messageBox.TabIndex = 7;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(4, 292);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(303, 32);
            this.ExecuteButton.TabIndex = 6;
            this.ExecuteButton.Text = "Отправить заказчику";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Заказы";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // queriesList
            // 
            this.queriesList.FormattingEnabled = true;
            this.queriesList.ItemHeight = 16;
            this.queriesList.Location = new System.Drawing.Point(4, 32);
            this.queriesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.queriesList.Name = "queriesList";
            this.queriesList.Size = new System.Drawing.Size(303, 116);
            this.queriesList.TabIndex = 0;
            this.queriesList.SelectedIndexChanged += new System.EventHandler(this.queriesList_SelectedIndexChanged);
            // 
            // imagesPanel
            // 
            this.imagesPanel.AutoScroll = true;
            this.imagesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagesPanel.Controls.Add(this.openFileDialogButton);
            this.imagesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.imagesPanel.Location = new System.Drawing.Point(325, 110);
            this.imagesPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imagesPanel.Name = "imagesPanel";
            this.imagesPanel.Size = new System.Drawing.Size(462, 327);
            this.imagesPanel.TabIndex = 4;
            this.imagesPanel.WrapContents = false;
            // 
            // openFileDialogButton
            // 
            this.openFileDialogButton.Location = new System.Drawing.Point(3, 2);
            this.openFileDialogButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openFileDialogButton.Name = "openFileDialogButton";
            this.openFileDialogButton.Size = new System.Drawing.Size(448, 33);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.imagesPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
