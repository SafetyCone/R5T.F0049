using System;

using Microsoft.Extensions.Logging;

using R5T.T0132;


namespace R5T.F0049
{
	[FunctionalityMarker]
	public partial interface ISolutionOperator : IFunctionalityMarker
	{
		public string Create_Solution_SourceDirectoryPath(
			string sourceDirectoryPath,
			string solutionName,
			ILogger logger)
		{
			var solutionDirectoryPath = Instances.SolutionPathsOperator.GetSolutionDirectoryPath_FromRepositorySourceDirectoryPath(sourceDirectoryPath);

			var solutionFilePath = this.Create_Solution_SolutionDirectoryPath(
				solutionDirectoryPath,
				solutionName,
				logger);

			return solutionFilePath;
		}

		public string Create_Solution_SolutionDirectoryPath(
			string solutionDirectoryPath,
			string solutionName,
			ILogger logger)
		{
			var solutionFilePath = Instances.SolutionPathsOperator.GetSolutionFilePath(
				solutionDirectoryPath,
				solutionName);

			logger.LogInformation($"Creating solution file...{Environment.NewLine}\t{solutionFilePath}");

			Instances.SolutionFileGenerator.CreateNew(solutionFilePath);

			logger.LogInformation($"Created script solution file.{Environment.NewLine}\t{solutionFilePath}");

			return solutionFilePath;
		}

		/// <summary>
		/// Chooses <see cref="Create_Solution_SolutionDirectoryPath(string, string, ILogger)"/> as the default.
		/// </summary>
		public string Create_Solution(
			string solutionDirectoryPath,
			string solutionName,
			ILogger logger)
		{
			var solutionFilePath = this.Create_Solution_SolutionDirectoryPath(
				solutionDirectoryPath,
				solutionName,
				logger);

			return solutionFilePath;
		}

		/// <summary>
		/// Returns the project file path.
		/// </summary>
		public string CreateLibraryProjectInExistingSolution(
			string solutionFilePath,
			string projectName,
			string projectDescription)
		{
			// Check that solution file exists.
			var solutionFileExists = Instances.FileSystemOperator.Exists_File(solutionFilePath);
			if (!solutionFileExists)
			{
				throw new Exception($"Solution file does not exist.{Environment.NewLine}\t{solutionFilePath}");
			}

			// Get project file path.
			var solutionDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(solutionFilePath);

			var projectDirectoryName = Instances.ProjectDirectoryNameOperator.GetProjectDirectoryName_FromProjectName(projectName);
			var projectDirectoryPath = Instances.PathOperator.GetDirectoryPath(
				solutionDirectoryPath,
				projectDirectoryName);

			var projectFileName = Instances.ProjectFileNameOperator.GetProjectFileName_FromProjectName(projectName);
			var projectFilePath = Instances.PathOperator.GetFilePath(
				projectDirectoryPath,
				projectFileName);

			// Check that project file does not already exist.
			var projectFileExists = Instances.FileSystemOperator.Exists_File(projectFilePath);
			if (projectFileExists)
			{
				throw new Exception($"Project file already exists.{Environment.NewLine}\t{projectFilePath}");
			}

			var namespaceName = Instances.ProjectNamespacesOperator.GetDefaultNamespaceName_FromProjectName(projectName);

			// Ensure the project directory exists.
			Instances.FileSystemOperator.CreateDirectory_OkIfAlreadyExists(projectDirectoryPath);

			// Create the project file.
			Instances.ProjectFileGenerator.CreateNewLibrary(projectFilePath);

			Instances.ProjectOperator.SetupProject_Library(
				projectFilePath,
				projectDescription,
				projectName,
				namespaceName);

			return projectFilePath;
		}

		public string CreateConsoleProjectInExistingSolution(
			string solutionFilePath,
			string projectName,
			string projectDescription)
		{
			// Check that solution file exists.
			var solutionFileExists = Instances.FileSystemOperator.Exists_File(solutionFilePath);
			if (!solutionFileExists)
			{
				throw new Exception($"Solution file does not exist.{Environment.NewLine}\t{solutionFilePath}");
			}

			// Get project file path.
			var solutionDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(solutionFilePath);

			var projectDirectoryName = Instances.ProjectDirectoryNameOperator.GetProjectDirectoryName_FromProjectName(projectName);
			var projectDirectoryPath = Instances.PathOperator.GetDirectoryPath(
				solutionDirectoryPath,
				projectDirectoryName);

			var projectFileName = Instances.ProjectFileNameOperator.GetProjectFileName_FromProjectName(projectName);
			var projectFilePath = Instances.PathOperator.GetFilePath(
				projectDirectoryPath,
				projectFileName);

			// Check that project file does not already exist.
			var projectFileExists = Instances.FileSystemOperator.Exists_File(projectFilePath);
			if (projectFileExists)
			{
				throw new Exception($"Project file already exists.{Environment.NewLine}\t{projectFilePath}");
			}

			var namespaceName = Instances.ProjectNamespacesOperator.GetDefaultNamespaceName_FromProjectName(projectName);

			// Ensure the project directory exists.
			Instances.FileSystemOperator.CreateDirectory_OkIfAlreadyExists(projectDirectoryPath);

			// Create the project file.
			Instances.ProjectFileGenerator.CreateNewConsole(projectFilePath);

			Instances.ProjectOperator.SetupProject_Console(
				projectFilePath,
				projectDescription,
				projectName,
				namespaceName);

			return projectFilePath;
		}
	}
}