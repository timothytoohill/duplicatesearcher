!define REQUIRED_DOTNET_VERSION "2"
; icons must be Microsoft .ICO files
!define icon "DuplicateSearcher.ico"
!define MUI_ICON "DuplicateSearcher.ico"
!define MUI_UNICON "DuplicateSearcher.ico"

# DotNET and MSI version checking macro.
# Written by AnarkiNet(AnarkiNet@gmail.com) originally, modified by eyal0 (for use in http://www.sourceforge.net/projects/itwister)
# MSI check code based on http://www.codeproject.com/useritems/NSIS.asp
# Downloads the MSI version 3.1 and runs it if the user does not have the correct version.
# Downloads and runs the Microsoft .NET Framework version 2.0 Redistributable and runs it if the user does not have the correct version.
# To use, call the macro with a string:
# Example: non real version numbers
# !insertmacro CheckDotNET "2"
# !insertmacro CheckDotNET "2.0.9"
# (Version 2.0.9 is less than version 2.0.10.)
# Example: latest real version number at time of writing
# !insertmacro CheckDotNET "2.0.50727"
# All register variables are saved and restored by CheckDotNet
# No output
 
!macro CheckDotNET DotNetReqVer
# !define DOTNET_URL "http://www.microsoft.com/downloads/info.aspx?na=90&p=&SrcDisplayLang=en&SrcCategoryId=&SrcFamilyId=0856eacb-4362-4b0d-8edd-aab15c5e04f5&u=http%3a%2f%2fdownload.microsoft.com%2fdownload%2f5%2f6%2f7%2f567758a3-759e-473e-bf8f-52154438565a%2fdotnetfx.exe"
  !define DOTNET_URL "http://download.microsoft.com/download/2/0/E/20E90413-712F-438C-988E-FDAA79A8AC3D/dotnetfx35.exe"
  !define MSI31_URL "http://download.microsoft.com/download/1/4/7/147ded26-931c-4daf-9095-ec7baf996f46/WindowsInstaller-KB893803-v2-x86.exe"
 
  DetailPrint "Checking your .NET Framework version..."
  ;callee register save
  Push $0
  Push $1
  Push $2
  Push $3
  Push $4
  Push $5
  Push $6 ;backup of intsalled ver
  Push $7 ;backup of DoNetReqVer
 
 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
 ;                               MSI                                          ;
 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
  GetDLLVersion "$SYSDIR\msi.dll" $R0 $R1
  IntOp $R2 $R0 / 0x00010000 ; $R2 now contains major version
  IntOp $R3 $R0 & 0x0000FFFF ; $R3 now contains minor version
  IntOp $R4 $R1 / 0x00010000 ; $R4 now contains release
  IntOp $R5 $R1 & 0x0000FFFF ; $R5 now contains build
  StrCpy $0 "$R2.$R3.$R4.$R5" ; $0 now contains string like "1.2.0.192"
 
  ${If} $R2 < '3'
    ;options
    SetOutPath "$TEMP"
    SetOverwrite on
 
    MessageBox MB_YESNOCANCEL|MB_ICONEXCLAMATION \
    "Your MSI version: $0.$\nRequired Version: 3 or greater.$\nDownload MSI version from www.microsoft.com?" \
    /SD IDYES IDYES DownloadMSI IDNO NewMSI
    goto GiveUpDotNET ;IDCANCEL
 
  ${Else}
 
    DetailPrint "MSI3.1 already installed"
    goto NewMSI
  ${EndIf}
 
DownloadMSI:
  DetailPrint "Beginning download of MSI3.1."
  NSISDL::download ${MSI31_URL} "$TEMP\WindowsInstaller-KB893803-v2-x86.exe"
  DetailPrint "Completed download."
  Pop $0
  ${If} $0 == "cancel"
    MessageBox MB_YESNO|MB_ICONEXCLAMATION \
    "Download cancelled.  Continue Installation?" \
    IDYES NewMSI IDNO GiveUpDotNET
  ${ElseIf} $0 != "success"
    MessageBox MB_YESNO|MB_ICONEXCLAMATION \
    "Download failed:$\n$0$\n$\nContinue Installation?" \
    IDYES NewMSI IDNO GiveUpDotNET
  ${EndIf}
  DetailPrint "Pausing installation while downloaded MSI3.1 installer runs."
  ExecWait '$TEMP\WindowsInstaller-KB893803-v2-x86.exe /quiet /norestart' $0
  DetailPrint "Completed MSI3.1 install/update. Exit code = '$0'. Removing MSI3.1 installer."
  Delete "$TEMP\WindowsInstaller-KB893803-v2-x86.exe"
  DetailPrint "MSI3.1 installer removed."
  goto NewMSI
 
NewMSI:
  DetailPrint "MSI3.1 installation done. Proceeding with remainder of installation."
 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
 
 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
 ;                                  NetFX                                     ;
 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
  StrCpy $7 ${DotNetReqVer}
 
  System::Call "mscoree::GetCORVersion(w .r0, i ${NSIS_MAX_STRLEN}, *i r2r2) i .r1 ?u"
 
  ${If} $0 == 0
  	DetailPrint ".NET Framework not found, download is required for program to run."
    Goto NoDotNET
  ${EndIf}
 
  ;at this point, $0 has maybe v2.345.678.
  StrCpy $0 $0 $2 1 ;remove the starting "v", $0 has the installed version num as a string
  StrCpy $6 $0
  StrCpy $1 $7 ;$1 has the requested verison num as a string
 
  ;MessageBox MB_OKCANCEL "found $0" IDCANCEL GiveUpDotNET
 
  ;MessageBox MB_OKCANCEL "looking for $1" IDCANCEL GiveUpDotNET
 
  ;now let's compare the versions, installed against required <part0>.<part1>.<part2>.
  ${Do}
    StrCpy $2 "" ;clear out the installed part
    StrCpy $3 "" ;clear out the required part
 
    ${Do}
      ${If} $0 == "" ;if there are no more characters in the version
        StrCpy $4 "." ;fake the end of the version string
      ${Else}
        StrCpy $4 $0 1 0 ;$4 = character from the installed ver
        ${If} $4 != "."
          StrCpy $0 $0 ${NSIS_MAX_STRLEN} 1 ;remove that first character from the remaining
        ${EndIf}
      ${EndIf}
 
      ${If} $1 == ""  ;if there are no more characters in the version
        StrCpy $5 "." ;fake the end of the version string
      ${Else}
        StrCpy $5 $1 1 0 ;$5 = character from the required ver
        ${If} $5 != "."
          StrCpy $1 $1 ${NSIS_MAX_STRLEN} 1 ;remove that first character from the remaining
        ${EndIf}
      ${EndIf}
      ;MessageBox MB_OKCANCEL "installed $2,$4,$0 required $3,$5,$1" IDCANCEL GiveUpDotNET
      ${If} $4 == "."
      ${AndIf} $5 == "."
        ${ExitDo} ;we're at the end of the part
      ${EndIf}
 
      ${If} $4 == "." ;if we're at the end of the current installed part
        StrCpy $2 "0$2" ;put a zero on the front
      ${Else} ;we have another character
        StrCpy $2 "$2$4" ;put the next character on the back
      ${EndIf}
      ${If} $5 == "." ;if we're at the end of the current required part
        StrCpy $3 "0$3" ;put a zero on the front
      ${Else} ;we have another character
        StrCpy $3 "$3$5" ;put the next character on the back
      ${EndIf}
    ${Loop}
    ;MessageBox MB_OKCANCEL "finished parts: installed $2,$4,$0 required $3,$5,$1" IDCANCEL GiveUpDotNET
 
    ${If} $0 != "" ;let's remove the leading period on installed part if it exists
      StrCpy $0 $0 ${NSIS_MAX_STRLEN} 1
    ${EndIf}
    ${If} $1 != "" ;let's remove the leading period on required part if it exists
      StrCpy $1 $1 ${NSIS_MAX_STRLEN} 1
    ${EndIf}
 
    ;$2 has the installed part, $3 has the required part
    ${If} $2 S< $3
      IntOp $0 0 - 1 ;$0 = -1, installed less than required
      ${ExitDo}
    ${ElseIf} $2 S> $3
      IntOp $0 0 + 1 ;$0 = 1, installed greater than required
      ${ExitDo}
    ${ElseIf} $2 == ""
    ${AndIf} $3 == ""
      IntOp $0 0 + 0 ;$0 = 0, the versions are identical
      ${ExitDo}
    ${EndIf} ;otherwise we just keep looping through the parts
  ${Loop}
 
  ${If} $0 < 0
    DetailPrint ".NET Framework Version found: $6, but is older than the required version: $7"
    Goto OldDotNET
  ${Else}
    DetailPrint ".NET Framework Version found: $6, equal or newer to required version: $7."
    Goto NewDotNET
  ${EndIf}
 
NoDotNET:
    MessageBox MB_YESNOCANCEL|MB_ICONEXCLAMATION \
    ".NET Framework not installed.$\nRequired Version: $7 or greater.$\nDownload .NET Framework version from www.microsoft.com?" \
    /SD IDYES IDYES DownloadDotNET IDNO NewDotNET
    goto GiveUpDotNET ;IDCANCEL
OldDotNET:
    MessageBox MB_YESNOCANCEL|MB_ICONEXCLAMATION \
    "Your .NET Framework version: $6.$\nRequired Version: $7 or greater.$\nDownload .NET Framework version from www.microsoft.com?" \
    /SD IDYES IDYES DownloadDotNET IDNO NewDotNET
    goto GiveUpDotNET ;IDCANCEL
 
DownloadDotNET:
  DetailPrint "Beginning download of latest .NET Framework version."
  NSISDL::download ${DOTNET_URL} "$TEMP\dotnetfx.exe"
  DetailPrint "Completed download."
  Pop $0
  ${If} $0 == "cancel"
    MessageBox MB_YESNO|MB_ICONEXCLAMATION \
    "Download cancelled.  Continue Installation?" \
    IDYES NewDotNET IDNO GiveUpDotNET
  ${ElseIf} $0 != "success"
    MessageBox MB_YESNO|MB_ICONEXCLAMATION \
    "Download failed:$\n$0$\n$\nContinue Installation?" \
    IDYES NewDotNET IDNO GiveUpDotNET
  ${EndIf}
  DetailPrint "Pausing installation while downloaded .NET Framework installer runs."
  ExecWait '$TEMP\dotnetfx.exe /q /c:"install /q"'
  DetailPrint "Completed .NET Framework install/update. Removing .NET Framework installer."
  Delete "$TEMP\dotnetfx.exe"
  DetailPrint ".NET Framework installer removed."
  goto NewDotNet
 
GiveUpDotNET:
  Abort "Installation cancelled by user."
 
NewDotNET:
  DetailPrint "Proceeding with remainder of installation."
  Pop $7
  Pop $6
  Pop $5
  Pop $4
  Pop $3
  Pop $2
  Pop $1
  Pop $0
!macroend


;--------------------------------
;modern ui
!include "MUI.nsh"

; The name of the installer
Name "DuplicateSearcher"

; The file to write
OutFile "DS_Setup.exe"

; The default installation directory
InstallDir $PROGRAMFILES\DuplicateSearcher

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\DuplicateSearcher" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------
; inteface settings
!define MUI_ABORTWARNING

; Pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

; finish page
# These indented statements modify settings for MUI_PAGE_FINISH
!define MUI_FINISHPAGE_NOAUTOCLOSE
!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_CHECKED
!define MUI_FINISHPAGE_RUN_TEXT "Run DuplicateSearcher Now"
!define MUI_FINISHPAGE_RUN_FUNCTION "LaunchApp"
!define MUI_FINISHPAGE_SHOWREADME_NOTCHECKED
!define MUI_FINISHPAGE_SHOWREADME $INSTDIR\ReadMe.txt
!insertmacro MUI_PAGE_FINISH

; uninstall pages
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH
;--------------------------------

;Languages
!insertmacro MUI_LANGUAGE "English"

; The stuff to install
Section "DuplicateSearcher Executables (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "..\DuplicateSearcher\bin\Release\dsc.exe"
  File "..\DuplicateSearcher\bin\Release\dsgui.exe"
  File "..\DuplicateSearcher\ReadMe.txt"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\DuplicateSearcher "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\DuplicateSearcher" "DisplayName" "DuplicateSearcher"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\DuplicateSearcher" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\DuplicateSearcher" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\DuplicateSearcher" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

  !insertmacro CheckDotNET ${REQUIRED_DOTNET_VERSION}  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"
  SetShellVarContext current

  CreateDirectory "$SMPROGRAMS\DuplicateSearcher"
  CreateShortCut "$SMPROGRAMS\DuplicateSearcher\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\DuplicateSearcher\DuplicateSearcher.lnk" "$INSTDIR\dsgui.exe" "" "$INSTDIR\dsgui.exe" 0
  CreateShortCut "$SMPROGRAMS\DuplicateSearcher\DuplicateSearcher Console.lnk" "cmd.exe" "/k dsc.exe" "cmd.exe" 0
  CreateShortCut "$SMPROGRAMS\DuplicateSearcher\DuplicateSearcher ReadMe.lnk" "$INSTDIR\ReadMe.txt" "" "$INSTDIR\ReadMe.txt" 0
  
SectionEnd

Section "Desktop Shortcut"
  SetShellVarContext current

  CreateShortCut "$DESKTOP\Duplicate Searcher.lnk" "$INSTDIR\dsgui.exe" "" "$INSTDIR\dsgui.exe" 0
SectionEnd
;--------------------------------

; Uninstaller

Section "Uninstall"
  SetShellVarContext all
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\DuplicateSearcher"
  DeleteRegKey HKCU SOFTWARE\DuplicateSearcher
  ; should want to keep this one for licensing
  ; DeleteRegKey HKLM SOFTWARE\DuplicateSearcher

  ; Remove files and uninstaller
  Delete "$INSTDIR\*.*"

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\DuplicateSearcher\*.*"
  Delete "$DESKTOP\Duplicate Searcher.lnk"

  ; Remove directories used
  RMDir "$SMPROGRAMS\DuplicateSearcher"
  RMDir "$INSTDIR"

  SetShellVarContext current
  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\DuplicateSearcher\*.*"
  Delete "$DESKTOP\Duplicate Searcher.lnk"

  ; Remove directories used
  RMDir "$SMPROGRAMS\DuplicateSearcher"

SectionEnd
 
Function LaunchApp
  ExecShell "" "$INSTDIR\dsgui.exe"
FunctionEnd

Function .onInit
 
  ReadRegStr $R0 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\DuplicateSearcher" "UninstallString"
  StrCmp $R0 "" done
 
  MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION "DuplicateSearcher is already installed. $\n$\nClick `OK` to remove the previous version or `Cancel` to cancel this upgrade." IDOK uninst
  Abort
 
;Run the uninstaller
uninst:
  ClearErrors
  ExecWait '$R0 _?=$INSTDIR' ;Do not copy the uninstaller to a temp file
 
  IfErrors no_remove_uninstaller done
    ;You can either use Delete /REBOOTOK in the uninstaller or add some code
    ;here to remove the uninstaller. Use a registry key to check
    ;whether the user has chosen to uninstall. If you are using an uninstaller
    ;components page, make sure all sections are uninstalled.
  no_remove_uninstaller:
 
done:
 
FunctionEnd


!ifdef icon
Icon "${icon}"
UninstallIcon "${icon}"
!endif

