using System;


namespace R5T.F0049
{
	public class SolutionOperator : ISolutionOperator
	{
		#region Infrastructure

	    public static ISolutionOperator Instance { get; } = new SolutionOperator();

	    private SolutionOperator()
	    {
        }

	    #endregion
	}
}