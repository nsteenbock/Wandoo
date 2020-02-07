using Doozr.Common.Isolation.Io;
using NSubstitute;
using Xunit;

namespace Wandoo.Logic.CodeAnalysis.Tests
{
	public class ClassicProjectFileAnalyzerTests
	{
		[Fact]
		public void Analyze_FileWithRootNamespace()
		{
			var projectFileString =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""15.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProjectGuid>{596CCD8A-D352-4DB0-A085-5E6CE4912484}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>Wandoo.Logic.CodeAnalysis.Tests</RootNamespace>
    <AssemblyName>Wandoo.Logic.CodeAnalysis.Tests</AssemblyName>
    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <Deterministic>true</Deterministic>
  </PropertyGroup>
</Project>";

			var filesystem = Substitute.For<IFilesystem>();
			filesystem.ReadAllText("namedoesnotmatter")
				.Returns(projectFileString);

			var sut = new ClassicProjectFileAnalyzer(filesystem);

			var result = sut.Analyze(@"namedoesnotmatter");
		}
	}
}
