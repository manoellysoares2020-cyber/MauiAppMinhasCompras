using MauiAppMinhasCompras.Model;


namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

	private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

            App.Db.Insert(p);
			await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");

		}
		catch (Exception ex)
		{
            await DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}