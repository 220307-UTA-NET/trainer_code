#!usr/bin/bash

test="Hello,6789678World!"
reg="[0-9]$"


if [[ $test =~ $reg ]]; then
	echo "yes"
else
	echo "no"
fi
