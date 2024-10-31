@echo off
setlocal enabledelayedexpansion

REM 현재 디렉토리 저장
set "ORIGINAL_DIR=%CD%"

REM ExcelParsher.exe 실행
echo Running ExcelParsher.exe...
cd /d "%~dp0ExcelParsher\ExcelParsher\bin\Release"
if exist "ExcelParsher.exe" (
    ExcelParsher.exe
    if !ERRORLEVEL! neq 0 (
        echo Error: ExcelParsher.exe failed to execute. Error code: !ERRORLEVEL!
        goto :error
    )
) else (
    echo Error: ExcelParsher.exe not found in the current directory.
    goto :error
)

REM 원래 디렉토리로 돌아가기
cd /d "%ORIGINAL_DIR%"

REM .cs 파일 복사
echo Copying .cs files...
if exist "ExcelDataTable" (
    if not exist "..\Client\Assets\ExcelParsher" mkdir "..\Client\Assets\ExcelParsher"
    xcopy "ExcelDataTable\*.cs" "..\Client\Assets\ExcelParsher" /Y /I
    if !ERRORLEVEL! neq 0 goto :copy_error
) else (
    echo Error: ExcelDataTable directory not found.
    goto :error
)

REM .xlsx 파일 복사
echo Copying .xlsx files...
if exist "ExcelDataTable" (
    if not exist "..\Client\Assets\ExcelDataTable" mkdir "..\Client\Assets\ExcelDataTable"
    xcopy "ExcelDataTable\*.xlsx" "..\Client\Assets\ExcelDataTable" /Y /I
    if !ERRORLEVEL! neq 0 goto :copy_error
) else (
    echo Error: ExcelDataTable directory not found.
    goto :error
)

echo All operations completed successfully.
goto :eof

:copy_error
echo An error occurred during file copying. Error level: !ERRORLEVEL!
goto :error

:error
echo An error occurred. Exiting with error level !ERRORLEVEL!.
pause
exit /b !ERRORLEVEL!

:eof
endlocal