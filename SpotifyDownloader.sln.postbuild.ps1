param($action, $solutionConfig, $succeded, $modified, $canceled)
# uncomment to debug issues with passed parameters, workingdir etc
"Running postbuild script with action:[$action] solutionConfig:[$solutionConfig]!"
#Get-Location
#$MyInvocation.InvocationName
#$MyInvocation.BoundParameters
#$MyInvocation.UnboundArguments
"deploy, pack, publish package"