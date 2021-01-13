"..\..\oqtane.framework\oqtane.package\nuget.exe" pack BitCoin.Prices.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
