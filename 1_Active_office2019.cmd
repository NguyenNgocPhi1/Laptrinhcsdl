@echo off
title Activate Microsoft Office 2019 (ALL versions) for FREE - MSGuides.com
cls
echo ============================================================================
@echo off
(if exist "%ProgramFiles(x86)%\Microsoft Office\Office16\ospp.vbs" cd /d "%ProgramFiles(x86)%\Microsoft Office\Office16")
(for /f %%x in ('dir /b ..\root\Licenses16\ProPlus2019VL*.xrm-ms') do cscript ospp.vbs /inslic:"..\root\Licenses16\%%x" >nul)
cscript //nologo slmgr.vbs /ckms >nul
cscript //nologo ospp.vbs /setprt:1688 >nul
cscript //nologo ospp.vbs /unpkey:6MWKP >nul
set i=1
cscript //nologo ospp.vbs /inpkey:NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP >nul
:skms
if %i% GTR 10 goto busy
if %i% EQU 1 set KMS=kms8.MSGuides.com
if %i% EQU 2 set KMS=s9.us.to
if %i% EQU 3 set KMS=s8.uk.to
if %i% GTR 3 goto ato
cscript //nologo ospp.vbs /sethst:%KMS% >nul
:ato
cscript //nologo ospp.vbs /act | find /i "successful" || (
set /a i+=1 
goto skms)
goto halt

:busy
echo ==================&echo.&echo Sorry, the server is busy and can't respond to your request. Please try again.&echo.
:halt
echo Finish
pause >nul