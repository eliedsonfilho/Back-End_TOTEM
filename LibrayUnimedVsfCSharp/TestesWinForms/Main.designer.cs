namespace TestesWinForms
{
    partial class Main
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.impress�oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirV�riosBoletosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Arquivos de Retorno (*.ret)|*.ret|Todos Arquivos (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Arquivos de Retorno (*.ret)|*.ret|Todos Arquivos (*.*)|*.*";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.impress�oToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // impress�oToolStripMenuItem
            // 
            this.impress�oToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirV�riosBoletosToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.impress�oToolStripMenuItem.Name = "impress�oToolStripMenuItem";
            this.impress�oToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.impress�oToolStripMenuItem.Text = "&Impress�o";
            // 
            // imprimirV�riosBoletosToolStripMenuItem
            // 
            this.imprimirV�riosBoletosToolStripMenuItem.Name = "imprimirV�riosBoletosToolStripMenuItem";
            this.imprimirV�riosBoletosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.imprimirV�riosBoletosToolStripMenuItem.Text = "Imprimir V�rios Boletos";
            this.imprimirV�riosBoletosToolStripMenuItem.Click += new System.EventHandler(this.impress�oToolStripMenuItem_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 446);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testes Winforms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem impress�oToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem imprimirV�riosBoletosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
    }
}

