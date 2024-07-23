"%WIX%bin\candle.exe" HLClientWFApp.wix dlguser.wix WixUI_InstallDir.wxs
"%WIX%bin\light.exe" -o HLClientWFAppInstaller.msi  -ext WixUIExtension HLClientWFApp.wixobj dlguser.wixobj WixUI_InstallDir.wixobj
