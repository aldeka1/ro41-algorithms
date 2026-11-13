#!/bin/sh
# Run from the t03/Gcd folder:  sh run_tests.sh
dotnet build -v q >/dev/null
n=0; ok=0
tail -n +2 tests.csv | while IFS=';' read -r a b expected; do
  n=$((n+1))
  out=$(printf '%s\n%s\n' "$a" "$b" | dotnet run --no-build | tail -n 1)
  if [ "$out" = "$expected" ]; then res=PASS; else res=FAIL; fi
  echo "$n. a='$a' b='$b' expected: $expected actual: $out [$res]"
done
