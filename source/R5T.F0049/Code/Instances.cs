using System;


namespace R5T.F0049
{
    public static class Instances
    {
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static L0066.IPathOperator PathOperator => L0066.PathOperator.Instance;
        public static F0052.IProjectDirectoryNameOperator ProjectDirectoryNameOperator => F0052.ProjectDirectoryNameOperator.Instance;
        public static F0052.IProjectFileNameOperator ProjectFileNameOperator => F0052.ProjectFileNameOperator.Instance;
        public static F0020.IProjectFileGenerator ProjectFileGenerator => F0020.ProjectFileGenerator.Instance;
        public static F0040.F000.IProjectNamespacesOperator ProjectNamespacesOperator => F0040.F000.ProjectNamespacesOperator.Instance;
        public static F0051.IProjectOperator ProjectOperator => F0051.ProjectOperator.Instance;
        public static F0024.ISolutionFileGenerator SolutionFileGenerator => F0024.SolutionFileGenerator.Instance;
        public static F0050.ISolutionPathsOperator SolutionPathsOperator => F0050.SolutionPathsOperator.Instance;
    }
}