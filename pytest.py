import time
import os
import sys

def main():
	
	for x in range(0, 5):
		
		print(f'{x}: Hi from python')
		time.sleep(1)
		sys.stdout.flush()

	exit()

main()