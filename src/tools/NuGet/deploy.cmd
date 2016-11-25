@echo off

setlocal

set local_packages_dir=C:\Dev\NuGet\packages
set nupkg_files=*.nupkg

pushd ..\..

if not exist %local_packages_dir% mkdir %local_packages_dir%

echo Copying files...

for /R %%f in (Kindgom.AspNet.WebApi.Castle.Windsor\%nupkg_files%) do (
    xcopy "%%f" %local_packages_dir% /Y
)

:end

popd

endlocal

pause
