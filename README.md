MaxPathSum

*Solution
-I convert input to 2D array. You can read input from file or constants directly inside the code. Check 2D matrix, if matrix include prime number set prime number values to '0' with ControlPrime() function. For each element, check both elements just below the number and below right to the number add the maximum of them to it. If both elements are prime number, change main element's value to '0' because that way is dead end. Then moving upwards by calculating the maximum possible paths.

*Question1: You will have an orthogonal triangle input from a file and you need to find the maximum sum of the numbers according to given rules below;

 You will start from the top and move downwards to an adjacent number as in below.
 You are only allowed to walk downwards and diagonally.
 You can only walk over NON PRIME NUMBERS.
 You have to reach at the end of the pyramid as much as possible.
 You have to treat your input as pyramid.

According to above rules the maximum sum of the numbers from top to bottom in below example is 24.

      *1
     *8 4
    2 *6 9
    8 5 *9 3

As you can see this has several paths that fits the rule of NOT PRIME NUMBERS; 1>8>6>9, 1>4>6>9, 1>4>9>9 1 + 8 + 6 + 9 = 24.  As you see 1, 8, 6, 9 are all NOT PRIME NUMBERS and walking over these yields the maximum sum.

*Question2: According to assignment that you implemented what is the maximum sum of below input? It means please take this input (as file or constants directly inside the code) for your implementation and solve by using it.

    215
    193 124
	117 237 442
	218 935 347 235
	320 804 522 417 345
	229 601 723 835 133 124
	248 202 277 433 207 263 257
	359 464 504 528 516 716 871 182
	461 441 426 656 863 560 380 171 923
	381 348 573 533 447 632 387 176 975 449
	223 711 445 645 245 543 931 532 937 541 444
	330 131 333 928 377 733 017 778 839 168 197 197
	131 171 522 137 217 224 291 413 528 520 227 229 928
	223 626 034 683 839 053 627 310 713 999 629 817 410 121
	924 622 911 233 325 139 721 218 253 223 107 233 230 124 233 