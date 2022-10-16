Å*
kC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\DataValidation.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
{ 
public 

static 
class 
DataValidation &
{ 
public 
const 
ushort 
NameTitleMaxLength .
=/ 0
$num1 4
;4 5
public 
const 
byte 
NameTitleMinLength ,
=- .
$num/ 0
;0 1
public 
const 
byte 
FullNameMaxLength +
=, -
$num. 0
;0 1
public

 
const

 
ushort

 
UrlPathMaxLength

 ,
=

- .
$num

/ 3
;

3 4
public 
const 
byte 
UrlPathMinLegth )
=* +
$num, -
;- .
public 
static 
class 
Comment #
{ 	
public 
const 
int 
ContentLength *
=+ ,
$num- 3
;3 4
} 	
public 
static 
class 
Proposal $
{ 	
public 
const 
ushort  
DescriptionMaxLength  4
=5 6
$num7 =
;= >
public 
const 
byte  
DescriptionMinLength 2
=3 4
$num5 7
;7 8
public 
const 
ushort %
ShortDescriptionMaxLength  9
=: ;
$num< ?
;? @
public 
const 
byte %
ShortDescriptionMinLength 7
=8 9
$num: <
;< =
} 	
public 
static 
class 
Post  
{ 	
public 
const 
ushort  
DescriptionMaxLength  4
=5 6
$num7 =
;= >
public 
const 
byte  
DescriptionMinLength 2
=3 4
$num5 7
;7 8
public 
const 
byte %
ShortDescriptionMaxLength 7
=8 9
$num: =
;= >
public   
const   
byte   %
ShortDescriptionMinLength   7
=  8 9
$num  : ;
;  ; <
}!! 	
public## 
static## 
class## 
Events## "
{$$ 	
public%% 
const%% 
ushort%%  
DescriptionMaxLength%%  4
=%%5 6
$num%%7 =
;%%= >
public&& 
const&& 
byte&&  
DescriptionMinLength&& 2
=&&3 4
$num&&5 7
;&&7 8
public(( 
const(( 
byte(( 
TotalPeopleMaxCount(( 1
=((2 3
$num((4 7
;((7 8
public)) 
const)) 
byte)) 
TotalPeopleMinCount)) 1
=))2 3
$num))4 5
;))5 6
}** 	
public,, 
static,, 
class,, 
Address,, #
{-- 	
public.. 
const.. 
byte..  
CountryNameMaxLength.. 2
=..3 4
$num..5 8
;..8 9
public// 
const// 
byte//  
CountryNameMinLength// 2
=//3 4
$num//5 8
;//8 9
public11 
const11 
byte11 
TownNameMaxLength11 /
=110 1
$num112 5
;115 6
public22 
const22 
byte22 
TownNameMinLength22 /
=220 1
$num222 5
;225 6
public44 
const44 
byte44 
StreetNameMaxLength44 1
=442 3
$num444 7
;447 8
public55 
const55 
byte55 
StreetNameMinLength55 1
=552 3
$num554 7
;557 8
}66 	
public88 
static88 
class88 
News88  
{99 	
public:: 
const:: 
byte:: 
PostedOnMaxLength:: /
=::0 1
$num::2 4
;::4 5
public;; 
const;; 
byte;; 
PostedOnMinLength;; /
=;;0 1
$num;;2 3
;;;3 4
public== 
const== 
ushort== 
SummaryMaxLength==  0
===1 2
$num==3 7
;==7 8
public>> 
const>> 
byte>> 
SummaryMinLength>> .
=>>/ 0
$num>>1 3
;>>3 4
public@@ 
const@@ 
ushort@@ 
CreditMaxLength@@  /
=@@0 1
$num@@2 6
;@@6 7
publicAA 
constAA 
byteAA 
CreaditMinLegthAA -
=AA. /
$numAA0 1
;AA1 2
publicCC 
constCC 
ushortCC  
DescriptionMaxLengthCC  4
=CC5 6
$numCC7 =
;CC= >
publicDD 
constDD 
byteDD  
DescriptionMinLengthDD 2
=DD3 4
$numDD5 7
;DD7 8
}EE 	
}FF 
}GG ñ
kC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\IDbQueryRunner.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
{ 
public 

	interface 
IDbQueryRunner #
:$ %
IDisposable& 1
{ 
Task 
RunQueryAsync 
( 
string !
query" '
,' (
params) /
object0 6
[6 7
]7 8

parameters9 C
)C D
;D E
}		 
}

 ›
vC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\Models\BaseDeletableModel.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
. 
Models %
{ 
public 

abstract 
class 
BaseDeletableModel ,
<, -
TKey- 1
>1 2
:3 4
	BaseModel5 >
<> ?
TKey? C
>C D
,D E
IDeletableEntityF V
{ 
public 
bool 
	IsDeleted 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
DateTime		 
?		 
	DeletedOn		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
}

 
} õ
mC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\Models\BaseModel.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
. 
Models %
{ 
public 

abstract 
class 
	BaseModel #
<# $
TKey$ (
>( )
:* +

IAuditInfo, 6
{ 
[ 	
Key	 
] 
public		 
TKey		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public 
DateTime 
	CreatedOn !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
? 

ModifiedOn #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} £
nC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\Models\IAuditInfo.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
. 
Models %
{ 
public 

	interface 

IAuditInfo 
{ 
DateTime 
	CreatedOn 
{ 
get  
;  !
set" %
;% &
}' (
DateTime		 
?		 

ModifiedOn		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
}

 
} ª
tC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\Models\IDeletableEntity.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
. 
Models %
{ 
public 

	interface 
IDeletableEntity %
{ 
bool 
	IsDeleted 
{ 
get 
; 
set !
;! "
}# $
DateTime		 
?		 
	DeletedOn		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
}

 
} Î
„C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\Repositories\IDeletableEntityRepository.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
. 
Repositories +
{ 
public 

	interface &
IDeletableEntityRepository /
</ 0
TEntity0 7
>7 8
:9 :
IRepository; F
<F G
TEntityG N
>N O
where		 
TEntity		 
:		 
class		 
,		 
IDeletableEntity		 /
{

 

IQueryable 
< 
TEntity 
> 
AllWithDeleted *
(* +
)+ ,
;, -

IQueryable 
< 
TEntity 
> &
AllAsNoTrackingWithDeleted 6
(6 7
)7 8
;8 9
Task 
< 
TEntity 
> #
GetByIdWithDeletedAsync -
(- .
params. 4
object5 ;
[; <
]< =
id> @
)@ A
;A B
void 

HardDelete 
( 
TEntity 
entity  &
)& '
;' (
void 
Undelete 
( 
TEntity 
entity $
)$ %
;% &
} 
} Ð

uC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Data\GreenCap.Data.Common\Repositories\IRepository.cs
	namespace 	
GreenCap
 
. 
Data 
. 
Common 
. 
Repositories +
{ 
public 

	interface 
IRepository  
<  !
TEntity! (
>( )
:* +
IDisposable, 7
where 
TEntity 
: 
class 
{		 

IQueryable

 
<

 
TEntity

 
>

 
All

 
(

  
)

  !
;

! "

IQueryable 
< 
TEntity 
> 
AllAsNoTracking +
(+ ,
), -
;- .
Task 
AddAsync 
( 
TEntity 
entity $
)$ %
;% &
void 
Update 
( 
TEntity 
entity "
)" #
;# $
void 
Delete 
( 
TEntity 
entity "
)" #
;# $
Task 
< 
int 
> 
SaveChangesAsync "
(" #
)# $
;$ %
} 
} 