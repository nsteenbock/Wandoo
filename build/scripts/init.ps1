. $PSScriptRoot\config.ps1

nuget sources add -Name "MyAccountFeed" -Source "$Env:NUGET_ACCOUNT_FEED" -UserName "$Env:NUGET_USER" -Password "$Env:NUGET_PWD"

nuget install OpenCover -Version $opencoverversion -OutputDirectory $PsScriptRoot\..\tools
nuget install coveralls.net -Version $coverallsversion -OutputDirectory $PsScriptRoot\..\tools
nuget install xunit.runner.console -Version $xunitversion -OutputDirectory $PsScriptRoot\..\tools
nuget install ReportGenerator -Version $reportgeneratorversion -OutputDirectory $PsScriptRoot\..\tools

Get-ChildItem $PsScriptRoot\..\..\src -Recurse -Filter *.sln | ForEach-Object {
    nuget restore $_.FullName
}