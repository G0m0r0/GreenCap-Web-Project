£
ŠC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Web\GreenCap.Web.Infrastructure\Attributes\CurrentYearMaxValueAttribute.cs
	namespace 	
GreenCap
 
. 

Attributes 
{ 
public 

class (
CurrentYearMaxValueAttribute -
:. /
ValidationAttribute0 C
{ 
public (
CurrentYearMaxValueAttribute +
(+ ,
int, /
minYear0 7
)7 8
{		 	
this

 
.

 
MinYear

 
=

 
minYear

 "
;

" #
this 
. 
ErrorMessage 
= 
$"  "
$str" :
{: ;
minYear; B
}B C
$strC H
{H I
DateTimeI Q
.Q R
UtcNowR X
.X Y
YearY ]
}] ^
$str^ _
"_ `
;` a
} 	
public 
int 
MinYear 
{ 
get  
;  !
}" #
public 
override 
bool 
IsValid $
($ %
object% +
value, 1
)1 2
{ 	
if 
( 
value 
is 
int 
intValue %
&& 
intValue 
<= 
DateTime '
.' (
UtcNow( .
.. /
Year/ 3
&& 
intValue 
>= 
this #
.# $
MinYear$ +
)+ ,
{ 
return 
true 
; 
} 
return 
false 
; 
} 	
} 
} 