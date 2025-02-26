#squ_060f5fd3b2e3f5daddd1ec753713ae3d2389d37d

dotnet tool install --global dotnet-sonarscanner
dotnet tool install --global coverlet.console
#dotnet tool install --global coverlet.collector

dotnet test Kata.MarsRover.Services.Test\Kata.MarsRover.Services.Test.csproj --results-directory ../TestResults\ /p:CollectCoverage=true /p:CoverletOutput=../TestResults/ /p:MergeWith=../TestResults/coverlet.json /p:CoverletOutputFormat=\"json,cobertura\"


#begin
dotnet sonarscanner begin /k:"MarsRover" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="squ_060f5fd3b2e3f5daddd1ec753713ae3d2389d37d" /d:sonar.cs.opencover.reportsPaths="**coverage.json" #/d:sonar.coverage.exclusions="**Tests*.cs"

#build
MsBuild.exe Kata.MarsRover.sln #/p:CollectCoverage=true #/t:rebuild -no-incremental 
coverlet .\Kata.MarsRover.Services.Test\bin\Debug\net8.0\Kata.MarsRover.Services.Test.dll --target "dotnet" --targetargs "test --no-build"

#run tests and collect code coverage
dotnet test /p:CoverletOutput="coverage.json"
#dotnet dotcover test --dcReportType=HTML

#end
dotnet sonarscanner end /d:sonar.token="squ_060f5fd3b2e3f5daddd1ec753713ae3d2389d37d"
