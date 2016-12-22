@echo off

setlocal

set nuget_exe=C:\Dev\NuGet\bin\NuGet.exe
set nuspec_files=*.nuspec

pushd ..\..

echo Copying files...

for /R %%f in (%nuspec_files%) do (
    %nuget_exe% pack "%%f" -symbols
)

:end

popd

endlocal

pause
