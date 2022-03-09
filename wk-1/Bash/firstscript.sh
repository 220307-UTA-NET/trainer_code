#!/usr/bin/bash

#shebang/hash-bang



#this is a comment

# This line makes a folder
#mkdir ./testfolder

# This line makes a file
touch ./testfolder/name.txt

echo "Hello New File!" >> ./testfolder/name.txt


# For Loop example
for (( i=0; i<5; i+=1 ))
do
	echo $i >> ./testfolder/name.txt
done

# If branching


j=16


if [ $j -eq 15 ]; then
	echo "equal"
else if [ $j -lt 15 ]; then
	echo "less than"
else 
	echo "greater than"
fi




# for range loop
for k in {1..20..2};do
	echo $k
done
