using CommunityToolkit.Mvvm.Input;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}