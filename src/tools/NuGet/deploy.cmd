@echo off

setlocal

set local_packages_dir=C:\Dev\NuGet\packages
set nupkg_files=*.nupkg

pushd ..\..

if not exist Kindgom.AspNet.WebApi.Castle.Windsor\%nupkg_files% goto end

if not exist %local_packages_dir% mkdir %local_packages_dir%

echo Copying files...
xcopy "Kindgom.AspNet.WebApi.Castle.Windsor\%nupkg_files%" "%local_packages_dir%\%nupkg_files%" /Y

:end

popd

endlocal

pause
