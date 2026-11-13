# Run from the t03/Gcd folder:  .\run_tests.ps1
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
dotnet build -v q | Out-Null
$tests = Import-Csv -Delimiter ';' -Encoding UTF8 -Path .\tests.csv
$n = 0; $ok = 0
foreach ($t in $tests) {
    $n++
    $out = ("$($t.a)`n$($t.b)" | dotnet run --no-build) | Select-Object -Last 1
    if ($out -eq $t.expected) { $ok++; $res = 'PASS' } else { $res = 'FAIL' }
    "{0,2}. a='{1}' b='{2}'  expected: {3}  actual: {4}  [{5}]" -f $n, $t.a, $t.b, $t.expected, $out, $res
}
"Passed $ok of $n"
