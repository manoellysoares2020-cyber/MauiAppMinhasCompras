namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

	private void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Navigation.PushAsync(new Views.ListaProduto());
		}
		catch (Exception ex)
		{
			DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}