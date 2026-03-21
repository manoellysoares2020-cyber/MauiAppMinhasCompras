using MauiAppMinhasCompras.Model;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {Produto produto_anexado = (Produto)BindingContext; // pega o produto que está anexado a tela
      //{Produto produto_anexado = BindingContext as Produto; // outra forma de fazer o mesmo que a linha acima, usando o operador "as",
      //assim que está na aula do professor, no entanto, o código acima é uma indicação do própio Visual Studio

            // cria um novo produto com os dados digitados
            Produto p = new Produto
            {
                Id = produto_anexado.Id, // mantém o mesmo Id do produto que está anexado a tela
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            App.Db.Insert(p); // sala no banco
            await DisplayAlert("Sucesso", "Registro atualizado!", "OK");
            await Navigation.PopAsync(); // volta para a tela anterior

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}