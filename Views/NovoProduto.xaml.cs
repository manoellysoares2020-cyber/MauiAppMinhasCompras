using MauiAppMinhasCompras.Model;


namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage // tela de cadastro
{
	public NovoProduto()
	{
		InitializeComponent(); // inicializa o XAML
    }

    // evento do botão "Salvar"
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{

            // cria um novo produto com os dados digitados
            Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text),
				Categoria = txt_categoria.Text

            };

            App.Db.Insert(p); // sala no banco
			await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");
            await Navigation.PopAsync(); // volta para a tela anterior

		}
		catch (Exception ex)
		{
            await DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}