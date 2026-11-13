# Run from the GradesStats folder:  .\run_tests.ps1
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
dotnet build -v q | Out-Null
$ok = 0; $n = 0
foreach ($in in Get-ChildItem .\tests\*.in | Sort-Object Name) {
    $n++
    $expFile = $in.FullName -replace '\.in$', '.out'
    $exp = (Get-Content $expFile -Encoding UTF8) -join "`n"
    $act = ((Get-Content $in.FullName | dotnet run --no-build) -join "`n")
    if ($act.Trim() -eq $exp.Trim()) { $ok++; $res = 'PASS' } else { $res = 'FAIL' }
    "{0}: {1}" -f $in.Name, $res
    if ($res -eq 'FAIL') { "expected:`n$exp`nactual:`n$act" }
}
"Passed $ok of $n"
