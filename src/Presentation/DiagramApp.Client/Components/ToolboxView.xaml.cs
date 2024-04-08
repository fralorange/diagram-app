using DiagramApp.Client.ViewModels;
using DiagramApp.Client.ViewModels.Wrappers;
using DiagramApp.Domain.Canvas.Figures;
using DiagramApp.Domain.Toolbox;

namespace DiagramApp.Client.Components;

public partial class ToolboxView : Frame
{
	public ToolboxView()
	{
		InitializeComponent();
	}

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is CollectionView collectionView && collectionView.SelectedItem is not null)
        {
            if (BindingContext is MainViewModel viewModel && viewModel.IsCanvasNotNull)
            {
                var current = e.CurrentSelection[0] as ToolboxItem;
                var figure = new Figure
                {
                    Name = current!.Name,
                    PathData = current!.PathData,
                };

                viewModel.CurrentCanvas!.Figures.Add(new ObservableFigure(figure));
            }

            Dispatcher.Dispatch(() =>
            {
                collectionView.SelectedItem = null;
            });
        }
    }
}