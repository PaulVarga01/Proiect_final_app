using Proiect_final_app.Models;

namespace Proiect_final_app;

public partial class LP : ContentPage
{
	public LP()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ToDoList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveToDoListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ToDoList)BindingContext;
        await App.Database.DeleteToDoListAsync(slist);
        await Navigation.PopAsync();
    }

}