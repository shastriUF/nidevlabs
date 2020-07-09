﻿using System.Globalization;
using System.Windows.Media;
using NationalInstruments;
using NationalInstruments.Core;
using NationalInstruments.ProjectExplorer;
using NationalInstruments.SourceModel.Envoys;
using ExamplePlugins.ExampleDocument.Model;

namespace ExamplePlugins.ExampleDocument.Shell
{
    /// <summary>
    /// Envoy service factory
    /// </summary>
    [ExportEnvoyServiceFactory(typeof(IProjectItemInfo))]
    [BindsToModelDefinitionType(TextDocumentDefinition.ElementName, ExamplePluginsNamespaceSchema.ParsableNamespaceName)]
    public class TextDocumentProjectExplorerServiceFactory : EnvoyServiceFactory
    {
        /// <inheritdoc />
        protected override EnvoyService CreateService()
        {
            return Host.CreateInstance<TextDocumentProjectExplorerService>();
        }
    }

    /// <summary>
    /// This is a "ProjectSerice" which provides information about our definition used to display it in
    /// the "Project Explorer Window" which is the project tree view.
    /// If a file does not have a ProjectExplorerService it will not be shown in the project tree.
    /// </summary>
    public class TextDocumentProjectExplorerService : ProjectItemInfoSourceFileReferenceDefaultService
    {
        public static ImageSource DefaultIcon = ResourceHelpers.LoadLocalizedBitmapImage(typeof(TextDocumentProjectExplorerService), "Resources/Paper.png", CultureInfo.CurrentCulture);

        #region IProjectItemInfo

        /// <summary>
        /// Returns the icon to use in the project tree
        /// </summary>
        public override PlatformImage Icon
        {
            get
            {
                return DefaultIcon;
            }
        }

        #endregion
    }
}
