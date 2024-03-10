@echo off
set projPath=%~dp0..\
set buildPath=%projPath%\bin\Release\net6.0\Toy Robot Library.dll
set solutionPath=%projPath%..\
set outPath=%solutionPath%\Toy Robot Challenge\lib
echo copying %buildPath% to %outPath%
copy "%buildPath%" "%outPath%"