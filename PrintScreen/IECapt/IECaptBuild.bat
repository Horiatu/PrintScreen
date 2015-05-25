midl IECaptComImports.idl
tlbimp IECaptComImports.tlb
aximp %SystemRoot%\system32\shdocvw.dll
csc /r:IECaptComImports.dll /r:AxSHDocVw.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll IECapt.cs
Pause

rem %SystemRoot%\system32;%SystemRoot%;%SystemRoot%\System32\Wbem;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0\;c:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\;c:\Program Files\Microsoft SQL Server\100\Tools\Binn\;c:\Program Files\Microsoft SQL Server\100\DTS\Binn\;C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\x64\;C:\Windows\Microsoft.NET\Framework\v2.0.50727\;C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\bin\;