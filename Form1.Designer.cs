namespace Ofx
{
    partial class frmOfx
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfx));
            btnAjuste = new Button();
            txtSelect = new TextBox();
            btnSelecao = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnAjuste
            // 
            btnAjuste.Location = new Point(163, 130);
            btnAjuste.Name = "btnAjuste";
            btnAjuste.Size = new Size(127, 23);
            btnAjuste.TabIndex = 0;
            btnAjuste.Text = "Ajuste de Arquivo";
            btnAjuste.UseVisualStyleBackColor = true;
            btnAjuste.Click += btnAjuste_Click;
            // 
            // txtSelect
            // 
            txtSelect.Enabled = false;
            txtSelect.Location = new Point(12, 65);
            txtSelect.Name = "txtSelect";
            txtSelect.Size = new Size(337, 23);
            txtSelect.TabIndex = 1;
            // 
            // btnSelecao
            // 
            btnSelecao.Location = new Point(355, 65);
            btnSelecao.Name = "btnSelecao";
            btnSelecao.Size = new Size(75, 23);
            btnSelecao.TabIndex = 2;
            btnSelecao.Text = "Seleção de arquivo";
            btnSelecao.UseVisualStyleBackColor = true;
            btnSelecao.Click += btnSelecao_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 9);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 3;
            label1.Text = "Ofx Ajute";
            label1.TextAlignChanged += asdasdasd;
            label1.FontChanged += label1_FontChanged;
            label1.Click += label1_Click;
            // 
            // frmOfx
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(442, 181);
            Controls.Add(label1);
            Controls.Add(btnSelecao);
            Controls.Add(txtSelect);
            Controls.Add(btnAjuste);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmOfx";
            Text = "OfxAjust";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAjuste;
        private TextBox txtSelect;
        private Button btnSelecao;
        private Label label1;
    }
}
