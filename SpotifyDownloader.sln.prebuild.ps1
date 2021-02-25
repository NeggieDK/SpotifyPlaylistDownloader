param($action, $solutionConfig)
# uncomment to debug issues with passed parameters, workingdir etc
"Running prebuild script with action:[$action] solutionConfig:[$solutionConfig]!"
#Get-Location
#$MyInvocation.InvocationName
#$MyInvocation.BoundParameters
#$MyInvocation.UnboundArguments

#for performance reasons we do code generation and nuget restore only on REBUILD
#other actions that can be hooked are BUILD and CLEAN
if($action -ne "REBUILD"){return}
"generate shared code"
"nuget restore SpotifyDownloader.sln"
"update lib links"