@echo off
:: Install SAP Crystal Reports Runtime Engine for .NET Framework (64-bit) SP36
:: Right-click this file → Run as administrator

net session >nul 2>&1
if %errorLevel% neq 0 (
    echo Requesting Administrator privileges...
    powershell -Command "Start-Process -FilePath '%~f0' -Verb RunAs"
    exit /b
)

cd /d "%~dp0"
echo.
echo Installing Crystal Reports Runtime 64-bit SP36...
echo This may take a few minutes.
echo.

msiexec /i "%~dp0CR13SP36MSI64.msi" /qb /norestart
set ERR=%ERRORLEVEL%

echo.
if %ERR%==0 (
    echo SUCCESS: Crystal Reports Runtime installed.
) else if %ERR%==3010 (
    echo SUCCESS: Installed. A reboot may be required ^(exit 3010^).
) else (
    echo FAILED with exit code %ERR%.
    echo Make sure you ran this as Administrator.
)
echo.
pause
