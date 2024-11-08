@echo off
rmdir /Q "EasyAssetManager.Share"
rem rmdir /Q "Newtonsoft.Json"
mklink /H/J "EasyAssetManager.Share" "%~dp0..\EasyAssetManager.Share\src"
rem mklink /H/J "Newtonsoft.Json" "%~dp0..\..\Newtonsoft.Json\Src\Newtonsoft.Json"