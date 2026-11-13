#!/bin/sh
# Run from the GradesStats folder:  sh run_tests.sh
dotnet build -v q >/dev/null
for f in tests/*.in; do
  exp="${f%.in}.out"
  if dotnet run --no-build < "$f" | diff -q - "$exp" >/dev/null; then echo "$f: PASS"; else echo "$f: FAIL"; fi
done
