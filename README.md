# Urm-Simulator
 is an easy program that simulate "Unlimited Registers Machine" commands.

## URM Commands:
| Command | Description  | Code |
|   --    |      --      |  --  |
| Successor(Register number |  increase the value stored in Register n by 1 (RegN=RegN+1)  |  `s(1)` |
| Zero(Register number) | Reset the value stored in Register n to 0 (RegN=0) | `z(1)`|
| Transfer(RegN1,RegN2) | Takes a Copy of value stored in RegN1 and paste it in RegN2.(Replace the value in Reg N1 with value   in RegN2).|`t(1,2)`|
| Jumb(RegN1,RegN2,LineN) |checks if (value in RegisterN1 equal to value in RegisterN2)
	if true ?  
	it jumbs to the lineN and execute it and Continue in Sequence.  
	if false ?  
	it ignores the current line of Jumb and Continue the current Sequence of executing .  | `j(1,2,3)` |
------------------------------------------------------------------------
 - **Jumb(RegN1,RegN2,LineN)** 
 **code:** 
 **description:** checks if (value in RegisterN1 equal to value in RegisterN2)
	if true ?  
	it jumbs to the lineN and execute it and Continue in Sequence.  
	if false ?  
	it ignores the current line of Jumb and Continue the current Sequence of executing .

## Note:
***Unmanaged*** Code may lead the program to Hang (it will not Response) because of Infinite loop caused by the  
Command 3, in this case you will have to terminate the program from the ***Task Manager*** or just stop Running if you run the  
Code .  
Although i have provided an option for you that you can Expect the maximum number of loops that program can make  
so if it exceeds the limits you gave it will break that loop.  
So

**be careful !** not enough times of loops won't give you any output.

**For more information RTM !**
