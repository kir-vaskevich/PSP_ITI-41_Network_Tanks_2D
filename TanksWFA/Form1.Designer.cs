
namespace TanksWFA
{
    partial class Form1
    {
        private OpenTK.GLControl gLControl;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
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
            this.gLControl = new OpenTK.GLControl();
            this.tank2Ammo = new System.Windows.Forms.Label();
            this.tank1Ammo = new System.Windows.Forms.Label();
            this.tank2Health = new System.Windows.Forms.Label();
            this.tank1Health = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EndGameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tank2Fuel = new System.Windows.Forms.Label();
            this.tank1Fuel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gLControl
            // 
            this.gLControl.BackColor = System.Drawing.Color.Transparent;
            this.gLControl.Location = new System.Drawing.Point(-4, -10);
            this.gLControl.Margin = new System.Windows.Forms.Padding(0);
            this.gLControl.Name = "gLControl";
            this.gLControl.Size = new System.Drawing.Size(1600, 900);
            this.gLControl.TabIndex = 0;
            this.gLControl.VSync = false;
            this.gLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.gLControl.Resize += new System.EventHandler(this.GLControl_Resize);
            // 
            // tank2Ammo
            // 
            this.tank2Ammo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tank2Ammo.Location = new System.Drawing.Point(1359, 830);
            this.tank2Ammo.Name = "tank2Ammo";
            this.tank2Ammo.Size = new System.Drawing.Size(50, 30);
            this.tank2Ammo.TabIndex = 1;
            // 
            // tank1Ammo
            // 
            this.tank1Ammo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tank1Ammo.Location = new System.Drawing.Point(151, 830);
            this.tank1Ammo.Name = "tank1Ammo";
            this.tank1Ammo.Size = new System.Drawing.Size(50, 30);
            this.tank1Ammo.TabIndex = 2;
            // 
            // tank2Health
            // 
            this.tank2Health.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tank2Health.Location = new System.Drawing.Point(1247, 830);
            this.tank2Health.Name = "tank2Health";
            this.tank2Health.Size = new System.Drawing.Size(50, 30);
            this.tank2Health.TabIndex = 4;
            // 
            // tank1Health
            // 
            this.tank1Health.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tank1Health.Location = new System.Drawing.Point(39, 830);
            this.tank1Health.Name = "tank1Health";
            this.tank1Health.Size = new System.Drawing.Size(50, 30);
            this.tank1Health.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 789);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Здоровье:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(151, 789);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Патроны:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1247, 789);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Здоровье:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1359, 789);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Патроны:";
            // 
            // EndGameLabel
            // 
            this.EndGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndGameLabel.Location = new System.Drawing.Point(593, 265);
            this.EndGameLabel.Name = "EndGameLabel";
            this.EndGameLabel.Size = new System.Drawing.Size(423, 152);
            this.EndGameLabel.TabIndex = 10;
            this.EndGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EndGameLabel.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1458, 789);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "Топливо:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(250, 789);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 30);
            this.label6.TabIndex = 8;
            this.label6.Text = "Топливо:";
            // 
            // tank2Fuel
            // 
            this.tank2Fuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tank2Fuel.Location = new System.Drawing.Point(1458, 830);
            this.tank2Fuel.Name = "tank2Fuel";
            this.tank2Fuel.Size = new System.Drawing.Size(50, 30);
            this.tank2Fuel.TabIndex = 12;
            // 
            // tank1Fuel
            // 
            this.tank1Fuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tank1Fuel.Location = new System.Drawing.Point(250, 830);
            this.tank1Fuel.Name = "tank1Fuel";
            this.tank1Fuel.Size = new System.Drawing.Size(50, 30);
            this.tank1Fuel.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1592, 880);
            this.Controls.Add(this.tank1Fuel);
            this.Controls.Add(this.tank2Fuel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EndGameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tank1Health);
            this.Controls.Add(this.tank2Health);
            this.Controls.Add(this.tank1Ammo);
            this.Controls.Add(this.tank2Ammo);
            this.Controls.Add(this.gLControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tank2Ammo;
        private System.Windows.Forms.Label tank1Ammo;
        private System.Windows.Forms.Label tank2Health;
        private System.Windows.Forms.Label tank1Health;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EndGameLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tank2Fuel;
        private System.Windows.Forms.Label tank1Fuel;
    }
}