using System;

using R5T.F0000;
using R5T.F0002;
using R5T.F0020;
using R5T.F0024;
using R5T.F0040.F000;
using R5T.F0050;
using R5T.F0051;
using R5T.F0052;


namespace R5T.F0049
{
    public static class Instances
    {
        public static F0000.IFileSystemOperator FileSystemOperator { get; } = F0000.FileSystemOperator.Instance;
        public static F0002.IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static IProjectDirectoryNameOperator ProjectDirectoryNameOperator { get; } = F0052.ProjectDirectoryNameOperator.Instance;
        public static IProjectFileNameOperator ProjectFileNameOperator { get; } = F0052.ProjectFileNameOperator.Instance;
        public static IProjectFileGenerator ProjectFileGenerator { get; } = F0020.ProjectFileGenerator.Instance;
        public static IProjectNamespacesOperator ProjectNamespacesOperator { get; } = F0040.F000.ProjectNamespacesOperator.Instance;
        public static F0051.IProjectOperator ProjectOperator { get; } = F0051.ProjectOperator.Instance;
        public static ISolutionFileGenerator SolutionFileGenerator { get; } = F0024.SolutionFileGenerator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = F0050.SolutionPathsOperator.Instance;
    }
}