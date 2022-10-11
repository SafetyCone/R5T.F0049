using System;


namespace R5T.F0049
{
	public class SolutionGenerator : ISolutionGenerator
	{
		#region Infrastructure

	    public static ISolutionGenerator Instance { get; } = new SolutionGenerator();

	    private SolutionGenerator()
	    {
        }

	    #endregion
	}
}