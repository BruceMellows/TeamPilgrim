using GalaSoft.MvvmLight.Command;

namespace JustAProgrammer.TeamPilgrim.VisualStudio.Model.BuildDefinitions
{
    public interface IBuildDefinitionCommandModel
    {
        RelayCommand NewBuildDefinitionCommand { get; set; }
        RelayCommand<BuildDefinitionModel> OpenBuildDefintionCommand { get; set; }
        RelayCommand<BuildDefinitionModel> ViewBuildsCommand { get; set; }
        RelayCommand<BuildDefinitionModel> QueueBuildCommand { get; set; }
    }
}