; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "TriviaMaze"
#define MyAppVersion "1.5"
#define MyAppPublisher "TeamQube"
#define MyAppExeName "TriviaMaze.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{78FB2CEC-41E2-4D00-B3DF-574360BBA79C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName=C:/{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Daniel\Documents\GitHub\QubeTriviaMaze\TriviaMaze\bin\Debug\TriviaMaze.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Daniel\Documents\GitHub\QubeTriviaMaze\TriviaMaze\bin\Debug\output.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Daniel\Documents\GitHub\QubeTriviaMaze\TriviaMaze\bin\Debug\questions.db"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Daniel\Documents\GitHub\QubeTriviaMaze\TriviaMaze\bin\Debug\SQLite.NET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Daniel\Documents\GitHub\QubeTriviaMaze\TriviaMaze\bin\Debug\SQLite3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Daniel\Documents\GitHub\QubeTriviaMaze\TriviaMaze\bin\Debug\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

