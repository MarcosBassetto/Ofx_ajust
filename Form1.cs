namespace Ofx
{
    public partial class frmOfx : Form
    {
        public frmOfx()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_FontChanged(object sender, EventArgs e)
        {

        }

        private void asdasdasd(object sender, EventArgs e)
        {

        }

        private void btnSelecao_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "OFX Files|*.ofx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSelect.Text = openFileDialog.FileName;
            }
        }

        private void btnAjuste_Click(object sender, EventArgs e)
        {
            string filePath = txtSelect.Text;
            if (File.Exists(filePath))
            {
                string ofxData = File.ReadAllText(filePath);
                OfxAjuste ofxAjuste = new OfxAjuste();
                ofxAjuste.VerificaTag(ofxData);

                // Ajustar tags <MEMO>
                string result = ofxAjuste.AjustarMemos(ofxAjuste.GetOfx());

                if (!string.IsNullOrEmpty(result))
                {
                    bool saved = ofxAjuste.SalvarOfx(filePath, result);
                    if (saved)
                    {
                        MessageBox.Show("Ajuste conclu�do com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("O salvamento foi cancelado pelo usu�rio.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum ajuste necess�rio.", "Informa��o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Arquivo n�o encontrado. Selecione um arquivo v�lido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
