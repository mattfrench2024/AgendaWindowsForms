using AgendaWindowsForms_EDD2.models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AgendaWindowsForms_EDD2
{
    public partial class Form1 : Form
    {
        private Agenda contatos = new Agenda();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var data = new Data(dtpNasc.Value.Day, dtpNasc.Value.Month, dtpNasc.Value.Year);
            var contato = new Contato(txtNome.Text, txtEmail.Text, data);
            contato.AdicionarTelefone(new Telefone("Celular", txtTelefone.Text, chkPrincipal.Checked));

            if (contatos.Adicionar(contato))
            {
                MessageBox.Show("Contato adicionado!");
                ListarContatos();
            }
            else
            {
                MessageBox.Show("Já existe contato com esse email!");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var c = contatos.Pesquisar(txtEmail.Text);
            if (c != null)
                MessageBox.Show(c.ToString());
            else
                MessageBox.Show("Contato não encontrado.");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var data = new Data(dtpNasc.Value.Day, dtpNasc.Value.Month, dtpNasc.Value.Year);
            var contato = new Contato(txtNome.Text, txtEmail.Text, data);
            contato.AdicionarTelefone(new Telefone("Celular", txtTelefone.Text, chkPrincipal.Checked));

            if (contatos.Alterar(contato))
                MessageBox.Show("Contato alterado!");
            else
                MessageBox.Show("Contato não encontrado.");

            ListarContatos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (contatos.Remover(txtEmail.Text))
                MessageBox.Show("Contato removido!");
            else
                MessageBox.Show("Contato não encontrado.");

            ListarContatos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarContatos();
        }

        private void ListarContatos()
        {
            dgvContatos.DataSource = null;
            dgvContatos.DataSource = contatos.Contatos.Select(c => new
            {
                c.Nome,
                c.Email,
                DataNasc = c.DtNasc.ToString(),
                Telefone = c.GetTelefonePrincipal()
            }).ToList();
        }
    }
}
