@echo off

setlocal enableDelayedExpansion

for %%i in ("%~dp0") do set "loadFolder=%%~i"
set folderLocation=!loadFolder!Source

set source=%folderLocation%
set target=!loadFolder!Archive

echo "Backup start"

if not exist "%target%" (
	md "%target%"
)

set /a n=1
for /r "%source%" %%F in (*) do if "%%~dpF" neq "%target%\" (
	if exist "%target%\%%~nxF" (
			
			set "full=%%~F"
			set "name=%%~nF"
			set "ext=%%~xF"
			
			echo "Backup file:%%~nxF"
			
			:loop
			if exist "%target%/!name!_%n%!ext!" (
			set /a n=n+1
			goto :loop
			)
			
			copy "!full!" "%target%/!name!_%n%!ext!" >nul

	) else copy "%%F" "%target%" >nul
)
endlocal

echo "Backup done"
pause
