; A-VNC.nsi
;
; This script is based on example2.nsi,
; It will install A-VNC into a directory that the user selects,

;--------------------------------

; The name of the installer
Name "A-VNC 1.5.1"

; The file to write
OutFile "AVNC-Installer.exe"

; The default installation directory
InstallDir $PROGRAMFILES\AVNC

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "SOFTWARE\AVNC" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "A-Vnc (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put files there
  File "AVNC.application"
  File "AVNC.exe"
  File "AVNC.exe.manifest"
  File "AVNC.pdb"
  File "login.htm"
  File "script.js"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\AVNC "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AVNC" "DisplayName" "AVNC"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AVNC" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AVNC" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AVNC" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\A-VNC"
  CreateShortCut "$SMPROGRAMS\A-VNC\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\A-VNC\A-VNC (server).lnk" "$INSTDIR\AVNC.exe" "" "$INSTDIR\AVNC.exe" 0
  
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AVNC"
  DeleteRegKey HKLM SOFTWARE\AVNC

  ; Remove files and uninstaller
  Delete $INSTDIR\AVNC.application
  Delete $INSTDIR\AVNC.exe
  Delete $INSTDIR\AVNC.exe.manifest
  Delete $INSTDIR\AVNC.pdb
  Delete $INSTDIR\login.htm
  Delete $INSTDIR\script.js
  Delete $INSTDIR\uninstall.exe

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\A-VNC\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\A-VNC"
  RMDir "$INSTDIR"

SectionEnd
