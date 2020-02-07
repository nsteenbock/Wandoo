using Doozr.Common.Isolation.Io;
using System.Xml.Linq;
using Wandoo.Logic.CodeAnalysis.Model;

namespace Wandoo.Logic.CodeAnalysis
{
	public abstract class ProjectFileAnalyzer : IProjectFileAnalyzer
	{
		private readonly IFilesystem filesystem;

		public ProjectFileAnalyzer(IFilesystem filesystem)
		{
			this.filesystem = filesystem;
		}

		public ProjectInfo Analyze(string projectFilePath)
		{
			XDocument projectFileXml = XDocument.Parse(filesystem.ReadAllText(projectFilePath));
			return InternalAnalyze(projectFileXml);
		}

		protected abstract ProjectInfo InternalAnalyze(XDocument projectFileXml);
	}
}
