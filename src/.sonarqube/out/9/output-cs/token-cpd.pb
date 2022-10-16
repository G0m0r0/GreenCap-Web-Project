⁄?
oC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\ChartService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
ChartService 
: 
IChartService  -
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
Event4 9
>9 :
events; A
;A B
private 
readonly &
IDeletableEntityRepository 3
<3 4
Proposal4 <
>< =
	proposals> G
;G H
private 
readonly &
IDeletableEntityRepository 3
<3 4
ApplicationUser4 C
>C D
usersE J
;J K
private 
readonly &
IDeletableEntityRepository 3
<3 4
Post4 8
>8 9
posts: ?
;? @
private 
readonly &
IDeletableEntityRepository 3
<3 4
News4 8
>8 9
news: >
;> ?
public 
ChartService 
( &
IDeletableEntityRepository &
<& '
Event' ,
>, -
events. 4
,4 5&
IDeletableEntityRepository &
<& '
Proposal' /
>/ 0
	proposals1 :
,: ;&
IDeletableEntityRepository &
<& '
ApplicationUser' 6
>6 7
users8 =
,= >&
IDeletableEntityRepository &
<& '
Post' +
>+ ,
posts- 2
,2 3&
IDeletableEntityRepository &
<& '
News' +
>+ ,
news- 1
)1 2
{ 	
this 
. 
events 
= 
events  
;  !
this 
. 
	proposals 
= 
	proposals &
;& '
this 
. 
users 
= 
users 
; 
this   
.   
posts   
=   
posts   
;   
this!! 
.!! 
news!! 
=!! 
news!! 
;!! 
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
List$$ 
<$$ 
int$$ "
>$$" #
>$$# $
GetMonthsActivity$$% 6
($$6 7
)$$7 8
{%% 	
var&& 
monthlyActivity&& 
=&&  !
new&&" %
List&&& *
<&&* +
int&&+ .
>&&. /
(&&/ 0
)&&0 1
;&&1 2
for(( 
((( 
int(( 
i(( 
=(( 
$num(( 
;(( 
i(( 
<=((  
(((! "
DateTime((" *
.((* +
Now((+ .
.((. /
Year((/ 3
-((4 5
GlobalConstants((6 E
.((E F
WebsiteCreationYear((F Y
)((Y Z
*(([ \
$num((] _
;((_ `
i((a b
++((b d
)((d e
{)) 
monthlyActivity** 
.**  
Add**  #
(**# $
await**$ )
this*** .
.**. /
GetMonthActivity**/ ?
(**? @
i**@ A
)**A B
)**B C
;**C D
}++ 
return-- 
monthlyActivity-- "
;--" #
}.. 	
private00 
async00 
Task00 
<00 
int00 
>00 
GetMonthActivity00  0
(000 1
int001 4
i005 6
)006 7
{11 	
int22 
yearToLookFor22 
=22 
GlobalConstants22  /
.22/ 0
WebsiteCreationYear220 C
;22C D
if44 
(44 
i44 
>44 
$num44 
)44 
{55 
i66 
=66 
i66 
-66 
(66 
$num66 
*66 
(66 
i66  
/66! "
$num66# %
)66% &
)66& '
;66' (
yearToLookFor77 
+=77  
i77! "
/77# $
$num77% '
;77' (
}88 
var:: !
createdEventsPerMonth:: %
=::& '
await::( -
this::. 2
.::2 3
events::3 9
.;; 
AllAsNoTracking;; $
(;;$ %
);;% &
.<< 
Where<< 
(<< 
x<< 
=><< 
x<<  !
.<<! "
	CreatedOn<<" +
.<<+ ,
Month<<, 1
==<<2 4
i<<5 6
&&<<7 9
x<<: ;
.<<; <
	CreatedOn<<< E
.<<E F
Year<<F J
==<<K M
yearToLookFor<<N [
)<<[ \
.== 

CountAsync== 
(==  
)==  !
;==! "
var??  
createdPostsPerMonth?? $
=??% &
await??' ,
this??- 1
.??1 2
posts??2 7
.@@ 
AllAsNoTracking@@  
(@@  !
)@@! "
.AA 
WhereAA 
(AA 
xAA 
=>AA 
xAA 
.AA 
	CreatedOnAA '
.AA' (
MonthAA( -
==AA. 0
iAA1 2
&&AA3 5
xAA6 7
.AA7 8
	CreatedOnAA8 A
.AAA B
YearAAB F
==AAG I
yearToLookForAAJ W
)AAW X
.BB 

CountAsyncBB 
(BB 
)BB 
;BB 
varDD $
createdProposalsPerMonthDD (
=DD) *
awaitDD+ 0
thisDD1 5
.DD5 6
	proposalsDD6 ?
.EE 
AllAsNoTrackingEE  
(EE  !
)EE! "
.FF 
WhereFF 
(FF 
xFF 
=>FF 
xFF 
.FF 
	CreatedOnFF '
.FF' (
MonthFF( -
==FF. 0
iFF1 2
&&FF3 5
xFF6 7
.FF7 8
	CreatedOnFF8 A
.FFA B
YearFFB F
==FFG I
yearToLookForFFJ W
)FFW X
.GG 

CountAsyncGG 
(GG 
)GG 
;GG 
varII 
createdNewsPerMonthII #
=II$ %
awaitII& +
thisII, 0
.II0 1
newsII1 5
.JJ 
AllAsNoTrackingJJ  
(JJ  !
)JJ! "
.KK 
WhereKK 
(KK 
xKK 
=>KK 
xKK 
.KK 
	CreatedOnKK '
.KK' (
MonthKK( -
==KK. 0
iKK1 2
&&KK3 5
xKK6 7
.KK7 8
	CreatedOnKK8 A
.KKA B
YearKKB F
==KKG I
yearToLookForKKJ W
)KKW X
.LL 

CountAsyncLL 
(LL 
)LL 
;LL 
varNN !
registerUsersPerMonthNN %
=NN& '
awaitNN( -
thisNN. 2
.NN2 3
usersNN3 8
.OO 
AllAsNoTrackingOO  
(OO  !
)OO! "
.PP 
WherePP 
(PP 
xPP 
=>PP 
xPP 
.PP 
	CreatedOnPP '
.PP' (
MonthPP( -
==PP. 0
iPP1 2
&&PP3 5
xPP6 7
.PP7 8
	CreatedOnPP8 A
.PPA B
YearPPB F
==PPG I
yearToLookForPPJ W
)PPW X
.QQ 

CountAsyncQQ 
(QQ 
)QQ 
;QQ 
varSS 
monthActivitySumSS  
=SS! "!
createdEventsPerMonthSS# 8
+SS9 :
createdNewsPerMonthSS; N
+SSO P 
createdPostsPerMonthSSQ e
+SSf g%
createdProposalsPerMonth	SSh Ä
+
SSÅ Ç#
registerUsersPerMonth
SSÉ ò
;
SSò ô
returnUU 
monthActivitySumUU #
;UU# $
}VV 	
}WW 
}XX Æ,
rC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\CommentsService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
CommentsService  
:! "
ICommentsService# 3
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
Comment4 ;
>; <

commentsDb= G
;G H
public 
CommentsService 
( &
IDeletableEntityRepository 9
<9 :
Comment: A
>A B

commentsDbC M
)M N
{ 	
this 
. 

commentsDb 
= 

commentsDb (
;( )
} 	
public 
async 
Task 
CreateAsync %
(% &
int& )
postId* 0
,0 1
string2 8
userId9 ?
,? @
stringA G
contentH O
,O P
intQ T
?T U
parentIdV ^
=_ `
nulla e
)e f
{ 	
var 
comment 
= 
new 
Comment %
{ 
Content 
= 
content !
,! "
ParentId 
= 
parentId #
,# $
PostId 
= 
postId 
,  
UserId 
= 
userId 
,  
} 
; 
await!! 
this!! 
.!! 

commentsDb!! !
.!!! "
AddAsync!!" *
(!!* +
comment!!+ 2
)!!2 3
;!!3 4
await"" 
this"" 
."" 

commentsDb"" !
.""! "
SaveChangesAsync""" 2
(""2 3
)""3 4
;""4 5
}## 	
public%% 
async%% 
Task%% 
<%% 
int%% 
>%% 
DeleteByIdAsync%% .
(%%. /
int%%/ 2
id%%3 5
,%%5 6
string%%7 =
userId%%> D
)%%D E
{&& 	
var'' 
modelToDelete'' 
='' 
await''  %
this''& *
.''* +

commentsDb''+ 5
.''5 6
All''6 9
(''9 :
)'': ;
.''; <
FirstOrDefaultAsync''< O
(''O P
x''P Q
=>''R T
x''U V
.''V W
Id''W Y
==''Z \
id''] _
)''_ `
;''` a
if)) 
()) 
modelToDelete)) 
.)) 
UserId)) $
!=))% '
userId))( .
))). /
{** 
throw++ 
new++ "
NullReferenceException++ 0
(++0 1
ExceptionMessages++1 B
.++B C4
(YouCanDeleteOnlyYourOwnCommentsException++C k
)++k l
;++l m
},, 
if.. 
(.. 
modelToDelete.. 
==..  
null..! %
)..% &
{// 
throw00 
new00 "
NullReferenceException00 0
(000 1
ExceptionMessages001 B
.00B C
CommentNotFound00C R
)00R S
;00S T
}11 
this33 
.33 

commentsDb33 
.33 
Delete33 "
(33" #
modelToDelete33# 0
)330 1
;331 2
await44 
this44 
.44 

commentsDb44 !
.44! "
SaveChangesAsync44" 2
(442 3
)443 4
;444 5
return66 
modelToDelete66  
.66  !
PostId66! '
;66' (
}77 	
public99 
bool99 

IsInPostId99 
(99 
int99 "
	commentId99# ,
,99, -
int99. 1
postId992 8
)998 9
{:: 	
CheckIfIdIsCorrect;; 
(;; 
	commentId;; (
);;( )
;;;) *
CheckIfIdIsCorrect<< 
(<< 
postId<< %
)<<% &
;<<& '
var>> 
commentPostId>> 
=>> 
this>>  $
.>>$ %

commentsDb>>% /
.??  !
All??! $
(??$ %
)??% &
.??& '
Where??' ,
(??, -
x??- .
=>??/ 1
x??2 3
.??3 4
Id??4 6
==??7 9
	commentId??: C
)??C D
.@@  !
Select@@! '
(@@' (
x@@( )
=>@@* ,
x@@- .
.@@. /
PostId@@/ 5
)@@5 6
.AA  !
FirstOrDefaultAA! /
(AA/ 0
)AA0 1
;AA1 2
returnCC 
commentPostIdCC  
==CC! #
postIdCC$ *
;CC* +
}DD 	
privateFF 
staticFF 
voidFF 
CheckIfIdIsCorrectFF .
(FF. /
intFF/ 2
idFF3 5
)FF5 6
{GG 	
ifHH 
(HH 
idHH 
<HH 
$numHH 
)HH 
{II 
throwJJ 
newJJ -
!NegativeNumberNotAllowedExceptionJJ ;
(JJ; <
stringKK 
.KK 
FormatKK !
(KK! "
ExceptionMessagesKK" 3
.KK3 4"
CanNotBeNegativeNumberKK4 J
,KKJ K
nameofKKL R
(KKR S
idKKS U
)KKU V
)KKV W
)KKW X
;KKX Y
}LL 
}MM 	
}NN 
}OO ¿
{C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Common\ExceptionMessages.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
Common! '
{ 
public 

static 
class 
ExceptionMessages )
{ 
public 
const 
string 
ProposalNotFound ,
=- .
$str/ G
;G H
public 
const 
string 
PostNotFound (
=) *
$str+ ?
;? @
public		 
const		 
string		 
NewsNotFound		 (
=		) *
$str		+ N
;		N O
public 
const 
string '
YouHaveToBeCreatorException 7
=8 9
$str: p
;p q
public 
const 
string *
InvalidImageExtentionException :
=; <
$str= [
;[ \
public 
const 
string 4
(YouCanDeleteOnlyYourOwnCommentsException D
=E F
$strG o
;o p
public 
const 
string 
CommentNotFound +
=, -
$str. L
;L M
public 
const 
string $
CategoryNameDoesNotExist 4
=5 6
$str7 V
;V W
public 
const 
string 
CategoryIsNull *
=+ ,
$str- G
;G H
public 
const 
string 
UserDoesNotExist ,
=- .
$str/ D
;D E
public 
const 
string 
EventNotFound )
=* +
$str, A
;A B
public 
const 
string "
CanNotBeNegativeNumber 2
=3 4
$str5 V
;V W
} 
} ¿
{C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Common\FormatValidations.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
Common! '
{ 
public 

static 
class 
FormatValidations )
{ 
public 
const 
string 
DateTimeFormat *
=+ ,
$str- :
;: ;
public 
const 
string 
DefaultUserName +
=, -
$str. ?
;? @
public		 
const		 
string		 !
DateTimeNeverModified		 1
=		2 3
$str		4 E
;		E F
}

 
} ß
}C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Common\OperationalMessages.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
Common! '
{ 
public 

static 
class 
OperationalMessages +
{ 
} 
} Ù
yC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IBaseService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
IBaseService !
{ 
IEnumerable 
< 
T 
> 
GetAll 
< 
T 
>  
(  !
int! $
page% )
,) *
int+ .
itemsPerPage/ ;
); <
;< =
Task

 
<

 
T

 
>

 
GetByIdAsync

 
<

 
T

 
>

 
(

  
int

  #
id

$ &
)

& '
;

' (
} 
} Œ
zC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IChartService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
IChartService "
{ 
Task 
< 
List 
< 
int 
> 
> 
GetMonthsActivity )
() *
)* +
;+ ,
}		 
}

 ˇ
}C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\ICommentsService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
ICommentsService %
{ 
Task 
CreateAsync 
( 
int 
postId #
,# $
string% +
userId, 2
,2 3
string4 :
content; B
,B C
intD G
?G H
parentIdI Q
=R S
nullT X
)X Y
;Y Z
bool		 

IsInPostId		 
(		 
int		 
	commentId		 %
,		% &
int		' *
postId		+ 1
)		1 2
;		2 3
Task 
< 
int 
> 
DeleteByIdAsync !
(! "
int" %
id& (
,( )
string* 0
userId1 7
)7 8
;8 9
} 
} È
zC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IEventService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
IEventService "
:# $
IBaseService% 1
{		 
Task

 
CreateAsync

 
(

 
EventInputViewModel

 ,
model

- 2
,

2 3
string

4 :
userId

; A
)

A B
;

B C
Task 
DeleteByIdAsync 
( 
int  
id! #
,# $
string% +
userId, 2
)2 3
;3 4
Task 
JoinEventAsync 
( 
int 
eventId  '
,' (
string) /
userId0 6
)6 7
;7 8
Task 
CancelEventAsync 
( 
int !
eventId" )
,) *
string+ 1
userId2 8
)8 9
;9 :
Task 
UpdateAsync 
( 
int 
id 
,  
EventEditViewModel! 3
input4 9
,9 :
string; A
userIdB H
)H I
;I J
int 
GetCount 
( 
) 
; 
} 
} Ú
yC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IHomeService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
IHomeService !
{ 
HomeStatisticsDto

 
	GetCounts

 #
(

# $
)

$ %
;

% &
} 
} ’
~C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IJoinEventService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
IJoinEventService &
{ 
Task 
JoinEventAsync 
( 
int 
eventId  '
,' (
string) /
userId0 6
)6 7
;7 8
double		 
GetNeededPeople		 
(		 
int		 "
eventId		# *
)		* +
;		+ ,
}

 
} Û
yC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\ILikeService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
ILikeService !
{ 
Task 
SetLikeAsync 
( 
int 
postId $
,$ %
string& ,
userId- 3
,3 4
bool5 9

isPositive: D
)D E
;E F
int		 
GetLikes		 
(		 
int		 
postId		 
)		  
;		  !
int 
GetDisslikes 
( 
int 
postId #
)# $
;$ %
} 
} â
yC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\INewsService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
INewsService !
:" #
IBaseService$ 0
{ 
Task 
DeleteByIdAsync 
( 
int  
id! #
)# $
;$ %
int		 
GetCount		 
(		 
)		 
;		 
}

 
} «
yC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IPostService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public		 

	interface		 
IPostservice		 !
:		" #
IBaseService		$ 0
{

 
IEnumerable 
< 
T 
> 
GetAllPersonal %
<% &
T& '
>' (
(( )
int) ,
page- 1
,1 2
int3 6
itemsPerPage7 C
,C D
stringE K
idL N
)N O
;O P
Task 
CreateAsync 
( 
PostInputViewModel +
model, 1
,1 2
string3 9
id: <
)< =
;= >
Task 
DeleteByIdAsync 
( 
int  
id! #
,# $
string% +
userId, 2
)2 3
;3 4
Task 
UpdateAsync 
( 
int 
id 
,  
PostEditViewModel! 2
input3 8
,8 9
string: @
userIdA G
)G H
;H I
int 
GetCount 
( 
) 
; 
int 
GetCountPersonal 
( 
string #
id$ &
)& '
;' (
int 
GetCountByCategory 
( 
string %
categoryName& 2
)2 3
;3 4
} 
} Ñ
}C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IProposalService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public		 

	interface		 
IProposalService		 %
:		& '
IBaseService		( 4
{

 
IEnumerable 
< 
T 
> 
GetAllPersonal %
<% &
T& '
>' (
(( )
int) ,
page- 1
,1 2
int3 6
itemsPerPage7 C
,C D
stringE K
idL N
)N O
;O P
Task 
CreateAsync 
( 
ProposalViewModel *
model+ 0
,0 1
string2 8
userId9 ?
,? @
stringA G
	imagepathH Q
)Q R
;R S
Task 
DeleteByIdAsync 
( 
int  
id! #
,# $
string% +
userId, 2
)2 3
;3 4
Task 
UpdateAsync 
( 
int 
id 
,  !
ProposalEditViewModel! 6
input7 <
,< =
string> D
userIdE K
)K L
;L M
int 
GetCount 
( 
) 
; 
int 
GetCountPersonal 
( 
string #
id$ &
)& '
;' (
} 
} ü
}C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\ISettingsService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
ISettingsService %
{ 
int 
GetCount 
( 
) 
; 
IEnumerable		 
<		 
T		 
>		 
GetAll		 
<		 
T		 
>		  
(		  !
)		! "
;		" #
}

 
} Å
zC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Contracts\IVotesService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
	Contracts! *
{ 
public 

	interface 
IVotesService "
{ 
Task 
SetVoteAsync 
( 
int 
recipeId &
,& '
string( .
userId/ 5
,5 6
byte7 ;
value< A
)A B
;B C
double		 
GetAverageVotes		 
(		 
int		 "
recipeId		# +
)		+ ,
;		, -
}

 
} ñ	
yC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\DTOs\HomeStatisticsDto.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !
DTOs! %
{ 
public 

class 
HomeStatisticsDto "
{ 
public 
int 

PostsCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
ProposalsCount !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
int		 
EventsCount		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public 
int 

UsersCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
	NewsCount 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} √∫
oC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\EventService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
EventService 
: 
IEventService  -
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
Event4 9
>9 :
eventsDb; C
;C D
private 
readonly &
IDeletableEntityRepository 3
<3 4
ApplicationUser4 C
>C D
userDbE K
;K L
private 
readonly &
IDeletableEntityRepository 3
<3 4
UserEventHosts4 B
>B C
userHostsDbD O
;O P
private 
readonly &
IDeletableEntityRepository 3
<3 4
UserEventSignedIn4 E
>E F

userJoinDbG Q
;Q R
public 
EventService 
( &
IDeletableEntityRepository &
<& '
Event' ,
>, -
eventsDb. 6
,6 7&
IDeletableEntityRepository &
<& '
ApplicationUser' 6
>6 7
userDb8 >
,> ?&
IDeletableEntityRepository &
<& '
UserEventHosts' 5
>5 6
userHostsDb7 B
,B C&
IDeletableEntityRepository &
<& '
UserEventSignedIn' 8
>8 9

userJoinDb: D
)D E
{ 	
this 
. 
eventsDb 
= 
eventsDb $
;$ %
this   
.   
userDb   
=   
userDb    
;    !
this!! 
.!! 
userHostsDb!! 
=!! 
userHostsDb!! *
;!!* +
this"" 
."" 

userJoinDb"" 
="" 

userJoinDb"" (
;""( )
}## 	
public%% 
async%% 
Task%% 
CreateAsync%% %
(%%% &
EventInputViewModel%%& 9
model%%: ?
,%%? @
string%%A G
userId%%H N
)%%N O
{&& 	
var'' 
creator'' 
='' 
this'' 
.'' 
userDb'' %
.''% &
All''& )
('') *
)''* +
.''+ ,
FirstOrDefault'', :
('': ;
x''; <
=>''= ?
x''@ A
.''A B
Id''B D
==''E G
userId''H N
)''N O
;''O P
if)) 
()) 
creator)) 
==)) 
null)) 
)))  
{** 
throw++ 
new++ "
NullReferenceException++ 0
(++0 1
ExceptionMessages++1 B
.++B C
UserDoesNotExist++C S
)++S T
;++T U
},, 
var.. 

eventModel.. 
=.. 
new..  
Event..! &
{// 
Description00 
=00 
model00 #
.00# $
Description00$ /
,00/ 0
EndDate11 
=11 
model11 
.11  
EndDate11  '
,11' (
	StartDate22 
=22 
model22 !
.22! "
	StartDate22" +
,22+ ,
	ImagePath33 
=33 
model33 !
.33! "
	ImagePath33" +
,33+ ,
Name44 
=44 
model44 
.44 
Name44 !
,44! "
TotalPeople55 
=55 
model55 #
.55# $
TotalPeople55$ /
,55/ 0
}66 
;66 
await77 
this77 
.77 
eventsDb77 
.77  
AddAsync77  (
(77( )

eventModel77) 3
)773 4
;774 5
await88 
this88 
.88 
eventsDb88 
.88  
SaveChangesAsync88  0
(880 1
)881 2
;882 3
var:: 
userCreator:: 
=:: 
new:: !
UserEventHosts::" 0
{;; 
UserId<< 
=<< 
creator<<  
.<<  !
Id<<! #
,<<# $
EventId== 
=== 

eventModel== $
.==$ %
Id==% '
,==' (
}>> 
;>> 
await?? 
this?? 
.?? 
userHostsDb?? "
.??" #
AddAsync??# +
(??+ ,
userCreator??, 7
)??7 8
;??8 9
await@@ 
this@@ 
.@@ 
userHostsDb@@ "
.@@" #
SaveChangesAsync@@# 3
(@@3 4
)@@4 5
;@@5 6
ifBB 
(BB 
modelBB 
.BB 
CreatorsNamesBB #
!=BB$ &
nullBB' +
)BB+ ,
{CC 
varDD 
listOfInputHostsDD $
=DD% &
modelDD' ,
.DD, -
CreatorsNamesDD- :
.DD: ;
SplitDD; @
(DD@ A
newDDA D
charDDE I
[DDI J
]DDJ K
{DDL M
$charDDN Q
,DDQ R
$charDDS V
,DDV W
$charDDX [
,DD[ \
$charDD] a
,DDa b
$charDDc f
}DDg h
,DDh i
StringSplitOptionsDDj |
.DD| }
RemoveEmptyEntries	DD} è
)
DDè ê
;
DDê ë
foreachFF 
(FF 
varFF 
userNameFF %
inFF& (
listOfInputHostsFF) 9
)FF9 :
{GG 
varHH 
userHH 
=HH 
thisHH #
.HH# $
userDbHH$ *
.II 
AllII 
(II 
)II 
.JJ 
FirstOrDefaultJJ '
(JJ' (
xJJ( )
=>JJ* ,
xJJ- .
.JJ. /
UserNameJJ/ 7
==JJ8 :
userNameJJ; C
)JJC D
;JJD E
ifLL 
(LL 
userLL 
!=LL 
nullLL  $
)LL$ %
{MM 
varNN 
userHostNN $
=NN% &
newNN' *
UserEventHostsNN+ 9
{OO 
EventIdPP #
=PP$ %

eventModelPP& 0
.PP0 1
IdPP1 3
,PP3 4
UserIdQQ "
=QQ# $
userQQ% )
.QQ) *
IdQQ* ,
,QQ, -
}RR 
;RR 
awaitTT 
thisTT "
.TT" #
userHostsDbTT# .
.TT. /
AddAsyncTT/ 7
(TT7 8
userHostTT8 @
)TT@ A
;TTA B
awaitUU 
thisUU "
.UU" #
userHostsDbUU# .
.UU. /
SaveChangesAsyncUU/ ?
(UU? @
)UU@ A
;UUA B
}VV 
}WW 
}XX 
}YY 	
public[[ 
async[[ 
Task[[ 
JoinEventAsync[[ (
([[( )
int[[) ,
eventId[[- 4
,[[4 5
string[[6 <
userId[[= C
)[[C D
{\\ 	
var]] 

eventModel]] 
=]] 
this]] !
.]]! "
eventsDb]]" *
.]]* +
All]]+ .
(]]. /
)]]/ 0
.]]0 1
FirstOrDefault]]1 ?
(]]? @
x]]@ A
=>]]B D
x]]E F
.]]F G
Id]]G I
==]]J L
eventId]]M T
)]]T U
;]]U V
var^^ 
	userModel^^ 
=^^ 
this^^  
.^^  !
userDb^^! '
.^^' (
All^^( +
(^^+ ,
)^^, -
.^^- .
FirstOrDefault^^. <
(^^< =
x^^= >
=>^^? A
x^^B C
.^^C D
Id^^D F
==^^G I
userId^^J P
)^^P Q
;^^Q R
if`` 
(`` 

eventModel`` 
==`` 
null`` "
)``" #
{aa 
throwbb 
newbb "
NullReferenceExceptionbb 0
(bb0 1
ExceptionMessagesbb1 B
.bbB C
EventNotFoundbbC P
)bbP Q
;bbQ R
}cc 
ifee 
(ee 
	userModelee 
==ee 
nullee !
)ee! "
{ff 
throwgg 
newgg "
NullReferenceExceptiongg 0
(gg0 1
ExceptionMessagesgg1 B
.ggB C
UserDoesNotExistggC S
)ggS T
;ggT U
}hh 
varjj 
	userEventjj 
=jj 
awaitjj !
thisjj" &
.jj& '

userJoinDbjj' 1
.kk 
AllWithDeletedkk 
(kk  
)kk  !
.ll 
FirstOrDefaultAsyncll $
(ll$ %
xll% &
=>ll' )
xll* +
.ll+ ,
UserIdll, 2
==ll3 5
userIdll6 <
&&ll= ?
xll@ A
.llA B
EventIdllB I
==llJ L
eventIdllM T
)llT U
;llU V
ifnn 
(nn 
	userEventnn 
!=nn 
nullnn !
)nn! "
{oo 
	userEventpp 
.pp 
	IsDeletedpp #
=pp$ %
falsepp& +
;pp+ ,
awaitqq 
thisqq 
.qq 

userJoinDbqq %
.qq% &
SaveChangesAsyncqq& 6
(qq6 7
)qq7 8
;qq8 9
returnss 
;ss 
}tt 
varvv 
userEventJoinvv 
=vv 
newvv  #
UserEventSignedInvv$ 5
{ww 
UserIdxx 
=xx 
	userModelxx "
.xx" #
Idxx# %
,xx% &
EventIdyy 
=yy 

eventModelyy $
.yy$ %
Idyy% '
,yy' (
}zz 
;zz 
await|| 
this|| 
.|| 

userJoinDb|| !
.||! "
AddAsync||" *
(||* +
userEventJoin||+ 8
)||8 9
;||9 :
await}} 
this}} 
.}} 

userJoinDb}} !
.}}! "
SaveChangesAsync}}" 2
(}}2 3
)}}3 4
;}}4 5
}~~ 	
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ 
DeleteByIdAsync
ÄÄ )
(
ÄÄ) *
int
ÄÄ* -
id
ÄÄ. 0
,
ÄÄ0 1
string
ÄÄ2 8
userId
ÄÄ9 ?
)
ÄÄ? @
{
ÅÅ 	
var
ÇÇ 
modelToDelete
ÇÇ 
=
ÇÇ 
await
ÇÇ  %
this
ÇÇ& *
.
ÇÇ* +
eventsDb
ÇÇ+ 3
.
ÇÇ3 4
All
ÇÇ4 7
(
ÇÇ7 8
)
ÇÇ8 9
.
ÇÇ9 :!
FirstOrDefaultAsync
ÇÇ: M
(
ÇÇM N
x
ÇÇN O
=>
ÇÇP R
x
ÇÇS T
.
ÇÇT U
Id
ÇÇU W
==
ÇÇX Z
id
ÇÇ[ ]
)
ÇÇ] ^
;
ÇÇ^ _
if
ÑÑ 
(
ÑÑ 
modelToDelete
ÑÑ 
==
ÑÑ  
null
ÑÑ! %
)
ÑÑ% &
{
ÖÖ 
throw
ÜÜ 
new
ÜÜ $
NullReferenceException
ÜÜ 0
(
ÜÜ0 1
ExceptionMessages
ÜÜ1 B
.
ÜÜB C
EventNotFound
ÜÜC P
)
ÜÜP Q
;
ÜÜQ R
}
áá 
if
ââ 
(
ââ 
modelToDelete
ââ 
.
ââ 
UserEventsHosts
ââ -
.
ââ- .
Any
ââ. 1
(
ââ1 2
x
ââ2 3
=>
ââ4 6
x
ââ7 8
.
ââ8 9
UserId
ââ9 ?
==
ââ@ B
userId
ââC I
)
ââI J
)
ââJ K
{
ää 
throw
ãã 
new
ãã $
NullReferenceException
ãã 0
(
ãã0 1
string
åå 
.
åå 
Format
åå !
(
åå! "
ExceptionMessages
åå" 3
.
åå3 4)
YouHaveToBeCreatorException
åå4 O
,
ååO P
modelToDelete
ååQ ^
.
åå^ _
Name
åå_ c
)
ååc d
)
ååd e
;
ååe f
}
çç 
this
èè 
.
èè 
eventsDb
èè 
.
èè 
Delete
èè  
(
èè  !
modelToDelete
èè! .
)
èè. /
;
èè/ 0
await
êê 
this
êê 
.
êê 
eventsDb
êê 
.
êê  
SaveChangesAsync
êê  0
(
êê0 1
)
êê1 2
;
êê2 3
}
ëë 	
public
ìì 
IEnumerable
ìì 
<
ìì 
T
ìì 
>
ìì 
GetAll
ìì $
<
ìì$ %
T
ìì% &
>
ìì& '
(
ìì' (
int
ìì( +
page
ìì, 0
,
ìì0 1
int
ìì2 5
itemsPerPage
ìì6 B
)
ììB C
{
îî 	1
#CheckIfPageAndItemsPerPageIsCorrect
ïï /
(
ïï/ 0
page
ïï0 4
,
ïï4 5
itemsPerPage
ïï6 B
)
ïïB C
;
ïïC D
return
óó 
this
óó 
.
óó 
eventsDb
óó  
.
òò 
AllAsNoTracking
òò  
(
òò  !
)
òò! "
.
ôô 
Where
ôô 
(
ôô 
x
ôô 
=>
ôô 
x
ôô 
.
ôô 
EndDate
ôô %
>
ôô& '
DateTime
ôô( 0
.
ôô0 1
UtcNow
ôô1 7
)
ôô7 8
.
öö 
OrderBy
öö 
(
öö 
x
öö 
=>
öö 
x
öö 
.
öö  
	StartDate
öö  )
)
öö) *
.
õõ 
Skip
õõ 
(
õõ 
(
õõ 
page
õõ 
-
õõ 
$num
õõ 
)
õõ  
*
õõ! "
itemsPerPage
õõ# /
)
õõ/ 0
.
úú 
Take
úú 
(
úú 
itemsPerPage
úú "
)
úú" #
.
ùù 
To
ùù 
<
ùù 
T
ùù 
>
ùù 
(
ùù 
)
ùù 
.
ûû 
ToList
ûû 
(
ûû 
)
ûû 
;
ûû 
}
üü 	
public
°° 
async
°° 
Task
°° 
<
°° 
T
°° 
>
°° 
GetByIdAsync
°° )
<
°°) *
T
°°* +
>
°°+ ,
(
°°, -
int
°°- 0
id
°°1 3
)
°°3 4
{
¢¢ 	 
CheckIfIdIsCorrect
££ 
(
££ 
id
££ !
)
££! "
;
££" #
return
•• 
await
•• 
this
•• 
.
•• 
eventsDb
•• &
.
¶¶ 
AllAsNoTracking
¶¶ 
(
¶¶  
)
¶¶  !
.
ßß 
Where
ßß 
(
ßß 
x
ßß 
=>
ßß 
x
ßß 
.
ßß 
Id
ßß 
==
ßß  "
id
ßß# %
)
ßß% &
.
®® 
To
®® 
<
®® 
T
®® 
>
®® 
(
®® 
)
®® 
.
©© !
FirstOrDefaultAsync
©© #
(
©©# $
)
©©$ %
;
©©% &
}
™™ 	
public
¨¨ 
int
¨¨ 
GetCount
¨¨ 
(
¨¨ 
)
¨¨ 
{
≠≠ 	
return
ÆÆ 
this
ÆÆ 
.
ÆÆ 
eventsDb
ÆÆ  
.
ÆÆ  !
AllAsNoTracking
ÆÆ! 0
(
ÆÆ0 1
)
ÆÆ1 2
.
ÆÆ2 3
Count
ÆÆ3 8
(
ÆÆ8 9
)
ÆÆ9 :
;
ÆÆ: ;
}
ØØ 	
public
±± 
async
±± 
Task
±± 
CancelEventAsync
±± *
(
±±* +
int
±±+ .
eventId
±±/ 6
,
±±6 7
string
±±8 >
userId
±±? E
)
±±E F
{
≤≤ 	
var
≥≥ 

eventModel
≥≥ 
=
≥≥ 
this
≥≥ !
.
≥≥! "
eventsDb
≥≥" *
.
≥≥* +
All
≥≥+ .
(
≥≥. /
)
≥≥/ 0
.
≥≥0 1
FirstOrDefault
≥≥1 ?
(
≥≥? @
x
≥≥@ A
=>
≥≥B D
x
≥≥E F
.
≥≥F G
Id
≥≥G I
==
≥≥J L
eventId
≥≥M T
)
≥≥T U
;
≥≥U V
var
¥¥ 
	userModel
¥¥ 
=
¥¥ 
this
¥¥  
.
¥¥  !
userDb
¥¥! '
.
¥¥' (
All
¥¥( +
(
¥¥+ ,
)
¥¥, -
.
¥¥- .
FirstOrDefault
¥¥. <
(
¥¥< =
x
¥¥= >
=>
¥¥? A
x
¥¥B C
.
¥¥C D
Id
¥¥D F
==
¥¥G I
userId
¥¥J P
)
¥¥P Q
;
¥¥Q R
if
∂∂ 
(
∂∂ 

eventModel
∂∂ 
==
∂∂ 
null
∂∂ "
)
∂∂" #
{
∑∑ 
throw
∏∏ 
new
∏∏ $
NullReferenceException
∏∏ 0
(
∏∏0 1
ExceptionMessages
∏∏1 B
.
∏∏B C
EventNotFound
∏∏C P
)
∏∏P Q
;
∏∏Q R
}
ππ 
if
ªª 
(
ªª 
	userModel
ªª 
==
ªª 
null
ªª !
)
ªª! "
{
ºº 
throw
ΩΩ 
new
ΩΩ $
NullReferenceException
ΩΩ 0
(
ΩΩ0 1
ExceptionMessages
ΩΩ1 B
.
ΩΩB C
UserDoesNotExist
ΩΩC S
)
ΩΩS T
;
ΩΩT U
}
ææ 
var
¿¿ 
	userEvent
¿¿ 
=
¿¿ 
await
¿¿ !
this
¿¿" &
.
¿¿& '

userJoinDb
¿¿' 1
.
¡¡ 
AllWithDeleted
¡¡ 
(
¡¡  
)
¡¡  !
.
¬¬ !
FirstOrDefaultAsync
¬¬ $
(
¬¬$ %
x
¬¬% &
=>
¬¬' )
x
¬¬* +
.
¬¬+ ,
UserId
¬¬, 2
==
¬¬3 5
userId
¬¬6 <
&&
¬¬= ?
x
¬¬@ A
.
¬¬A B
EventId
¬¬B I
==
¬¬J L
eventId
¬¬M T
)
¬¬T U
;
¬¬U V
if
ƒƒ 
(
ƒƒ 
	userEvent
ƒƒ 
==
ƒƒ 
null
ƒƒ !
)
ƒƒ! "
{
≈≈ 
return
∆∆ 
;
∆∆ 
}
«« 
if
…… 
(
…… 
!
…… 
	userEvent
…… 
.
…… 
	IsDeleted
…… $
)
……$ %
{
   
this
ÀÀ 
.
ÀÀ 

userJoinDb
ÀÀ 
.
ÀÀ  
Delete
ÀÀ  &
(
ÀÀ& '
	userEvent
ÀÀ' 0
)
ÀÀ0 1
;
ÀÀ1 2
await
ÃÃ 
this
ÃÃ 
.
ÃÃ 

userJoinDb
ÃÃ %
.
ÃÃ% &
SaveChangesAsync
ÃÃ& 6
(
ÃÃ6 7
)
ÃÃ7 8
;
ÃÃ8 9
}
ÕÕ 
}
ŒŒ 	
public
–– 
async
–– 
Task
–– 
UpdateAsync
–– %
(
––% &
int
––& )
id
––* ,
,
––, - 
EventEditViewModel
––. @
input
––A F
,
––F G
string
––H N
userId
––O U
)
––U V
{
—— 	
var
““ 

eventModel
““ 
=
““ 
await
““ "
this
““# '
.
““' (
eventsDb
““( 0
.
““0 1
All
““1 4
(
““4 5
)
““5 6
.
““6 7!
FirstOrDefaultAsync
““7 J
(
““J K
x
““K L
=>
““M O
x
““P Q
.
““Q R
Id
““R T
==
““U W
id
““X Z
)
““Z [
;
““[ \
if
‘‘ 
(
‘‘ 

eventModel
‘‘ 
==
‘‘ 
null
‘‘ "
)
‘‘" #
{
’’ 
throw
÷÷ 
new
÷÷ $
NullReferenceException
÷÷ 0
(
÷÷0 1
ExceptionMessages
÷÷1 B
.
÷÷B C
EventNotFound
÷÷C P
)
÷÷P Q
;
÷÷Q R
}
◊◊ 
if
ŸŸ 
(
ŸŸ 

eventModel
ŸŸ 
.
ŸŸ 
UserEventsHosts
ŸŸ *
.
ŸŸ* +
Any
ŸŸ+ .
(
ŸŸ. /
x
ŸŸ/ 0
=>
ŸŸ1 3
x
ŸŸ4 5
.
ŸŸ5 6
UserId
ŸŸ6 <
==
ŸŸ= ?
userId
ŸŸ@ F
)
ŸŸF G
)
ŸŸG H
{
⁄⁄ 
throw
€€ 
new
€€ $
NullReferenceException
€€ 0
(
€€0 1
string
‹‹ 
.
‹‹ 
Format
‹‹ !
(
‹‹! "
ExceptionMessages
‹‹" 3
.
‹‹3 4)
YouHaveToBeCreatorException
‹‹4 O
,
‹‹O P

eventModel
‹‹Q [
.
‹‹[ \
Name
‹‹\ `
)
‹‹` a
)
‹‹a b
;
‹‹b c
}
›› 

eventModel
ﬂﬂ 
.
ﬂﬂ 
Name
ﬂﬂ 
=
ﬂﬂ 
input
ﬂﬂ #
.
ﬂﬂ# $
Name
ﬂﬂ$ (
;
ﬂﬂ( )

eventModel
‡‡ 
.
‡‡ 
Description
‡‡ "
=
‡‡# $
input
‡‡% *
.
‡‡* +
Description
‡‡+ 6
;
‡‡6 7

eventModel
·· 
.
·· 
	StartDate
··  
=
··! "
input
··# (
.
··( )
	StartDate
··) 2
;
··2 3

eventModel
‚‚ 
.
‚‚ 
EndDate
‚‚ 
=
‚‚  
input
‚‚! &
.
‚‚& '
EndDate
‚‚' .
;
‚‚. /

eventModel
„„ 
.
„„ 
	ImagePath
„„  
=
„„! "
input
„„# (
.
„„( )
	ImagePath
„„) 2
;
„„2 3

eventModel
‰‰ 
.
‰‰ 
TotalPeople
‰‰ "
=
‰‰# $
input
‰‰% *
.
‰‰* +
TotalPeople
‰‰+ 6
;
‰‰6 7
await
ÊÊ 
this
ÊÊ 
.
ÊÊ 
eventsDb
ÊÊ 
.
ÊÊ  
SaveChangesAsync
ÊÊ  0
(
ÊÊ0 1
)
ÊÊ1 2
;
ÊÊ2 3
}
ÁÁ 	
private
ÈÈ 
static
ÈÈ 
void
ÈÈ  
CheckIfIdIsCorrect
ÈÈ .
(
ÈÈ. /
int
ÈÈ/ 2
id
ÈÈ3 5
)
ÈÈ5 6
{
ÍÍ 	
if
ÎÎ 
(
ÎÎ 
id
ÎÎ 
<
ÎÎ 
$num
ÎÎ 
)
ÎÎ 
{
ÏÏ 
throw
ÌÌ 
new
ÌÌ /
!NegativeNumberNotAllowedException
ÌÌ ;
(
ÌÌ; <
string
ÓÓ 
.
ÓÓ 
Format
ÓÓ !
(
ÓÓ! "
ExceptionMessages
ÓÓ" 3
.
ÓÓ3 4$
CanNotBeNegativeNumber
ÓÓ4 J
,
ÓÓJ K
nameof
ÓÓL R
(
ÓÓR S
id
ÓÓS U
)
ÓÓU V
)
ÓÓV W
)
ÓÓW X
;
ÓÓX Y
}
ÔÔ 
}
 	
private
ÚÚ 
static
ÚÚ 
void
ÚÚ 1
#CheckIfPageAndItemsPerPageIsCorrect
ÚÚ ?
(
ÚÚ? @
int
ÚÚ@ C
page
ÚÚD H
,
ÚÚH I
int
ÚÚJ M
itemsPerPage
ÚÚN Z
)
ÚÚZ [
{
ÛÛ 	
if
ÙÙ 
(
ÙÙ 
page
ÙÙ 
<
ÙÙ 
$num
ÙÙ 
)
ÙÙ 
{
ıı 
throw
ˆˆ 
new
ˆˆ /
!NegativeNumberNotAllowedException
ˆˆ ;
(
ˆˆ; <
string
˜˜ 
.
˜˜ 
Format
˜˜ !
(
˜˜! "
ExceptionMessages
˜˜" 3
.
˜˜3 4$
CanNotBeNegativeNumber
˜˜4 J
,
˜˜J K
nameof
˜˜L R
(
˜˜R S
page
˜˜S W
)
˜˜W X
)
˜˜X Y
)
˜˜Y Z
;
˜˜Z [
}
¯¯ 
if
˙˙ 
(
˙˙ 
itemsPerPage
˙˙ 
<
˙˙ 
$num
˙˙  
)
˙˙  !
{
˚˚ 
throw
¸¸ 
new
¸¸ /
!NegativeNumberNotAllowedException
¸¸ ;
(
¸¸; <
string
˝˝ 
.
˝˝ 
Format
˝˝ !
(
˝˝! "
ExceptionMessages
˝˝" 3
.
˝˝3 4$
CanNotBeNegativeNumber
˝˝4 J
,
˝˝J K
nameof
˝˝L R
(
˝˝R S
itemsPerPage
˝˝S _
)
˝˝_ `
)
˝˝` a
)
˝˝a b
;
˝˝b c
}
˛˛ 
}
ˇˇ 	
}
ÄÄ 
}ÅÅ ⁄
èC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\Exceptions\NegativeNumberNotAllowedException.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
.  !

Exceptions! +
{ 
public 

class -
!NegativeNumberNotAllowedException 2
:3 4
	Exception5 >
{ 
public -
!NegativeNumberNotAllowedException 0
(0 1
string1 7
message8 ?
)? @
: 
base 
( 
message 
) 
{		 	
}

 	
} 
} ˙
nC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\HomeService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public

 

class

 
HomeService

 
:

 
IHomeService

 +
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
Event4 9
>9 :
events; A
;A B
private 
readonly &
IDeletableEntityRepository 3
<3 4
Proposal4 <
>< =
	proposals> G
;G H
private 
readonly &
IDeletableEntityRepository 3
<3 4
ApplicationUser4 C
>C D
usersE J
;J K
private 
readonly &
IDeletableEntityRepository 3
<3 4
Post4 8
>8 9
posts: ?
;? @
private 
readonly &
IDeletableEntityRepository 3
<3 4
News4 8
>8 9
news: >
;> ?
public 
HomeService 
( &
IDeletableEntityRepository &
<& '
Event' ,
>, -
events. 4
,4 5&
IDeletableEntityRepository &
<& '
Proposal' /
>/ 0
	proposals1 :
,: ;&
IDeletableEntityRepository &
<& '
ApplicationUser' 6
>6 7
users8 =
,= >&
IDeletableEntityRepository &
<& '
Post' +
>+ ,
posts- 2
,2 3&
IDeletableEntityRepository &
<& '
News' +
>+ ,
news- 1
)1 2
{ 	
this 
. 
events 
= 
events  
;  !
this 
. 
	proposals 
= 
	proposals &
;& '
this 
. 
users 
= 
users 
; 
this 
. 
posts 
= 
posts 
; 
this 
. 
news 
= 
news 
; 
} 	
public   
HomeStatisticsDto    
	GetCounts  ! *
(  * +
)  + ,
{!! 	
var"" 
data"" 
="" 
new"" 
HomeStatisticsDto"" ,
{## 
EventsCount$$ 
=$$ 
this$$ "
.$$" #
events$$# )
.$$) *
All$$* -
($$- .
)$$. /
.$$/ 0
Count$$0 5
($$5 6
)$$6 7
,$$7 8

PostsCount%% 
=%% 
this%% !
.%%! "
posts%%" '
.%%' (
All%%( +
(%%+ ,
)%%, -
.%%- .
Count%%. 3
(%%3 4
)%%4 5
,%%5 6
ProposalsCount&& 
=&&  
this&&! %
.&&% &
	proposals&&& /
.&&/ 0
All&&0 3
(&&3 4
)&&4 5
.&&5 6
Count&&6 ;
(&&; <
)&&< =
,&&= >

UsersCount'' 
='' 
this'' !
.''! "
users''" '
.''' (
All''( +
(''+ ,
)'', -
.''- .
Count''. 3
(''3 4
)''4 5
,''5 6
	NewsCount(( 
=(( 
this((  
.((  !
news((! %
.((% &
All((& )
((() *
)((* +
.((+ ,
Count((, 1
(((1 2
)((2 3
,((3 4
})) 
;)) 
return++ 
data++ 
;++ 
},, 	
}-- 
}.. ﬁ5
nC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\NewsService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
NewsService 
: 
INewsService +
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
News4 8
>8 9
newsDb: @
;@ A
public 
NewsService 
( &
IDeletableEntityRepository 5
<5 6
News6 :
>: ;
newsDb< B
)B C
{ 	
this 
. 
newsDb 
= 
newsDb  
;  !
} 	
public 
async 
Task 
DeleteByIdAsync )
() *
int* -
id. 0
)0 1
{ 	
CheckIfIdIsCorrect 
( 
id !
)! "
;" #
var 
modelToDelete 
= 
await  %
this& *
.* +
newsDb+ 1
.1 2
All2 5
(5 6
)6 7
.7 8
FirstOrDefaultAsync8 K
(K L
xL M
=>N P
xQ R
.R S
IdS U
==V X
idY [
)[ \
;\ ]
if 
( 
modelToDelete 
==  
null! %
)% &
{   
throw!! 
new!! "
NullReferenceException!! 0
(!!0 1
ExceptionMessages!!1 B
.!!B C
NewsNotFound!!C O
)!!O P
;!!P Q
}"" 
modelToDelete$$ 
.$$ 
	IsDeleted$$ #
=$$$ %
true$$& *
;$$* +
modelToDelete%% 
.%% 
	DeletedOn%% #
=%%$ %
DateTime%%& .
.%%. /
UtcNow%%/ 5
;%%5 6
this&& 
.&& 
newsDb&& 
.&& 
Update&& 
(&& 
modelToDelete&& ,
)&&, -
;&&- .
await(( 
this(( 
.(( 
newsDb(( 
.(( 
SaveChangesAsync(( .
(((. /
)((/ 0
;((0 1
})) 	
public++ 
IEnumerable++ 
<++ 
T++ 
>++ 
GetAll++ $
<++$ %
T++% &
>++& '
(++' (
int++( +
page++, 0
,++0 1
int++2 5
itemsPerPage++6 B
)++B C
{,, 	/
#CheckIfPageAndItemsPerPageIsCorrect-- /
(--/ 0
page--0 4
,--4 5
itemsPerPage--6 B
)--B C
;--C D
return// 
this// 
.// 
newsDb// 
.00 
AllAsNoTracking00  
(00  !
)00! "
.11 
OrderByDescending11 "
(11" #
x11# $
=>11% '
x11( )
.11) *
	CreatedOn11* 3
)113 4
.22 
Skip22 
(22 
(22 
page22 
-22 
$num22 
)22  
*22! "
itemsPerPage22# /
)22/ 0
.33 
Take33 
(33 
itemsPerPage33 "
)33" #
.44 
To44 
<44 
T44 
>44 
(44 
)44 
.55 
ToList55 
(55 
)55 
;55 
}66 	
public88 
async88 
Task88 
<88 
T88 
>88 
GetByIdAsync88 )
<88) *
T88* +
>88+ ,
(88, -
int88- 0
id881 3
)883 4
{99 	
CheckIfIdIsCorrect:: 
(:: 
id:: !
)::! "
;::" #
return<< 
await<< 
this<< 
.<< 
newsDb<< $
.== 
AllAsNoTracking==  
(==  !
)==! "
.>> 
Where>> 
(>> 
x>> 
=>>> 
x>> 
.>> 
Id>>  
==>>! #
id>>$ &
)>>& '
.?? 
To?? 
<?? 
T?? 
>?? 
(?? 
)?? 
.@@ 
FirstOrDefaultAsync@@ $
(@@$ %
)@@% &
;@@& '
}AA 	
publicCC 
intCC 
GetCountCC 
(CC 
)CC 
{DD 	
returnEE 
thisEE 
.EE 
newsDbEE 
.EE 
AllEE "
(EE" #
)EE# $
.EE$ %
CountEE% *
(EE* +
)EE+ ,
;EE, -
}FF 	
privateHH 
staticHH 
voidHH 
CheckIfIdIsCorrectHH .
(HH. /
intHH/ 2
idHH3 5
)HH5 6
{II 	
ifJJ 
(JJ 
idJJ 
<JJ 
$numJJ 
)JJ 
{KK 
throwLL 
newLL -
!NegativeNumberNotAllowedExceptionLL ;
(LL; <
stringMM 
.MM 
FormatMM !
(MM! "
ExceptionMessagesMM" 3
.MM3 4"
CanNotBeNegativeNumberMM4 J
,MMJ K
nameofMML R
(MMR S
idMMS U
)MMU V
)MMV W
)MMW X
;MMX Y
}NN 
}OO 	
privateQQ 
staticQQ 
voidQQ /
#CheckIfPageAndItemsPerPageIsCorrectQQ ?
(QQ? @
intQQ@ C
pageQQD H
,QQH I
intQQJ M
itemsPerPageQQN Z
)QQZ [
{RR 	
ifSS 
(SS 
pageSS 
<SS 
$numSS 
)SS 
{TT 
throwUU 
newUU -
!NegativeNumberNotAllowedExceptionUU ;
(UU; <
stringVV 
.VV 
FormatVV !
(VV! "
ExceptionMessagesVV" 3
.VV3 4"
CanNotBeNegativeNumberVV4 J
,VVJ K
nameofVVL R
(VVR S
pageVVS W
)VVW X
)VVX Y
)VVY Z
;VVZ [
}WW 
ifYY 
(YY 
itemsPerPageYY 
<YY 
$numYY  
)YY  !
{ZZ 
throw[[ 
new[[ -
!NegativeNumberNotAllowedException[[ ;
([[; <
string\\ 
.\\ 
Format\\ !
(\\! "
ExceptionMessages\\" 3
.\\3 4"
CanNotBeNegativeNumber\\4 J
,\\J K
nameof\\L R
(\\R S
itemsPerPage\\S _
)\\_ `
)\\` a
)\\a b
;\\b c
}]] 
}^^ 	
}__ 
}`` ®
rC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\PostLikeService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public

 

class

 
PostLikeService

  
:

! "
ILikeService

# /
{ 
private 
readonly 
IRepository $
<$ %
UserLike% -
>- .
likesDb/ 6
;6 7
public 
PostLikeService 
( 
IRepository *
<* +
UserLike+ 3
>3 4
likesDb5 <
)< =
{ 	
this 
. 
likesDb 
= 
likesDb "
;" #
} 	
public 
int 
GetDisslikes 
(  
int  #
postId$ *
)* +
{ 	
return 
this 
. 
likesDb 
. 
All 
( 
) 
. 
Where 
( 
x 
=> 
x 
. 
PostId $
==% '
postId( .
). /
. 
Where 
( 
x 
=> 
! 
x 
. 

IsPositive )
)) *
. 
Count 
( 
) 
; 
} 	
public 
int 
GetLikes 
( 
int 
postId  &
)& '
{ 	
return 
this 
. 
likesDb 
. 
All 
( 
) 
.   
Where   
(   
x   
=>   
x   
.   
PostId   $
==  % '
postId  ( .
)  . /
.!! 
Where!! 
(!! 
x!! 
=>!! 
x!! 
.!! 

IsPositive!! (
)!!( )
."" 
Count"" 
("" 
)"" 
;"" 
}## 	
public%% 
async%% 
Task%% 
SetLikeAsync%% &
(%%& '
int%%' *
postId%%+ 1
,%%1 2
string%%3 9
userId%%: @
,%%@ A
bool%%B F

isPositive%%G Q
)%%Q R
{&& 	
var'' 
like'' 
='' 
this'' 
.'' 
likesDb'' #
.''# $
All''$ '
(''' (
)''( )
.(( 
FirstOrDefault(( 
(((  
x((  !
=>((" $
x((% &
.((& '
PostId((' -
==((. 0
postId((1 7
&&((8 :
x((; <
.((< =
UserId((= C
==((D F
userId((G M
)((M N
;((N O
if** 
(** 
like** 
==** 
null** 
)** 
{++ 
like,, 
=,, 
new,, 
UserLike,, #
{-- 
PostId.. 
=.. 
postId.. #
,..# $
UserId// 
=// 
userId// #
,//# $
}00 
;00 
await22 
this22 
.22 
likesDb22 "
.22" #
AddAsync22# +
(22+ ,
like22, 0
)220 1
;221 2
}33 
like55 
.55 

IsPositive55 
=55 

isPositive55 (
;55( )
await66 
this66 
.66 
likesDb66 
.66 
SaveChangesAsync66 /
(66/ 0
)660 1
;661 2
}77 	
}88 
}99 ÚÑ
nC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\PostService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
PostService 
: 
IPostservice +
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
Post4 8
>8 9
forumDb: A
;A B
private 
readonly &
IDeletableEntityRepository 3
<3 4
ApplicationUser4 C
>C D
userDbE K
;K L
public 
PostService 
( &
IDeletableEntityRepository 5
<5 6
Post6 :
>: ;
forumDb< C
,C D&
IDeletableEntityRepositoryE _
<_ `
ApplicationUser` o
>o p
userDbq w
)w x
{ 	
this 
. 
forumDb 
= 
forumDb "
;" #
this 
. 
userDb 
= 
userDb  
;  !
} 	
public 
async 
Task 
CreateAsync %
(% &
PostInputViewModel& 8
model9 >
,> ?
string@ F
idG I
)I J
{ 	
var   
creator   
=   
this   
.   
userDb   %
.  % &
All  & )
(  ) *
)  * +
.  + ,
FirstOrDefault  , :
(  : ;
x  ; <
=>  = ?
x  @ A
.  A B
Id  B D
==  E G
id  H J
)  J K
;  K L
if"" 
("" 
creator"" 
=="" 
null"" 
)""  
{## 
throw$$ 
new$$ "
NullReferenceException$$ 0
($$0 1
ExceptionMessages$$1 B
.$$B C
UserDoesNotExist$$C S
)$$S T
;$$T U
}%% 
var'' 
modelToCreate'' 
='' 
new''  #
Post''$ (
{(( 
ProblemTitle)) 
=)) 
model)) $
.))$ %
ProblemTitle))% 1
,))1 2
Category** 
=** 
model**  
.**  !
Category**! )
,**) *
CreatedById++ 
=++ 
id++  
,++  !
Description,, 
=,, 
model,, #
.,,# $
Description,,$ /
,,,/ 0
}-- 
;-- 
await// 
this// 
.// 
forumDb// 
.// 
AddAsync// '
(//' (
modelToCreate//( 5
)//5 6
;//6 7
await00 
this00 
.00 
forumDb00 
.00 
SaveChangesAsync00 /
(00/ 0
)000 1
;001 2
}11 	
public33 
IEnumerable33 
<33 
T33 
>33 
GetAll33 $
<33$ %
T33% &
>33& '
(33' (
int33( +
page33, 0
,330 1
int332 5
itemsPerPage336 B
)33B C
{44 	/
#CheckIfPageAndItemsPerPageIsCorrect55 /
(55/ 0
page550 4
,554 5
itemsPerPage556 B
)55B C
;55C D
return77 
this77 
.77 
forumDb77 
.88 
AllAsNoTracking88  
(88  !
)88! "
.99 
OrderByDescending99 "
(99" #
x99# $
=>99% '
x99( )
.99) *
	CreatedOn99* 3
)993 4
.:: 
Skip:: 
(:: 
(:: 
page:: 
-:: 
$num:: 
)::  
*::! "
itemsPerPage::# /
)::/ 0
.;; 
Take;; 
(;; 
itemsPerPage;; "
);;" #
.<< 
To<< 
<<< 
T<< 
><< 
(<< 
)<< 
.== 
ToList== 
(== 
)== 
;== 
}>> 	
public@@ 
IEnumerable@@ 
<@@ 
T@@ 
>@@ 
GetAllPersonal@@ ,
<@@, -
T@@- .
>@@. /
(@@/ 0
int@@0 3
page@@4 8
,@@8 9
int@@: =
itemsPerPage@@> J
,@@J K
string@@L R
id@@S U
)@@U V
{AA 	/
#CheckIfPageAndItemsPerPageIsCorrectBB /
(BB/ 0
pageBB0 4
,BB4 5
itemsPerPageBB6 B
)BBB C
;BBC D
ifDD 
(DD 
!DD 
thisDD 
.DD 
userDbDD 
.DD 
AllDD  
(DD  !
)DD! "
.DD" #
AnyDD# &
(DD& '
xDD' (
=>DD) +
xDD, -
.DD- .
IdDD. 0
==DD1 3
idDD4 6
)DD6 7
)DD7 8
{EE 
throwFF 
newFF "
NullReferenceExceptionFF 0
(FF0 1
ExceptionMessagesFF1 B
.FFB C
UserDoesNotExistFFC S
)FFS T
;FFT U
}GG 
returnII 
thisII 
.II 
forumDbII 
.JJ 
AllAsNoTrackingJJ  
(JJ  !
)JJ! "
.KK 
WhereKK 
(KK 
xKK 
=>KK 
xKK 
.KK 
CreatedByIdKK )
==KK* ,
idKK- /
)KK/ 0
.LL 
OrderByDescendingLL "
(LL" #
xLL# $
=>LL% '
xLL( )
.LL) *
	CreatedOnLL* 3
)LL3 4
.MM 
SkipMM 
(MM 
(MM 
pageMM 
-MM 
$numMM 
)MM  
*MM! "
itemsPerPageMM# /
)MM/ 0
.NN 
TakeNN 
(NN 
itemsPerPageNN "
)NN" #
.OO 
ToOO 
<OO 
TOO 
>OO 
(OO 
)OO 
.PP 
ToListPP 
(PP 
)PP 
;PP 
}QQ 	
publicSS 
asyncSS 
TaskSS 
<SS 
TSS 
>SS 
GetByIdAsyncSS )
<SS) *
TSS* +
>SS+ ,
(SS, -
intSS- 0
idSS1 3
)SS3 4
{TT 	
CheckIfIdIsCorrectUU 
(UU 
idUU !
)UU! "
;UU" #
returnWW 
awaitWW 
thisWW 
.WW 
forumDbWW %
.XX 
AllAsNoTrackingXX  
(XX  !
)XX! "
.YY 
WhereYY 
(YY 
xYY 
=>YY 
xYY 
.YY 
IdYY  
==YY! #
idYY$ &
)YY& '
.ZZ 
ToZZ 
<ZZ 
TZZ 
>ZZ 
(ZZ 
)ZZ 
.[[ 
FirstOrDefaultAsync[[ $
([[$ %
)[[% &
;[[& '
}\\ 	
public^^ 
async^^ 
Task^^ 
UpdateAsync^^ %
(^^% &
int^^& )
id^^* ,
,^^, -
PostEditViewModel^^. ?
input^^@ E
,^^E F
string^^G M
userId^^N T
)^^T U
{__ 	
var`` 
post`` 
=`` 
await`` 
this`` !
.``! "
forumDb``" )
.``) *
All``* -
(``- .
)``. /
.``/ 0
FirstOrDefaultAsync``0 C
(``C D
x``D E
=>``F H
x``I J
.``J K
Id``K M
==``N P
id``Q S
)``S T
;``T U
ifbb 
(bb 
postbb 
==bb 
nullbb 
)bb 
{cc 
throwdd 
newdd "
NullReferenceExceptiondd 0
(dd0 1
ExceptionMessagesdd1 B
.ddB C
PostNotFoundddC O
)ddO P
;ddP Q
}ee 
ifgg 
(gg 
postgg 
.gg 
CreatedByIdgg  
!=gg! #
userIdgg$ *
)gg* +
{hh 
throwii 
newii "
NullReferenceExceptionii 0
(ii0 1
stringii1 7
.ii7 8
Formatii8 >
(ii> ?
ExceptionMessagesii? P
.iiP Q'
YouHaveToBeCreatorExceptioniiQ l
,iil m
postiin r
.iir s
ProblemTitleiis 
)	ii Ä
)
iiÄ Å
;
iiÅ Ç
}jj 
postll 
.ll 
ProblemTitlell 
=ll 
inputll  %
.ll% &
ProblemTitlell& 2
;ll2 3
postmm 
.mm 
Descriptionmm 
=mm 
inputmm $
.mm$ %
Descriptionmm% 0
;mm0 1
postnn 
.nn 
Categorynn 
=nn 
inputnn !
.nn! "
Categorynn" *
;nn* +
awaitpp 
thispp 
.pp 
forumDbpp 
.pp 
SaveChangesAsyncpp /
(pp/ 0
)pp0 1
;pp1 2
}qq 	
publicss 
asyncss 
Taskss 
DeleteByIdAsyncss )
(ss) *
intss* -
idss. 0
,ss0 1
stringss2 8
userIdss9 ?
)ss? @
{tt 	
varuu 
modelToDeleteuu 
=uu 
awaituu  %
thisuu& *
.uu* +
forumDbuu+ 2
.uu2 3
Alluu3 6
(uu6 7
)uu7 8
.uu8 9
FirstOrDefaultAsyncuu9 L
(uuL M
xuuM N
=>uuO Q
xuuR S
.uuS T
IduuT V
==uuW Y
iduuZ \
)uu\ ]
;uu] ^
ifww 
(ww 
modelToDeleteww 
==ww  
nullww! %
)ww% &
{xx 
throwyy 
newyy "
NullReferenceExceptionyy 0
(yy0 1
ExceptionMessagesyy1 B
.yyB C
PostNotFoundyyC O
)yyO P
;yyP Q
}zz 
if|| 
(|| 
modelToDelete|| 
.|| 
CreatedById|| )
!=||* ,
userId||- 3
)||3 4
{}} 
throw~~ 
new~~ "
NullReferenceException~~ 0
(~~0 1
string 
. 
Format !
(! "
ExceptionMessages" 3
.3 4'
YouHaveToBeCreatorException4 O
,O P
modelToDeleteQ ^
.^ _
ProblemTitle_ k
)k l
)l m
;m n
}
ÄÄ 
this
ÇÇ 
.
ÇÇ 
forumDb
ÇÇ 
.
ÇÇ 
Delete
ÇÇ 
(
ÇÇ  
modelToDelete
ÇÇ  -
)
ÇÇ- .
;
ÇÇ. /
await
ÑÑ 
this
ÑÑ 
.
ÑÑ 
forumDb
ÑÑ 
.
ÑÑ 
SaveChangesAsync
ÑÑ /
(
ÑÑ/ 0
)
ÑÑ0 1
;
ÑÑ1 2
}
ÖÖ 	
public
áá 
int
áá 
GetCount
áá 
(
áá 
)
áá 
{
àà 	
return
ââ 
this
ââ 
.
ââ 
forumDb
ââ 
.
ââ  
All
ââ  #
(
ââ# $
)
ââ$ %
.
ââ% &
Count
ââ& +
(
ââ+ ,
)
ââ, -
;
ââ- .
}
ää 	
public
åå 
int
åå 
GetCountPersonal
åå #
(
åå# $
string
åå$ *
id
åå+ -
)
åå- .
{
çç 	
bool
éé 
exist
éé 
=
éé 
this
éé 
.
éé 
userDb
éé $
.
éé$ %
All
éé% (
(
éé( )
)
éé) *
.
éé* +
Any
éé+ .
(
éé. /
x
éé/ 0
=>
éé1 3
x
éé4 5
.
éé5 6
Id
éé6 8
==
éé9 ;
id
éé< >
)
éé> ?
;
éé? @
if
èè 
(
èè 
!
èè 
exist
èè 
)
èè 
{
êê 
throw
ëë 
new
ëë $
NullReferenceException
ëë 0
(
ëë0 1
ExceptionMessages
ëë1 B
.
ëëB C
UserDoesNotExist
ëëC S
)
ëëS T
;
ëëT U
}
íí 
return
îî 
this
îî 
.
îî 
forumDb
îî 
.
îî  
All
îî  #
(
îî# $
)
îî$ %
.
îî% &
Where
îî& +
(
îî+ ,
x
îî, -
=>
îî. 0
x
îî1 2
.
îî2 3
CreatedById
îî3 >
==
îî? A
id
îîB D
)
îîD E
.
îîE F
Count
îîF K
(
îîK L
)
îîL M
;
îîM N
}
ïï 	
public
óó 
int
óó  
GetCountByCategory
óó %
(
óó% &
string
óó& ,
categoryName
óó- 9
)
óó9 :
{
òò 	
if
ôô 
(
ôô 
string
ôô 
.
ôô  
IsNullOrWhiteSpace
ôô )
(
ôô) *
categoryName
ôô* 6
)
ôô6 7
)
ôô7 8
{
öö 
throw
õõ 
new
õõ $
NullReferenceException
õõ 0
(
õõ0 1
ExceptionMessages
õõ1 B
.
õõB C
CategoryIsNull
õõC Q
)
õõQ R
;
õõR S
}
úú 
bool
ûû 
categoryExists
ûû 
=
ûû  !
Enum
ûû" &
.
ûû& '
	IsDefined
ûû' 0
(
ûû0 1
typeof
üü 
(
üü 
Category
üü 
)
üü  
,
üü  !
categoryName
üü" .
)
üü. /
;
üü/ 0
if
°° 
(
°° 
!
°° 
categoryExists
°° 
)
°°  
{
¢¢ 
throw
££ 
new
££ $
NullReferenceException
££ 0
(
££0 1
ExceptionMessages
££1 B
.
££B C&
CategoryNameDoesNotExist
££C [
)
££[ \
;
££\ ]
}
§§ 
return
¶¶ 
this
¶¶ 
.
¶¶ 
forumDb
¶¶ 
.
¶¶  
All
¶¶  #
(
¶¶# $
)
¶¶$ %
.
¶¶% &
Where
¶¶& +
(
¶¶+ ,
x
¶¶, -
=>
¶¶. 0
x
¶¶1 2
.
¶¶2 3
Category
¶¶3 ;
.
¶¶; <
ToString
¶¶< D
(
¶¶D E
)
¶¶E F
==
¶¶G I
categoryName
¶¶J V
)
¶¶V W
.
¶¶W X
Count
¶¶X ]
(
¶¶] ^
)
¶¶^ _
;
¶¶_ `
}
ßß 	
private
©© 
static
©© 
void
©©  
CheckIfIdIsCorrect
©© .
(
©©. /
int
©©/ 2
id
©©3 5
)
©©5 6
{
™™ 	
if
´´ 
(
´´ 
id
´´ 
<
´´ 
$num
´´ 
)
´´ 
{
¨¨ 
throw
≠≠ 
new
≠≠ /
!NegativeNumberNotAllowedException
≠≠ ;
(
≠≠; <
string
ÆÆ 
.
ÆÆ 
Format
ÆÆ !
(
ÆÆ! "
ExceptionMessages
ÆÆ" 3
.
ÆÆ3 4$
CanNotBeNegativeNumber
ÆÆ4 J
,
ÆÆJ K
nameof
ÆÆL R
(
ÆÆR S
id
ÆÆS U
)
ÆÆU V
)
ÆÆV W
)
ÆÆW X
;
ÆÆX Y
}
ØØ 
}
∞∞ 	
private
≤≤ 
static
≤≤ 
void
≤≤ 1
#CheckIfPageAndItemsPerPageIsCorrect
≤≤ ?
(
≤≤? @
int
≤≤@ C
page
≤≤D H
,
≤≤H I
int
≤≤J M
itemsPerPage
≤≤N Z
)
≤≤Z [
{
≥≥ 	
if
¥¥ 
(
¥¥ 
page
¥¥ 
<
¥¥ 
$num
¥¥ 
)
¥¥ 
{
µµ 
throw
∂∂ 
new
∂∂ /
!NegativeNumberNotAllowedException
∂∂ ;
(
∂∂; <
string
∑∑ 
.
∑∑ 
Format
∑∑ !
(
∑∑! "
ExceptionMessages
∑∑" 3
.
∑∑3 4$
CanNotBeNegativeNumber
∑∑4 J
,
∑∑J K
nameof
∑∑L R
(
∑∑R S
page
∑∑S W
)
∑∑W X
)
∑∑X Y
)
∑∑Y Z
;
∑∑Z [
}
∏∏ 
if
∫∫ 
(
∫∫ 
itemsPerPage
∫∫ 
<
∫∫ 
$num
∫∫  
)
∫∫  !
{
ªª 
throw
ºº 
new
ºº /
!NegativeNumberNotAllowedException
ºº ;
(
ºº; <
string
ΩΩ 
.
ΩΩ 
Format
ΩΩ !
(
ΩΩ! "
ExceptionMessages
ΩΩ" 3
.
ΩΩ3 4$
CanNotBeNegativeNumber
ΩΩ4 J
,
ΩΩJ K
nameof
ΩΩL R
(
ΩΩR S
itemsPerPage
ΩΩS _
)
ΩΩ_ `
)
ΩΩ` a
)
ΩΩa b
;
ΩΩb c
}
ææ 
}
øø 	
}
¿¿ 
}¡¡ ﬂ|
rC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\ProposalService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
ProposalService  
:! "
IProposalService# 3
{ 
private 
readonly 
string 
[  
]  !
allowedExtensions" 3
=4 5
new6 9
[9 :
]: ;
{< =
$str> C
,C D
$strE J
,J K
$strL Q
}R S
;S T
private 
readonly &
IDeletableEntityRepository 3
<3 4
Proposal4 <
>< =

proposalDb> H
;H I
public 
ProposalService 
( &
IDeletableEntityRepository 9
<9 :
Proposal: B
>B C

proposalDbD N
)N O
{ 	
this 
. 

proposalDb 
= 

proposalDb (
;( )
} 	
public 
async 
Task 
CreateAsync %
(% &
ProposalViewModel& 7
model8 =
,= >
string? E
userIdF L
,L M
stringN T
	imagePathU ^
)^ _
{ 	
var 
proposal 
= 
new 
Proposal '
{   
Title!! 
=!! 
model!! 
.!! 
Title!! #
,!!# $
ShortDescription""  
=""! "
model""# (
.""( )
ShortDescription"") 9
,""9 :
Description## 
=## 
model## #
.### $
Description##$ /
,##/ 0
CreatedById$$ 
=$$ 
userId$$ $
,$$$ %
}%% 
;%% 
	Directory)) 
.)) 
CreateDirectory)) %
())% &
$"))& (
{))( )
	imagePath))) 2
}))2 3
$str))3 >
"))> ?
)))? @
;))@ A
foreach** 
(** 
var** 
image** 
in** !
model**" '
.**' (
Images**( .
)**. /
{++ 
var,, 
	extension,, 
=,, 
Path,,  $
.,,$ %
GetExtension,,% 1
(,,1 2
image,,2 7
.,,7 8
FileName,,8 @
),,@ A
.,,A B
	TrimStart,,B K
(,,K L
$char,,L O
),,O P
;,,P Q
if-- 
(-- 
!-- 
this-- 
.-- 
allowedExtensions-- +
.--+ ,
Any--, /
(--/ 0
x--0 1
=>--2 4
	extension--5 >
.--> ?
EndsWith--? G
(--G H
x--H I
)--I J
)--J K
)--K L
{.. 
throw// 
new// 
	Exception// '
(//' (
string//( .
.//. /
Format/// 5
(//5 6
ExceptionMessages//6 G
.//G H*
InvalidImageExtentionException//H f
,//f g
	extension//h q
)//q r
)//r s
;//s t
}00 
var22 
dbImage22 
=22 
new22 !
Image22" '
{33 
	AddedById44 
=44 
userId44  &
,44& '
	Extension55 
=55 
	extension55  )
,55) *
}66 
;66 
proposal77 
.77 
Images77 
.77  
Add77  #
(77# $
dbImage77$ +
)77+ ,
;77, -
var99 
physicalPath99  
=99! "
$"99# %
{99% &
	imagePath99& /
}99/ 0
$str990 ;
{99; <
dbImage99< C
.99C D
Id99D F
}99F G
$str99G H
{99H I
	extension99I R
}99R S
"99S T
;99T U
using:: 
Stream:: 

fileStream:: '
=::( )
new::* -

FileStream::. 8
(::8 9
physicalPath::9 E
,::E F
FileMode::G O
.::O P
Create::P V
)::V W
;::W X
await;; 
image;; 
.;; 
CopyToAsync;; '
(;;' (

fileStream;;( 2
);;2 3
;;;3 4
}<< 
await>> 
this>> 
.>> 

proposalDb>> !
.>>! "
AddAsync>>" *
(>>* +
proposal>>+ 3
)>>3 4
;>>4 5
await?? 
this?? 
.?? 

proposalDb?? !
.??! "
SaveChangesAsync??" 2
(??2 3
)??3 4
;??4 5
}@@ 	
publicBB 
IEnumerableBB 
<BB 
TBB 
>BB 
GetAllBB $
<BB$ %
TBB% &
>BB& '
(BB' (
intBB( +
pageBB, 0
,BB0 1
intBB2 5
itemsPerPageBB6 B
)BBB C
{CC 	/
#CheckIfPageAndItemsPerPageIsCorrectDD /
(DD/ 0
pageDD0 4
,DD4 5
itemsPerPageDD6 B
)DDB C
;DDC D
returnFF 
thisFF 
.FF 

proposalDbFF "
.GG 
AllAsNoTrackingGG  
(GG  !
)GG! "
.HH 
OrderByDescendingHH "
(HH" #
xHH# $
=>HH% '
xHH( )
.HH) *
	CreatedOnHH* 3
)HH3 4
.II 
SkipII 
(II 
(II 
pageII 
-II 
$numII 
)II  
*II! "
itemsPerPageII# /
)II/ 0
.JJ 
TakeJJ 
(JJ 
itemsPerPageJJ "
)JJ" #
.KK 
ToKK 
<KK 
TKK 
>KK 
(KK 
)KK 
.LL 
ToListLL 
(LL 
)LL 
;LL 
}MM 	
publicOO 
IEnumerableOO 
<OO 
TOO 
>OO 
GetAllPersonalOO ,
<OO, -
TOO- .
>OO. /
(OO/ 0
intOO0 3
pageOO4 8
,OO8 9
intOO: =
itemsPerPageOO> J
,OOJ K
stringOOL R
userIdOOS Y
)OOY Z
{PP 	/
#CheckIfPageAndItemsPerPageIsCorrectQQ /
(QQ/ 0
pageQQ0 4
,QQ4 5
itemsPerPageQQ6 B
)QQB C
;QQC D
returnSS 
thisSS 
.SS 

proposalDbSS "
.TT 
AllAsNoTrackingTT  
(TT  !
)TT! "
.UU 
WhereUU 
(UU 
xUU 
=>UU 
xUU 
.UU 
CreatedByIdUU )
==UU* ,
userIdUU- 3
)UU3 4
.VV 
OrderByDescendingVV "
(VV" #
xVV# $
=>VV% '
xVV( )
.VV) *
	CreatedOnVV* 3
)VV3 4
.WW 
SkipWW 
(WW 
(WW 
pageWW 
-WW 
$numWW 
)WW  
*WW! "
itemsPerPageWW# /
)WW/ 0
.XX 
TakeXX 
(XX 
itemsPerPageXX "
)XX" #
.YY 
ToYY 
<YY 
TYY 
>YY 
(YY 
)YY 
.ZZ 
ToListZZ 
(ZZ 
)ZZ 
;ZZ 
}[[ 	
public]] 
async]] 
Task]] 
<]] 
T]] 
>]] 
GetByIdAsync]] )
<]]) *
T]]* +
>]]+ ,
(]], -
int]]- 0
id]]1 3
)]]3 4
{^^ 	
CheckIfIdIsCorrect__ 
(__ 
id__ !
)__! "
;__" #
returnaa 
awaitaa 
thisaa 
.aa 

proposalDbaa (
.bb 
AllAsNoTrackingbb  
(bb  !
)bb! "
.cc 
Wherecc 
(cc 
xcc 
=>cc 
xcc 
.cc 
Idcc  
==cc! #
idcc$ &
)cc& '
.dd 
Todd 
<dd 
Tdd 
>dd 
(dd 
)dd 
.ee 
FirstOrDefaultAsyncee $
(ee$ %
)ee% &
;ee& '
}ff 	
publichh 
asynchh 
Taskhh 
UpdateAsynchh %
(hh% &
inthh& )
idhh* ,
,hh, -!
ProposalEditViewModelhh. C
inputhhD I
,hhI J
stringhhK Q
userIdhhR X
)hhX Y
{ii 	
varjj 
proposaljj 
=jj 
awaitjj  
thisjj! %
.jj% &

proposalDbjj& 0
.jj0 1
Alljj1 4
(jj4 5
)jj5 6
.jj6 7
FirstOrDefaultAsyncjj7 J
(jjJ K
xjjK L
=>jjM O
xjjP Q
.jjQ R
IdjjR T
==jjU W
idjjX Z
)jjZ [
;jj[ \
ifll 
(ll 
proposalll 
==ll 
nullll  
)ll  !
{mm 
thrownn 
newnn "
NullReferenceExceptionnn 0
(nn0 1
ExceptionMessagesnn1 B
.nnB C
ProposalNotFoundnnC S
)nnS T
;nnT U
}oo 
ifqq 
(qq 
proposalqq 
.qq 
CreatedByIdqq $
!=qq% '
userIdqq( .
)qq. /
{rr 
throwss 
newss "
NullReferenceExceptionss 0
(ss0 1
stringtt 
.tt 
Formattt !
(tt! "
ExceptionMessagestt" 3
.tt3 4'
YouHaveToBeCreatorExceptiontt4 O
,ttO P
proposalttQ Y
.ttY Z
TitlettZ _
)tt_ `
)tt` a
;tta b
}uu 
proposalww 
.ww 
Titleww 
=ww 
inputww "
.ww" #
Titleww# (
;ww( )
proposalxx 
.xx 
Descriptionxx  
=xx! "
inputxx# (
.xx( )
Descriptionxx) 4
;xx4 5
proposalyy 
.yy 
ShortDescriptionyy %
=yy& '
inputyy( -
.yy- .
ShortDescriptionyy. >
;yy> ?
await{{ 
this{{ 
.{{ 

proposalDb{{ !
.{{! "
SaveChangesAsync{{" 2
({{2 3
){{3 4
;{{4 5
}|| 	
public~~ 
async~~ 
Task~~ 
DeleteByIdAsync~~ )
(~~) *
int~~* -
id~~. 0
,~~0 1
string~~2 8
userId~~9 ?
)~~? @
{ 	
var
ÄÄ 
modelToDelete
ÄÄ 
=
ÄÄ 
await
ÄÄ  %
this
ÄÄ& *
.
ÄÄ* +

proposalDb
ÄÄ+ 5
.
ÄÄ5 6
All
ÄÄ6 9
(
ÄÄ9 :
)
ÄÄ: ;
.
ÄÄ; <!
FirstOrDefaultAsync
ÄÄ< O
(
ÄÄO P
x
ÄÄP Q
=>
ÄÄR T
x
ÄÄU V
.
ÄÄV W
Id
ÄÄW Y
==
ÄÄZ \
id
ÄÄ] _
)
ÄÄ_ `
;
ÄÄ` a
if
ÇÇ 
(
ÇÇ 
modelToDelete
ÇÇ 
==
ÇÇ  
null
ÇÇ! %
)
ÇÇ% &
{
ÉÉ 
throw
ÑÑ 
new
ÑÑ $
NullReferenceException
ÑÑ 0
(
ÑÑ0 1
ExceptionMessages
ÑÑ1 B
.
ÑÑB C
ProposalNotFound
ÑÑC S
)
ÑÑS T
;
ÑÑT U
}
ÖÖ 
if
áá 
(
áá 
modelToDelete
áá 
.
áá 
CreatedById
áá )
!=
áá* ,
userId
áá- 3
)
áá3 4
{
àà 
throw
ââ 
new
ââ $
NullReferenceException
ââ 0
(
ââ0 1
string
ää 
.
ää 
Format
ää !
(
ää! "
ExceptionMessages
ää" 3
.
ää3 4)
YouHaveToBeCreatorException
ää4 O
,
ääO P
modelToDelete
ääQ ^
.
ää^ _
Title
ää_ d
)
ääd e
)
ääe f
;
ääf g
}
ãã 
this
çç 
.
çç 

proposalDb
çç 
.
çç 
Delete
çç "
(
çç" #
modelToDelete
çç# 0
)
çç0 1
;
çç1 2
await
èè 
this
èè 
.
èè 

proposalDb
èè !
.
èè! "
SaveChangesAsync
èè" 2
(
èè2 3
)
èè3 4
;
èè4 5
}
êê 	
public
íí 
int
íí 
GetCount
íí 
(
íí 
)
íí 
{
ìì 	
return
îî 
this
îî 
.
îî 

proposalDb
îî "
.
îî" #
All
îî# &
(
îî& '
)
îî' (
.
îî( )
Count
îî) .
(
îî. /
)
îî/ 0
;
îî0 1
}
ïï 	
public
óó 
int
óó 
GetCountPersonal
óó #
(
óó# $
string
óó$ *
userId
óó+ 1
)
óó1 2
{
òò 	
return
ôô 
this
ôô 
.
ôô 

proposalDb
ôô "
.
ôô" #
All
ôô# &
(
ôô& '
)
ôô' (
.
ôô( )
Where
ôô) .
(
ôô. /
x
ôô/ 0
=>
ôô1 3
x
ôô4 5
.
ôô5 6
CreatedById
ôô6 A
==
ôôB D
userId
ôôE K
)
ôôK L
.
ôôL M
Count
ôôM R
(
ôôR S
)
ôôS T
;
ôôT U
}
öö 	
private
úú 
static
úú 
void
úú  
CheckIfIdIsCorrect
úú .
(
úú. /
int
úú/ 2
id
úú3 5
)
úú5 6
{
ùù 	
if
ûû 
(
ûû 
id
ûû 
<
ûû 
$num
ûû 
)
ûû 
{
üü 
throw
†† 
new
†† /
!NegativeNumberNotAllowedException
†† ;
(
††; <
string
°° 
.
°° 
Format
°° !
(
°°! "
ExceptionMessages
°°" 3
.
°°3 4$
CanNotBeNegativeNumber
°°4 J
,
°°J K
nameof
°°L R
(
°°R S
id
°°S U
)
°°U V
)
°°V W
)
°°W X
;
°°X Y
}
¢¢ 
}
££ 	
private
•• 
static
•• 
void
•• 1
#CheckIfPageAndItemsPerPageIsCorrect
•• ?
(
••? @
int
••@ C
page
••D H
,
••H I
int
••J M
itemsPerPage
••N Z
)
••Z [
{
¶¶ 	
if
ßß 
(
ßß 
page
ßß 
<
ßß 
$num
ßß 
)
ßß 
{
®® 
throw
©© 
new
©© /
!NegativeNumberNotAllowedException
©© ;
(
©©; <
string
™™ 
.
™™ 
Format
™™ !
(
™™! "
ExceptionMessages
™™" 3
.
™™3 4$
CanNotBeNegativeNumber
™™4 J
,
™™J K
nameof
™™L R
(
™™R S
page
™™S W
)
™™W X
)
™™X Y
)
™™Y Z
;
™™Z [
}
´´ 
if
≠≠ 
(
≠≠ 
itemsPerPage
≠≠ 
<
≠≠ 
$num
≠≠  
)
≠≠  !
{
ÆÆ 
throw
ØØ 
new
ØØ /
!NegativeNumberNotAllowedException
ØØ ;
(
ØØ; <
string
∞∞ 
.
∞∞ 
Format
∞∞ !
(
∞∞! "
ExceptionMessages
∞∞" 3
.
∞∞3 4$
CanNotBeNegativeNumber
∞∞4 J
,
∞∞J K
nameof
∞∞L R
(
∞∞R S
itemsPerPage
∞∞S _
)
∞∞_ `
)
∞∞` a
)
∞∞a b
;
∞∞b c
}
±± 
}
≤≤ 	
}
≥≥ 
}¥¥ ≥
rC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\SettingsService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
SettingsService  
:! "
ISettingsService# 3
{ 
private 
readonly &
IDeletableEntityRepository 3
<3 4
Setting4 ;
>; <
settingsRepository= O
;O P
public 
SettingsService 
( &
IDeletableEntityRepository 9
<9 :
Setting: A
>A B
settingsRepositoryC U
)U V
{ 	
this 
. 
settingsRepository #
=$ %
settingsRepository& 8
;8 9
} 	
public 
int 
GetCount 
( 
) 
{ 	
return 
this 
. 
settingsRepository *
.* +
AllAsNoTracking+ :
(: ;
); <
.< =
Count= B
(B C
)C D
;D E
} 	
public 
IEnumerable 
< 
T 
> 
GetAll $
<$ %
T% &
>& '
(' (
)( )
{ 	
return 
this 
. 
settingsRepository *
.* +
All+ .
(. /
)/ 0
.0 1
To1 3
<3 4
T4 5
>5 6
(6 7
)7 8
.8 9
ToList9 ?
(? @
)@ A
;A B
} 	
} 
} Ó
oC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Data\VotesService.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Data  
{ 
public 

class 
VotesService 
: 
IVotesService  -
{ 
private 
readonly 
IRepository $
<$ %
Vote% )
>) *
votesRepository+ :
;: ;
public 
VotesService 
( 
IRepository '
<' (
Vote( ,
>, -
votesRepository. =
)= >
{ 	
this 
. 
votesRepository  
=! "
votesRepository# 2
;2 3
} 	
public 
double 
GetAverageVotes %
(% &
int& )

proposalId* 4
)4 5
{ 	
CheckIfIdIsCorrect 
( 

proposalId )
)) *
;* +
return 
this 
. 
votesRepository '
.' (
All( +
(+ ,
), -
. 
Where 
( 
x 
=> 
x 
. 

ProposalId (
==) +

proposalId, 6
)6 7
. 
Average 
( 
x 
=> 
x 
.  
Value  %
)% &
;& '
} 	
public 
async 
Task 
SetVoteAsync &
(& '
int' *

proposalId+ 5
,5 6
string7 =
userId> D
,D E
byteF J
valueK P
)P Q
{ 	
var   
vote   
=   
this   
.   
votesRepository   +
.  + ,
All  , /
(  / 0
)  0 1
.!! 
FirstOrDefault!! 
(!!  
x!!  !
=>!!" $
x!!% &
.!!& '

ProposalId!!' 1
==!!2 4

proposalId!!5 ?
&&!!@ B
x!!C D
.!!D E
UserId!!E K
==!!L N
userId!!O U
)!!U V
;!!V W
if## 
(## 
vote## 
==## 
null## 
)## 
{$$ 
vote%% 
=%% 
new%% 
Vote%% 
{&& 

ProposalId'' 
=''  

proposalId''! +
,''+ ,
UserId(( 
=(( 
userId(( #
,((# $
})) 
;)) 
await++ 
this++ 
.++ 
votesRepository++ *
.++* +
AddAsync+++ 3
(++3 4
vote++4 8
)++8 9
;++9 :
},, 
vote.. 
... 
Value.. 
=.. 
value.. 
;.. 
await// 
this// 
.// 
votesRepository// &
.//& '
SaveChangesAsync//' 7
(//7 8
)//8 9
;//9 :
}00 	
private22 
static22 
void22 
CheckIfIdIsCorrect22 .
(22. /
int22/ 2
id223 5
)225 6
{33 	
if44 
(44 
id44 
<44 
$num44 
)44 
{55 
throw66 
new66 -
!NegativeNumberNotAllowedException66 ;
(66; <
string77 
.77 
Format77 !
(77! "
ExceptionMessages77" 3
.773 4"
CanNotBeNegativeNumber774 J
,77J K
nameof77L R
(77R S
id77S U
)77U V
)77V W
)77W X
;77X Y
}88 
}99 	
}:: 
};; 