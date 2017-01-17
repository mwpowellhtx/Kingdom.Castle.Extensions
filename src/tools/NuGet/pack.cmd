@echo off

setlocal

:: Expecting NuGet to be added to the System PATH Environment Variable.
set nuget_exe=NuGet.exe
set nuspec_files=*.nuspec

pushd ..\..

echo Packing NuGet packages...

:: TODO: TBD: remember to deal with published NuGet packages, rename and/or delete/obsolete the old name...
call :pack Kingdom.Web.Http.Castle.Windsor
call :pack Kingdom.Web.Mvc.Core
call :pack Kingdom.Web.Mvc.Castle.Windsor

:end

popd

endlocal

pause

exit /b 0

:: Leave the function scope along for purposes of this call.
:pack
echo Packing %* ...
:: The ID can be different AFAIK, but the NuSpec name must be the same as the CSPROJ name.
%nuget_exe% pack %*\%*.csproj -symbols -properties Configuration=Release
exit /b 0
