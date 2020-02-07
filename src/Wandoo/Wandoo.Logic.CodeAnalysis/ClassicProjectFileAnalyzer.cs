using Doozr.Common.Isolation.Io;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Wandoo.Logic.CodeAnalysis.Model;

namespace Wandoo.Logic.CodeAnalysis
{
	public class ClassicProjectFileAnalyzer : ProjectFileAnalyzer, IClassicProjectFileAnalyzer
	{
		public ClassicProjectFileAnalyzer(IFilesystem filesystem) : base(filesystem)
		{
		}

		protected override ProjectInfo InternalAnalyze(XDocument projectFileXml)
		{
			var result = new ProjectInfo();
			XmlNamespaceManager xnm = new XmlNamespaceManager(new NameTable());
			xnm.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003");
			result.RootNamespace = projectFileXml.XPathSelectElement("./x:Project/x:PropertyGroup/x:RootNamespace", xnm).Value;
			result.AssemblyName = projectFileXml.XPathSelectElement("./x:Project/x:PropertyGroup/x:AssemblyName", xnm).Value;

			return result;
		}
	}
}
