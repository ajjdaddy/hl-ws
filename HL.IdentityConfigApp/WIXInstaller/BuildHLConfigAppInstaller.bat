"%WIX%bin\candle.exe" HLConfigApp.wix dlguser.wix WixUI_InstallDir.wxs
"%WIX%bin\light.exe" -o HLConfigAppInstaller.msi  -ext WixUIExtension HLConfigApp.wixobj dlguser.wixobj WixUI_InstallDir.wixobj
