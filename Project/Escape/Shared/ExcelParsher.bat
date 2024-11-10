@echo off

cd ExcelParsher\ExcelParsher\bin\Release
ExcelParsher.exe

cd ..\..\..\..\
cd ExcelDataTable

xcopy /y *.xlsx ..\..\Client\Assets\ExcelDataTable
xcopy /y *.cs ..\..\Client\Assets\ExcelParsher

pause