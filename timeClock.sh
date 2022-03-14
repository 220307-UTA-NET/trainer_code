#!bin/usr/bash

echo "Running timeClock.sh..."
while [ true ]; do

	read -p $'This is my promp: \n' input
	timestamp=$(date +"%Y-%m-%d:%T")
	echo $input
	echo $timestamp
	#if [[ $input =~ /stop/-i ]]; then
	#if [[ $input == "STOP" || $input == "stop" ]]; then
	if [[ ${input^^} == "STOP" || $input == "stop" ]]; then

	break

	
elif [[ -z $input ]]; then
		echo "empty input found, please try again!"
	fi
	#echo $input + $timestamp >> ./ClockInOut.txt
	EmployeeNames+=("$input:$timestamp")
	sleep 0.5
done

	#echo ${EmployeeNames[@]} >> ./ClockInOut.txt
	for name in ${EmployeeNames[@]}; do
		echo $name >> ./ClockInOut.txt
	done
	echo "Exiting TimeClock"
