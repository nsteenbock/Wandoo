using Wandoo.Logic.CodeAnalysis.Model;

namespace Wandoo.Logic.CodeAnalysis
{
	public interface IProjectFileAnalyzer
	{
		ProjectInfo Analyze(string projectFilePath);
	}
}
