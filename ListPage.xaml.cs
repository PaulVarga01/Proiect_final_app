using Proiect_final_app.Models;
namespace Proiect_final_app;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetToDoListsAsync();
    }
    async void OnToDoListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LP
        {
            BindingContext = new ToDoList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new LP
            {
                BindingContext = e.SelectedItem as ToDoList
            });
        }
    }

}