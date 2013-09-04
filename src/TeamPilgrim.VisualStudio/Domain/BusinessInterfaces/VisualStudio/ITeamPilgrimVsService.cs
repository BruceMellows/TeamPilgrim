﻿using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.TeamFoundation.Build.Controls;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.TeamFoundation;
using Project = Microsoft.TeamFoundation.WorkItemTracking.Client.Project;

namespace JustAProgrammer.TeamPilgrim.VisualStudio.Domain.BusinessInterfaces.VisualStudio
{
    public delegate void SolutionStateChanged();
    
    public interface ITeamPilgrimVsService
    {
        event SolutionStateChanged SolutionStateChanged;

        ProjectContextExt ActiveProjectContext { get; }
        ITeamFoundationHostWrapper TeamFoundationHost { get; }

        void OpenSourceControl(string projectName);

        void NewQueryDefinition(Project project, QueryFolder parent);
        void EditQueryDefinition(TfsTeamProjectCollection projectCollection, Guid queryDefinitionId);
        void CloseQueryDefinitionFrames(TfsTeamProjectCollection projectCollection, Guid queryDefinitionId);

        void ViewBuilds(string projectName, string buildDefinition, string qualityFilter, DateFilter dateFilter);
        void OpenBuildDefinition(Uri buildDefinitionUri);
        void QueueBuild(string projectName, Uri buildDefinitionUri);
        void OpenProcessFileLocation(Uri buildDefinitionUri);
        
        void TfsConnect();
        void NewBuildDefinition(string projectName);
        void OpenControllerAgentManager(string projectName);
        void OpenQualityManager(string projectName);
        void OpenBuildSecurityDialog(string projectName, string projectUri);
        void OpenBuildDefinitionSecurityDialog(string projectName, string projectUri, string definitionName, string definitionUri);

        void NewWorkItem(TfsTeamProjectCollection projectCollection, string projectName, string typeName);
        void GoToWorkItem();
        void OpenSecurityItemDialog(QueryItem queryItem);
        void ResolveConflicts(Workspace workspace, string[] paths, bool recursive, bool afterCheckin);
        void CompareChangesetChangesWithLatestVersions(IList<PendingChange> pendingChanges);
        void CompareChangesetChangesWithWorkspaceVersions(Workspace workspace, IList<PendingChange> pendingChanges);
        void UndoChanges(Workspace workspace, IList<PendingChange> pendingChanges);
        void View(Workspace workspace, IList<PendingChange> pendingChanges);
        
        void ShowWorkItemsAreasAndIterationsDialog(TfsTeamProjectCollection tfsTeamProjectCollection, string projectName, string projectUri);
        void ShowPortalSettings(TfsTeamProjectCollection tfsTeamProjectCollection, string projectName, string projectUri);
        void ShowSourceControlSettings();
        void ShowSourceControlCollectionSettings();
        void DisconnectFromTfs();
        void NewTeamProject();
        void ShowProcessTemplateManager(TfsTeamProjectCollection tfsTeamProjectCollection);
        string[] GetSolutionFilePaths();
        Workspace ActiveWorkspace { get; }
        Solution Solution { get; }
    }
}
