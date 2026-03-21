using MauiAppMinhasCompras.Model;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
   

    public ListaProduto()
	{
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
	{
		try
		{
			List<Produto> tmp = await App.Db.GetAll(); // busca todos os produtos do banco

			tmp.ForEach(i => lista.Add(i)); // adiciona na lista (mostra na tela)
		}
		catch (Exception ex)
		{
			await DisplayAlert("ops", ex.Message, "OK");
        }
    }

    // botão de adicionar produto
    private void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());  // abre tela de cadastro

        }
		catch (Exception ex)
		{
			DisplayAlert("Erro", ex.Message, "OK"); // mostra uma mensagem "Erro" se acontecer
        }
	}

    // busca dinâmica (quando digita no SearchBar)
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e) 
	{
		try
		{
			string q = e.NewTextValue; // texto digitado

			lista.Clear(); // limpa a lista atual

			List<Produto> tmp = await App.Db.Seanch(q);  // busca no banco

			tmp.ForEach(i => lista.Add(i)); // mostra resultados
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK"); // mostra uma mensagem "Erro" se acontecer
		}

        }

    // botão que calcula o total
    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
	{
		double soma = lista.Sum(i => i.Total);  // soma todos os totais

        string msg = $"O total é {soma:C}"; // formata como dinheiro

        DisplayAlert("Total dos Produtos", msg, "OK");
		
	}

	private async void MenuItem_Clicked(object sender, EventArgs e)
	{

		try
		{
			MenuItem selecionado = sender as MenuItem; /// pega o produto selecionado (clicado)

			Produto p = selecionado.BindingContext as Produto; // pega o produto associado ao item do menu (o produto que foi clicado)

			bool confirm = await DisplayAlert(
				"Tem certeza?", $"Remover {p.Descricao}?", "Sim", "Não");
			if (confirm)
			{
				await App.Db.Delete(p.Id); // remove do banco
				lista.Remove(p); // remove da lista (tela)
			}
		}
		catch (Exception ex)
		{
           await DisplayAlert("Erro", ex.Message, "OK");
        }
	
	}

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		try
		{
         Produto p = e.SelectedItem as Produto; // pega o produto selecionado

			Navigation.PushAsync(new Views.EditarProduto // abre a tela de edição passando o produto
			{
				BindingContext = p, // mostra os dados do produto na tela de edição
			});
		}
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}