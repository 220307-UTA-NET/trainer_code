#!usr/bin/bash

echo "Running timeclock.sh..."

EmployeeNames=()

while [ true ]; do
	read -p $'This is my prompt: \n' input
	timestamp=$(date +"%Y-%m-%d:%T")
	echo $input
	echo $timestamp

	#if [[ $input =~ /stop/i ]]; then
	#if [[ $input == "STOP" || $input == "stop" ]]; then
	if [[ ${input^^} == "STOP" ]]; then
		break
	#else if
	elif [[ -z $input ]]; then
		echo "empty input found, please try again"

	#fi
	#if [[ -n $input ]]; then
	#	if  [[ ${#input} > 5 ]]; then
	#		echo "input longer than 5 characters"
	#	fi
	#fi
	#echo $input + $timestamp >> ./ClockInOut.txt
	EmployeeNames+=("$input:$timestamp")
	sleep 2
done

#echo ${EmployeeNames[@]} >> ./ClockInOut.txt
for name in ${EmployeeNames[@]}; do
	echo $name >> ./ClockInOut.txt
done


echo "Exiting Timeclock"




