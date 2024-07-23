"%WIX%bin\candle.exe" HLService.wix dlguser.wix WixUI_InstallDir.wxs
"%WIX%bin\light.exe" -o HLServiceInstaller.msi  -ext WixUIExtension HLService.wixobj dlguser.wixobj WixUI_InstallDir.wixobj
